using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int tmp1 = 1;
            //double tmp2 = 2.0;
            //string tmp3 = "elo";
            //bool tmp4 = true;
            //var tmp5 = 1;
            //var tmp6 = "Napis";
            //var path = @"C:\Users\s13777\Desktop\cw1";

            //Console.WriteLine($"{tmp3} {tmp6} {tmp1+tmp5}");

            //var newPerson = new Person { FirstName = "Robert" };

            var httpClient = new HttpClient();
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl/";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
