using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace econ.Data
{
    public class Registration
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Hours { get; set; }
        public DateTime Created { get; set; }

        public int ProjectId { get; set; }
    }
}
