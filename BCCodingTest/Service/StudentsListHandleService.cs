using System.Net;
using BCCodingTest.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BCCodingTest.Handler
{
    /// <summary>
    /// Service
    /// </summary>
    public class StudentsListHandleService
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JsonResult<List<string>> GetRandomStudentsList(int num)
        {
            var result = new JsonResult<List<string>>();
            result.Code = (int)HttpStatusCode.BadRequest;
            try
            {
                var random = new Random();
                var studentsList = new List<string>();
                for (int i = 0; i < num; i++)
                {
                    studentsList.Add($"L{i}");
                }
                if (studentsList.Count > 0)
                {
                    result.Code = (int)HttpStatusCode.OK;
                    result.Data = studentsList;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Order
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JsonResult<List<string>> GetOrderdStudensList(List<string> students)
        {
            var result = new JsonResult<List<string>>();
            result.Code = (int)HttpStatusCode.BadRequest;
            try
            {
                var rearrangedStudents = new List<string>();
                int n = students.Count - 1;
                for (int i = 0; i < students.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        rearrangedStudents.Add(students[i]);
                    }
                    else
                    {
                        rearrangedStudents.Add(students[n]);
                        n--;
                    }
                }
                if (rearrangedStudents.Count == students.Count)
                {
                    result.Code = (int)HttpStatusCode.OK;
                    result.Data = rearrangedStudents;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
