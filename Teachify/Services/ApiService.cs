using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teachify.Models;

namespace Teachify.Services
{
    public class ApiService
    {
        public async void RegisterUser(string email, string password, string confirmPassword)
        {
            var registerModel = new RegisterModel(){
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var httpClient = new HttpClient(); // install Newtonsoft.Json
            var json = JsonConvert.SerializeObject(registerModel);            
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync("link/api/Account/Register", content);

        }
    }
}
