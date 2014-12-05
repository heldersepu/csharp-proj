using System.Linq;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrates.Models;

namespace Socrates.Tests.Models
{
    [TestClass]
    public class SocratesContextTest
    {
        [TestMethod]
        public void AllDepartments()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            var context = new SocratesContext(connStr);
            var departments = context.Departments.ToList();
            Assert.IsNotNull(departments);
        }
    }
}
