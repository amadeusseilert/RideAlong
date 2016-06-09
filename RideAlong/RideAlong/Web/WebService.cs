using Newtonsoft.Json;
using RideAlong.Resources;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RideAlong.Web
{
    public static class WebService
    {

        public static HttpClient client = new HttpClient();

        public static async Task<string> GET(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                } else {
                    return Strings.WS_ERROR;
                }
            } catch (WebException we)
            {
                return Strings.WE_ERROR;
            }
            
        }

        public static async Task<string> POST(string url, string json)
        {
            HttpResponseMessage response = null;
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return Strings.WS_OK;
                } else
                {
                    return Strings.WS_ERROR;
                }
            }
            catch (WebException we)
            {
                return Strings.WE_ERROR;
            }
        }

        public static async Task<string> PUT(string url, string json)
        {
            HttpResponseMessage response = null;
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return Strings.WS_OK;
                }
                else
                {
                    return Strings.WS_ERROR;
                }
            }
            catch (WebException we)
            {
                return Strings.WE_ERROR;
            }
        }

        public static async Task<string> DELETE(string url)
        {
            try
            {
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Strings.WS_OK;
                }
                else
                {
                    return Strings.WS_ERROR;
                }
            }
            catch (WebException we)
            {
                return Strings.WE_ERROR;
            }
        }
    }
}
