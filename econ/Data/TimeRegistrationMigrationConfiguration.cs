using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Security;
using WebMatrix.WebData;

namespace econ.Data
{

    public class TimeRegistrationMigrationConfiguration : DbMigrationsConfiguration<TimeRegistrationContext>
    {
        public TimeRegistrationMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;


        }

        protected override void Seed(TimeRegistrationContext context)
        {
            base.Seed(context);

#if DEBUG
            if (context.Projects.Count() == 0)
            {
                var project = new Project
                {
                    Name = "e-conomic case",
                    Created = DateTime.Now,
                    UserId = WebSecurity.CurrentUserId,
                    Registrations = new List<Registration>() {
                        new Registration() {
                            Description = "Analysis",
                            Hours = 1.5,
                            Created = DateTime.Now
                        },
                        new Registration() {
                            Description = "Design",
                            Hours = 1.5,
                            Created = DateTime.Now
                        },
                        new Registration() {
                            Description = "Build",
                            Hours = 1.5,
                            Created = DateTime.Now
                        }
                    }
                };

                context.Projects.Add(project);

                var anotherProject = new Project
                {
                    Name = "e-conomic case 2",
                    Created = DateTime.Now,
                    Registrations = new List<Registration>() {
                        new Registration() {
                            Description = "Analysis",
                            Hours = 1.5,
                            Created = DateTime.Now
                        },
                        new Registration() {
                            Description = "Design",
                            Hours = 1.5,
                            Created = DateTime.Now
                        },
                        new Registration() {
                            Description = "Build",
                            Hours = 1.5,
                            Created = DateTime.Now
                        }
                    }
                };

                context.Projects.Add(anotherProject);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    var msg = ex.Message;
                    Debug.WriteLine(msg);
                }


#endif
            }
        }
    }
}
