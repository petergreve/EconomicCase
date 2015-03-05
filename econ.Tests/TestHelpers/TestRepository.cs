using econ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econ.Tests.TesterHelpers
{
    class TestRepository : ITimeRegistrationRepository
    {


        public IQueryable<Project> GetProjects()
        {
            return new Project[]
            {
                new Project()
                {
                    Id = 1,
                    Name = "Test Project 1",
                    Created = DateTime.Now
                },
                new Project()
                {
                    Id = 2,
                    Name = "Test Project 3",
                    Created = DateTime.Now
                },
                new Project()
                {
                    Id = 3,
                    Name = "Test Project 3",
                    Created = DateTime.Now
                }
            }.AsQueryable();
        
        }

        public IQueryable<Project> GetProjectsIncludingRegistrations()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Registration> GetRegistrationsByProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool AddProject(Project newProject)
        {
            throw new NotImplementedException();
        }

        public bool AddRegistration(Registration newRegistration)
        {
            throw new NotImplementedException();
        }
    }
}
