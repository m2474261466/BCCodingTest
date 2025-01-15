using WebApiProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCodingTest.Controllers;
using BCCodingTest.Handler;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Tests.Tests
{
    [TestClass()]
    public class StudentControllerTestsTests
    {
        [TestMethod()]
        public void GetRandomStudents_ReturnsListOfStudentsTest()
        {
            var instance = new StudentsListHandleService();
            var controller = new OrderNumListController(instance);
            var result = controller.GetRandomStudensList(20);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetRandomStudents_ReturnsListOfStudentsTest2()
        {
            var instance = new StudentsListHandleService();
            var controller = new OrderNumListController(instance);
            var randomStudents = new List<string> { "L0", "L1", "L2", "L3", "L4" };
            var result = controller.GetOrderdStudensList(randomStudents);
            Assert.IsNotNull(result);
        }
    }
}