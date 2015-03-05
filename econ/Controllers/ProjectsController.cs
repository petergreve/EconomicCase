using econ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace econ.Controllers
{
    public class ProjectsController : ApiController
    {
        private ITimeRegistrationRepository _repo;

        public ProjectsController(ITimeRegistrationRepository repo)
        {
            _repo = repo;

        }

        public IEnumerable<Project> Get(bool includeRegistrations = false)
        {
            IQueryable<Project> results;

            if(includeRegistrations) {
                results = _repo.GetProjectsIncludingRegistrations();
            }else {
                results = _repo.GetProjects();

            }

            var projects = results.OrderByDescending(t => t.Created).Take(10).ToList();
            return projects;
        }

        public HttpResponseMessage Post([FromBody] Project newProject)
        {

            if (newProject.Created == default(DateTime))
            {
                newProject.Created = DateTime.UtcNow;
            }
            if (_repo.AddProject(newProject) && _repo.Save())
            {

                return Request.CreateResponse(HttpStatusCode.Created, newProject);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
