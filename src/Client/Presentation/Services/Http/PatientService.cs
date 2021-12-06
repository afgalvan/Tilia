using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Services.Http.Connection;
using Requests.Patients;
using RestSharp;

namespace Presentation.Services.Http
{
    public class PatientService
    {
        private readonly IRestComposer _restComposer;

        public PatientService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task RegisterPatient(string personId, int idType, string firstName,
            string lastName, int genre, string city, DateTime birthDate,
            string occupation, string studies, string sport, string modality, string coach,
            DateTime startDate, bool continuousTraining, bool trainingPlan,
            int dominance, string address, string livingCity, int stratum, string phoneNumber,
            string landline, CancellationToken cancellation)
        {
            const string endpoint = "/patients";
            var patientRequest = new CreatePatientRequest
            {
                PersonId           = personId,
                IdType             = idType,
                FirstName          = firstName,
                LastName           = lastName,
                Genre              = genre,
                City               = city,
                BirthDate          = birthDate,
                Occupation         = occupation,
                Studies            = studies,
                Sport              = sport,
                Modality           = modality,
                Coach              = coach,
                StartDate          = startDate,
                ContinuousTraining = continuousTraining,
                TrainingPlan       = trainingPlan,
                Dominance          = dominance,
                Address            = address,
                LivingCity         = livingCity,
                Stratum            = stratum,
                PhoneNumber        = phoneNumber,
                Landline           = landline,
            };
            IRestRequest request = new RestRequest(endpoint).AddJsonBody(patientRequest);
            await _restComposer.Post<Unit>(request, cancellation);
        }

        public async Task<IEnumerable<PatientResponse>> GetAllPatients(
            CancellationToken cancellation)
        {
            const string endpoint = "/patients";
            return await _restComposer.GetAsync<IEnumerable<PatientResponse>>(endpoint,
                cancellation);
        }
    }
}
