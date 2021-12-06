using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Presentation.Services.Http.Connection;

namespace Presentation.Services.Http
{
    public class RolesService
    {
        private readonly IRestComposer _restComposer;

        public RolesService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<IEnumerable<SanitaryRole>> GetSanitaryRoles(
            CancellationToken cancellation)
        {
            const string endpoint = "/roles/sanitary";
            return await _restComposer.GetAsync<IEnumerable<SanitaryRole>>(endpoint, cancellation);
        }
    }
}
