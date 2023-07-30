using InsuranceApp.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace InsuranceApp.Services
{
    namespace InsuranceApp.Services
    {
        public class LoginService : ILoginRepository
        {

            public async Task<User> Login(string Username, string Password)
            {

                HttpClient client = new HttpClient();

                string url = GlobalVariables.serverAdress + "/api/users/auth";

                string requestBodyContent = "{\"username\":\"" + Username + "\", \"password\":\"" + Password + "\"}";

                HttpResponseMessage response = null;

                var request = new HttpRequestMessage
                {

                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(requestBodyContent, Encoding.UTF8, MediaTypeNames.Application.Json)
                };

                response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Status code error");
                    return null;
                }

                string content = await response.Content.ReadAsStringAsync();
                string token = JObject.Parse(content).Value<string>("token");

                if (token == null)
                {
                    Console.WriteLine("Unable to retrieve token");
                    return null;
                }

                return await Task.FromResult(
                    new User
                    {
                        Username = Username,
                        Password = Password,
                        Token = token
                    }
                );

            }

        }

    }
}
