using InsuranceApp.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceApp.Services
{
    public interface ILoginRepository
    {
        Task<User> Login(string Username, string Password);
       
    }
}
