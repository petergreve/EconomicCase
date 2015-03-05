using econ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace econ.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public ICollection<Registration> Registrations { get; set; }

    }
}