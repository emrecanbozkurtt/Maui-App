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


namespace InsuranceApp.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Login(string Username, string Password)
        {
            {
                var user = new List<User>();
                var client = new HttpClient();

                string url = "https://localhost:7206/api/users" + Username + "/" + Password;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<List<User>>(content);
                    return await Task.FromResult(user.FirstOrDefault());
                }
                else
                {
                    return null;
                }
            }
        }



    }

}
