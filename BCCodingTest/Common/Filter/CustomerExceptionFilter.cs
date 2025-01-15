using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BCCodingTest.Common.Filter
{
    public class CustomerExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                var result = new JsonResult<string>
                {
                    Code = 0,
                    Message = context.Exception.Message
                };
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(result)
                };
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
