using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teachify.Models;
using System.Net;
using System.Net.Http.Headers;

namespace Teachify.Services
{
    public class ApiService
    {
        public async Task<bool> RegisterUser(string email, string password, string confirmPassword) // done 
        {
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var httpClient = new HttpClient(); // install Newtonsoft.Json
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://loteachifyv03.azurewebsites.net/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<TokenResponse> GetToken(string email, string password) // done
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"email={email}&password={password}",
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://loteachifyv03.azurewebsites.net/api/Account/Token", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(jsonResult);
            return result;
        }
        public async Task<bool> PasswordRecovery(string email) // Done
        {
            var httpClient = new HttpClient();
            var recoverPasswordModel = new PasswordRecoveryModel()
            {
                Email = email
            };
            var json = JsonConvert.SerializeObject(recoverPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://loteachifyv03.azurewebsites.net/api/Account/PasswordRecovery", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword) //done
        {
            var httpClient = new HttpClient();
            var changePasswordModel = new ChangePasswordModel()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(changePasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.PostAsync("https://loteachifyv03.azurewebsites.net/api/Account/ChangePassword", content);// customLink
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> BecomeAnInstructor(Instructor instructor) // Done
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(instructor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.PostAsync("https://loteachifyv03.azurewebsites.net/api/Instructor/instructor", content);
            return response.StatusCode == HttpStatusCode.Created;
        }
        public async Task<List<Instructor>> GetIntructors() // Done
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("https://loteachifyv03.azurewebsites.net/api/Instructor/instructors");
            return JsonConvert.DeserializeObject<List<Instructor>>(response);
        }
        public async Task<Instructor> GetIntructor(Guid id) // Done
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("https://loteachifyv03.azurewebsites.net/api/Instructor/instructors?id=" + id);
            return JsonConvert.DeserializeObject<Instructor>(response);
        }
        public async Task<List<Instructor>> SearchIntructors(string subject, string gender, string city) // Done
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("https://loteachifyv03.azurewebsites.net/api/Instructor/instructors?subject=" + subject +
                "&gender=" + gender +
                "&city=" + city);
            return JsonConvert.DeserializeObject<List<Instructor>>(response);
        }
        public async Task<List<City>> GetCities() // done
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://loteachifyv03.azurewebsites.net/api/City/cities");
            return JsonConvert.DeserializeObject<List<City>>(response);
        }
        public async Task<List<Course>> GetCourses() // done
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://loteachifyv03.azurewebsites.net/api/Course/courses");
            return JsonConvert.DeserializeObject<List<Course>>(response);
        }
    }
}
