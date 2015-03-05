using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econ.Data
{
    public interface ITimeRegistrationRepository
    {
        IQueryable<Project> GetProjects();
        IQueryable<Project> GetProjectsIncludingRegistrations();

        IQueryable<Registration> GetRegistrationsByProject(int projectId);

        bool Save();
        bool AddProject(Project newProject);
        bool AddRegistration(Registration newRegistration);
    }
}
