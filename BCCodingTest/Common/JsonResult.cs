namespace BCCodingTest.Common
{
    /// <summary>
    /// Common Result Return
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResult<T>
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
