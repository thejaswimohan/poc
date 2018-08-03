namespace EmployeeApp.Unittest
{
    using System;
    using System.Web.Http.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SampleWebAPI.Controllers;

    [TestClass]
    public class SimpleTests
    {
       
        [TestMethod]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            var controller = new EmployeeController();
            var result = controller.getEmployee();
            Assert.IsTrue(result!=null);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnEmployeesBasedOnId()
        {
            int id = 40006;
            var controller = new EmployeeController();
            var result = controller.EmployeesgetbyId(id);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldthrowExceptionNotFoundWhenGettingEmployeeById()
        {
            int id = 4000;
            var exceptionIsThrown = false;
            Object obj = true;
            var controller = new EmployeeController();
            try
            {
                var result = controller.EmployeesgetbyId(id) as NotFoundResult;
            }
            catch (Exception)
            {
                exceptionIsThrown = true;
            }
            Assert.AreEqual(exceptionIsThrown, obj);           
        }
    }
}
