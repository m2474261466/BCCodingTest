using BCCodingTest.Controllers;
using BCCodingTest.Handler;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace WebApiProject.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void GetRandomStudents_ReturnsListOfStudents()
        {
            var instance=new StudentsListHandleService();
            var controller = new OrderNumListController(instance);
            var result = controller.GetRandomStudensList(20);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var students = Assert.IsAssignableFrom<List<string>>(okResult.Value);
            Assert.True(students.Count > 20);
        }

        [Fact]
        public void RearrangeStudents_RearrangesCorrectly()
        {
            var instance = new StudentsListHandleService();
            var controller = new OrderNumListController(instance);
            var randomStudents = new List<string> { "L0", "L1", "L2", "L3", "L4" };
            var result = controller.GetOrderdStudensList(randomStudents);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var rearrangedStudents = Assert.IsAssignableFrom<List<string>>(okResult.Value);
            Assert.Equal(new List<string> { "L0", "L4", "L1", "L3", "L2" }, rearrangedStudents);
        }
    }
}