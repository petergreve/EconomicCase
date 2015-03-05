using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace econ.Data
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository
    {
        TimeRegistrationContext _ctx;

        public TimeRegistrationRepository(TimeRegistrationContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Project> GetProjectsIncludingRegistrations()
        {
            return _ctx.Projects.Include("Registrations");
        }

        public IQueryable<Registration> GetRegistrationsByProject(int projectId)
        {
            return _ctx.Registrations.Where(r => r.ProjectId == projectId);
        }


        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TO-DO log
                return false;
            }
        }

        public bool AddProject(Project newProject)
        {
            try
            {
                _ctx.Projects.Add(newProject);
                return true;
            }
            catch (Exception ex)
            {
                //TO-DO log
                return false;
            }

        }

        public IQueryable<Project> GetProjects()
        {
            return _ctx.Projects;
        }


        public bool AddRegistration(Registration newRegistration)
        {
            try
            {
                _ctx.Registrations.Add(newRegistration);
                return true;
            }
            catch (Exception ex)
            {
                //TO-DO log
                return false;
            }
        }
    }
}