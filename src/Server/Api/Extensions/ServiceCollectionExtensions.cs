using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using Api.Extensions.Settings;
using Application.Dashboard.GetAll;
using Application.MedicalFiles.Create;
using Application.MedicalFiles.Filter;
using Application.MedicalFiles.FindById;
using Application.MedicalFiles.GetAll;
using Application.MedicalFiles.Remove;
using Application.MedicalFiles.Toggle;
using Application.Patients.Create;
using Application.Patients.FindById;
using Application.Patients.GetAll;
using Application.Users.Authenticate;
using Application.Users.Create;
using Application.Users.FindById;
using Application.Users.GenerateJwt;
using Application.Users.GetAll;
using Domain.Employees;
using Domain.Employees.Repositories;
using Domain.Locations;
using Domain.Locations.Repositories;
using Domain.MedicalFiles;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalRecords;
using Domain.MedicalFiles.Repositories;
using Domain.Patients;
using Domain.Patients.Repositories;
using Domain.People;
using Domain.People.Repositories;
using Domain.SharedLib.Email;
using Domain.Users;
using Domain.Users.Repositories;
using Hangfire;
using Hangfire.Storage.SQLite;
using Infrastructure.Email;
using Infrastructure.Persistence.Employees;
using Infrastructure.Persistence.IdTypes;
using Infrastructure.Persistence.Locations;
using Infrastructure.Persistence.MedicalFiles;
using Infrastructure.Persistence.Patients;
using Infrastructure.Persistence.Users;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Requests.Appointments;
using Requests.Appointments.MedicalNotes;
using Requests.Auth;
using Requests.Employees;
using Requests.Patients;
using Requests.Users;
using SharedLib.Persistence;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionInformation = new DbConnectionConfig(configuration);

            services.AddDbContext<TiliaDbContext>(options =>
                options.SetupDatabaseEngine(connectionInformation)
                    .UseSnakeCaseNamingConvention()
            );
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<SecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<JwtGenerator>();
            services.AddScoped<UserCreator>();
            services.AddScoped<IEmailSender<User>, UserEmailSender>();
            services.AddScoped<UsersRetriever>();
            services.AddScoped<UserFinder>();
            services.AddScoped<UserAuthenticator>();
            services.AddScoped<PatientCreator>();
            services.AddScoped<PatientsRetriever>();
            services.AddScoped<PatientsFinder>();
            services.AddScoped<AppointmentFinder>();
            services.AddScoped<AppointmentCreator>();
            services.AddScoped<AppointmentsRetriever>();
            services.AddScoped<AppointmentFilter>();
            services.AddScoped<AppointmentToggler>();
            services.AddScoped<AppointmentRemover>();
            services.AddScoped<StatisticsRetriever>();
            services.AddMediatR(Assembly.Load("Application"));
        }

        public static void AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // services.ConfigureHangFire();

            services.AddFluentEmail(configuration["Smtp:Username"], "Tilia")
                .AddSmtpSender(CreateClient(configuration));
            services.AddSingleton(GetTypeAdapterConfig());
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IUsersRepository, OracleUsersRepository>();
            services.AddScoped<IIdTypesRepository, OracleIdTypesRepository>();
            services.AddScoped<ILocationsRepository, OracleLocationsRepository>();
            services.AddScoped<IPatientsRepository, OraclePatientsRepository>();
            services.AddScoped<IAttentionHistoryRepository, OracleAttentionHistoryRepository>();
            services.AddScoped<ISanitaryRolesRepository, OracleSanitaryRolesRepository>();
            services
                .AddScoped<ISanitaryEmployeesRepository, OracleSanitaryEmployeesRepository>();
            services
                .AddScoped<IMedicalAppointmentRepository,
                    OracleMedicalAppointmentRepository>();
        }

        private static void ConfigureHangFire(this IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSQLiteStorage()
            );
            services.AddHangfireServer();
        }

        private static SmtpClient CreateClient(IConfiguration configuration)
        {
            var smtpClient = new SmtpClient(configuration["Smtp:Host"],
                int.Parse(configuration["Smtp:Port"], CultureInfo.CurrentCulture)
            );
            string username = configuration["Smtp:Username"];
            string password = configuration["Smtp:Password"];
            smtpClient.Credentials           = new NetworkCredential(username, password);
            smtpClient.EnableSsl             = true;
            smtpClient.UseDefaultCredentials = false;
            return smtpClient;
        }

        private static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var configuration = new TypeAdapterConfig();
            configuration.NewConfig<CreateUserRequest, CreateUserCommand>();
            configuration.NewConfig<LoginUserRequest, AuthenticateCommand>();
            configuration.NewConfig<DiagnosisDto, Diagnosis>();
            configuration.NewConfig<ReferralDto, Referral>();
            configuration.NewConfig<ManagementPlanDto, ManagementPlan>();

            configuration.NewConfig<CreateEmployeeRequest, SanitaryEmployee>()
                .Map(employee => employee.City, request => new City(request.City));

            configuration.NewConfig<MedicalNoteDto, MedicalNote>()
                .Map(note => note.EvolutionSheet,
                    dto => new EvolutionSheet(dto.EvolutionSheet));

            configuration.NewConfig<CreateMedicalAppointmentRequest, MedicalAppointment>()
                .Map(appointment => appointment.Anamnesis,
                    request => new Anamnesis(request.AnamnesisDescription))
                .Map(appointment => appointment.MedicalNote, request => request.MedicalNote);

            configuration.NewConfig<MedicalAppointment, MedicalAppointmentResponse>()
                .Map(response => response.Doctor,
                    appointment =>
                        $"{appointment.DoctorCaring.FirstName} {appointment.DoctorCaring.LastName}")
                .Map(response => response.Patient,
                    appointment =>
                        $"{appointment.Patient.FirstName} {appointment.Patient.LastName}");

            configuration.NewConfig<SanitaryEmployee, EmployeeResponse>()
                .Map(response => response.IdType, patient => patient.IdType.Name)
                .Map(response => response.RoleName, patient => patient.SanitaryRole.Name);

            configuration.NewConfig<Patient, PatientResponse>()
                .Map(response => response.Sport, patient => patient.SportsData.Sport)
                .Map(response => response.IdType, patient => patient.IdType.Name);

            configuration.NewConfig<CreatePatientCommand, Patient>()
                .Map(patient => patient.ContactData.Address, command => command.Address)
                .Map(patient => patient.ContactData.Landline, command => command.Landline)
                .Map(patient => patient.ContactData.LivingCity,
                    command => new City(command.LivingCity))
                .Map(patient => patient.ContactData.PhoneNumber,
                    command => command.PhoneNumber)
                .Map(patient => patient.ContactData.Stratum, command => command.Stratum)
                .Map(patient => patient.SportsData.Coach, command => command.Coach)
                .Map(patient => patient.SportsData.Dominance, command => command.Dominance)
                .Map(patient => patient.SportsData.Modality, command => command.Modality)
                .Map(patient => patient.SportsData.Sport, command => command.Sport)
                .Map(patient => patient.SportsData.ContinuousTraining,
                    command => command.ContinuousTraining)
                .Map(patient => patient.SportsData.StartDate, command => command.StartDate)
                .Map(patient => patient.SportsData.TrainingPlan,
                    command => command.TrainingPlan)
                .Map(patient => patient.Genre, command => command.Genre)
                .Map(patient => patient.IdType, command => new IdType(command.IdType))
                .Map(patient => patient.City, command => new City(command.City));
            return configuration;
        }
    }
}
