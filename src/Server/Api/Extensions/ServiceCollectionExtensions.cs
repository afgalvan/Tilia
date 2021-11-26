using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Api.Controllers;
using Api.Extensions.Settings;
using Application.Patients.Create;
using Application.Patients.FindById;
using Application.Patients.GetAll;
using Application.Users.Authenticate;
using Application.Users.Create;
using Application.Users.FindById;
using Application.Users.GenerateJwt;
using Application.Users.GetAll;
using Domain.Locations;
using Domain.Locations.Repositories;
using Domain.Patients;
using Domain.Patients.Repositories;
using Domain.People;
using Domain.People.Repositories;
using Domain.Users.Repositories;
using Hangfire;
using Hangfire.Storage.SQLite;
using Infrastructure.Persistence.IdTypes;
using Infrastructure.Persistence.Locations;
using Infrastructure.Persistence.Patients;
using Infrastructure.Persistence.Users;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Requests.Auth;
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
            services.AddScoped<UsersRetriever>();
            services.AddScoped<UserFinder>();
            services.AddScoped<UserAuthenticator>();
            services.AddScoped<PatientCreator>();
            services.AddScoped<PatientsRetriever>();
            services.AddScoped<PatientsFinder>();
            services.AddMediatR(Assembly.Load("Application"));
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // services.ConfigureHangFire();
            services.AddSingleton(GetTypeAdapterConfig());
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IUsersRepository, OracleUsersRepository>();
            services.AddScoped<IIdTypesRepository, OracleIdTypesRepository>();
            services.AddScoped<ILocationsRepository, OracleLocationsRepository>();
            services.AddScoped<IPatientsRepository, OraclePatientsRepository>();
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

        private static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var configuration = new TypeAdapterConfig();
            configuration.NewConfig<CreateUserRequest, CreateUserCommand>();
            configuration.NewConfig<LoginUserRequest, AuthenticateCommand>();
            configuration.NewConfig<CreatePatientCommand, Patient>()
                .Map(patient => patient.ContactData.Address, command => command.Address)
                .Map(patient => patient.ContactData.Landline, command => command.Landline)
                .Map(patient => patient.ContactData.LivingCity, command => new City(command.LivingCity))
                .Map(patient => patient.ContactData.PhoneNumber, command => command.PhoneNumber)
                .Map(patient => patient.ContactData.Stratum, command => command.Stratum)
                .Map(patient => patient.SportsData.Coach, command => command.Coach)
                .Map(patient => patient.SportsData.Dominance, command => command.Dominance)
                .Map(patient => patient.SportsData.Modality, command => command.Modality)
                .Map(patient => patient.SportsData.Sport, command => command.Sport)
                .Map(patient => patient.SportsData.ContinuousTraining, command => command.ContinuousTraining)
                .Map(patient => patient.SportsData.StartDate, command => command.StartDate)
                .Map(patient => patient.SportsData.TrainingPlan, command => command.TrainingPlan)
                .Map(patient => patient.Genre, command => command.Genre)
                .Map(patient => patient.IdType, command => new IdType(command.IdType))
                .Map(patient => patient.City, command => new City(command.City));
            return configuration;
        }
    }
}
