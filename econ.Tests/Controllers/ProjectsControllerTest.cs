using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using econ.Controllers;
using econ.Tests.TesterHelpers;

namespace econ.Tests.Controllers
{
    [TestClass]
    public class ProjectsControllersTests
    {
        [TestMethod]
        public void ProjectsController_Get()
        {
            var ctrl = new ProjectsController(new TestRepository());

            var results = ctrl.Get(false);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
            Assert.IsNotNull(results.First());
        }
    }
}
