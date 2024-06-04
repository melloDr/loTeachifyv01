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
        public async Task<bool> RegisterUser(string email, string password, string confirmPassword)
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
            var response = await httpClient.PostAsync("link/api/Account/Register", content);// customLink
            return response.IsSuccessStatusCode;
        }
        public async Task<TokenResponse> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"grant_type=password&username={email}&password={password}",
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("link//Token", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(jsonResult);
            return result;
        }
        public async Task<bool> PasswordRecovery(string email)
        {
            var httpClient = new HttpClient();
            var recoverPasswordModel = new PasswordRecoveryModel()
            {
                Email = email
            };
            var json = JsonConvert.SerializeObject(recoverPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("link/api/Users/PasswordRecovery", content);// customLink
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
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
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeadervalue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.PostAsync("link/api/Account/ChangePassword", content);// customLink
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> BecomeAnInstructor(Instructor instructor)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(instructor);
            var json = JsonConvert.SerializeObject(changePasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeadervalue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.PostAsync("link/api/instructor", content);// customLink
            return response.StatusCode == HttpStatusCode.Created;
        }
        public async Task<List<Instructor>> GetIntructors()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeadervalue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("link/api/instructors");
            return JsonConvert.DeserializeObject<List<Instructor>>(response);
        }
        public async Task<Instructor> GetIntructor(int id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeadervalue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("link/api/instructors/" + id);
            return JsonConvert.DeserializeObject<Instructor>(response);
        }
        public async Task<List<Instructor>> SearchIntructors(string subject, string gender, string city)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeadervalue("bearer", "Put Your Access Token Here...");
            var response = await httpClient.GetStringAsync("link/api/instructors?subject=" + subject +
                "&gender=" + gender +
                "&city=" + city);
            return JsonConvert.DeserializeObject<List<Instructor>>(response);
        }
        public async Task<List<City>> GetCities()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("link/api/cities");
            return JsonConvert.DeserializeObject<List<City>>(response);
        }
        public async Task<List<Course>> GetCourses()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("link/api/courses");
            return JsonConvert.DeserializeObject<List<Course>>(response);
        }
    }
}
