using System.Threading;
using System.Threading.Tasks;
using Presentation.Services.Http.Connection;

namespace Presentation.Services.Http
{
    public class PatientService
    {
        private readonly IRestComposer _restComposer;

        public PatientService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task PostPatient(CancellationToken cancellation)
        {
            var endpoint = "/patients";
        }

    }
}
