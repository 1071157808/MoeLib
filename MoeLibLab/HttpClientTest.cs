using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Moe.Lib;

namespace MoeLibLab
{
    internal static class HttpClientTest
    {
        internal static async Task TestAsync()
        {
            try
            {
                HttpClient client = HttpClientFactory.Create(new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0) { CharSet = "utf-8" });
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.5) { CharSet = "utf-8" });
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html", 0.2) { CharSet = "utf-8" });
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.1) { CharSet = "utf-8" });
                client.DefaultRequestHeaders.AcceptEncoding.Clear();
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("*"));
                client.Timeout = 1.Minutes();

                using (client)
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.baidu.com/");
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(response.Headers.AcceptRanges.Join(";"));
                    Console.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}