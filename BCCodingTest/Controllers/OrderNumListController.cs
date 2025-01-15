using BCCodingTest.Common;
using BCCodingTest.Handler;
using Microsoft.AspNetCore.Mvc;

namespace BCCodingTest.Controllers
{
    /// <summary>
    /// Student Data Order And Random Generate
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderNumListController:ControllerBase
    {

        private readonly  StudentsListHandleService _service;
        
        public OrderNumListController(StudentsListHandleService service)
        {
           _service = service;
        }
        /// <summary>
        /// Get Random Generate Students List
        /// </summary>
        /// <returns></returns>
        [HttpGet("randomGenerate")]
        public JsonResult<List<string>> GetRandomStudensList(int num)
        {
           return   _service.GetRandomStudentsList(num);
        }

        /// <summary>
        /// Order Students List
        /// </summary>
        /// <returns></returns>
        [HttpPost("orderStudensList")]
        public JsonResult<List<string>>  GetOrderdStudensList([FromBody]List<string> students)
        {
            return  _service.GetOrderdStudensList( students);
        }
    }
}
