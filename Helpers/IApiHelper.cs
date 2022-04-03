using OSBookReviewMAUI.Models;

namespace OSBookReviewMAUI.Helpers
{
    public interface IApiHelper
    {
        Task<Login> Authenticate(Login login);
        Task<List<T>> GetList<T>(string url);
        Task<T> GetSingleObject<T>(string url);
        Task<HttpResponseMessage> PostRequest(string url, HttpContent data);
        Task<HttpResponseMessage> PutRequest(string url, HttpContent data);
        Task SetLogin(Login login);
    }
}