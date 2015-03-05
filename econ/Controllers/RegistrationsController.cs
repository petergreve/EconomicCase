using econ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace econ.Controllers
{
    public class RegistrationsController : ApiController
    {
        private ITimeRegistrationRepository _repo;

        public RegistrationsController(ITimeRegistrationRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Registration> Get(int projectId)
        {

            return _repo.GetRegistrationsByProject(projectId);
        }

        public HttpResponseMessage Post(int projectId, [FromBody] Registration newRegistration)
        {

            if (newRegistration.Created == default(DateTime))
            {
                newRegistration.Created = DateTime.UtcNow;
            }

            newRegistration.ProjectId = projectId;

            if (_repo.AddRegistration(newRegistration) && _repo.Save())
            {

                return Request.CreateResponse(HttpStatusCode.Created, newRegistration);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
