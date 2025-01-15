namespace BCCodingTest.ServiceCheck
{
    public class HttpServiceConnectionChecker
    {
        private readonly string _serviceUrl;
        private readonly HttpClient _httpClient;

        public HttpServiceConnectionChecker(string serviceUrl, HttpClient httpClient)
        {
            _serviceUrl = serviceUrl;
            _httpClient = httpClient;
        }

        public async Task<bool> CheckConnection()
        {
            try
            {
                var response = await _httpClient.GetAsync(_serviceUrl);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP服务连接错误: {ex.Message}");
                return false;
            }
        }
    }
}
