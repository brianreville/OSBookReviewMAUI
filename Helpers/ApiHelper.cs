using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using OSBookReviewMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OSBookReviewMAUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient ApiClient { get; set; }
        private Login _login { get; set; }

        public ApiHelper()
        {
            InitializeClient();
        }
        // default initalisation of the Http Client
        private void InitializeClient()
        {
            // set a default if necessary
            string api = Preferences.Get("WebUrl", "https://bookreview2022.azurewebsites.net/");
            ApiClient = new HttpClient
            {
                BaseAddress = new Uri(api)
            };
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _login = new Login();

        }
        // sets the JWT token for the web api to the one retreived on authenticated user login.
        public async Task SetLogin(Login login)
        {
            await Task.Run(() =>
            {
                _login = login;
                ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", login.AccessToken);
            });
        }
        // authenticates the user and then returns user login with registered details
        public async Task<Login> Authenticate(Login login)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username",login.UserName),
                new KeyValuePair<string, string>("password", login.UserPword),
                new KeyValuePair<string, string>("Ip6address",login.RegisteredDeviceCode),
                new KeyValuePair<string, string>("grant_type","password")
            });

            using HttpResponseMessage response = await ApiClient.PostAsync("/api/Token/Login", data);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<Login>>();
                Login first = result.FirstOrDefault();
                return first;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        // returns a list of objects of Type T in event of error returns an empty list
        public async Task<List<T>> GetList<T>(string url)
        {

            try
            {
                HttpResponseMessage response = await ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<List<T>>(result);
                    return res;
                }
                else
                {
                    var res = new List<T>();
                    return res;
                }
            }
            catch (HttpRequestException ex)
            {
                Crashes.TrackError(ex);
                var res = new List<T>();
                return res;
            }

        }
        // complets a put http request
        public async Task<HttpResponseMessage> PutRequest(string url, HttpContent data)
        {
            using HttpResponseMessage response = await ApiClient.PutAsync(url, data);
            return response.IsSuccessStatusCode ? response : response;
        }
        // complets a put http request
        public async Task<HttpResponseMessage> PostRequest(string url, HttpContent data)
        {
            using HttpResponseMessage response = await ApiClient.PostAsync(url, data);
            return response.IsSuccessStatusCode ? response : response;
        }
    }
}
