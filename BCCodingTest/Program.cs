using System.Text;

namespace BCCodingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
