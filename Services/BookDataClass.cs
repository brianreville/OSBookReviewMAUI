using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;
using System.Text;

namespace OSBookReviewMAUI.Services
{
    public class BookDataClass : IDataStore<BookReview>
    {

        public IApiHelper ApiHelper => DependencyService.Get<ApiHelper>();
        public BookDataClass()
        {

        }

        public async Task<bool> AddRecord(BookReview b)
        {
            return await AddReview(b);
        }

        public async Task<bool> UpdateRecord(BookReview b)
        {
            return await UpdateReview(b);
        }


        public async Task<BookReview> GetSingle(int id)
        {
            return await GetBookByID(id);

        }
        public async Task<IEnumerable<BookReview>> GetListAsync()
        {
            return await GetBooks();
        }

        public async Task<IEnumerable<BookReview>> GetListAsync(int AID)
        {
            return await GetBooks(AID);
        }

        public async Task<IEnumerable<BookReview>> GetListAsync(string authorname)
        {
            return await GetBooks(authorname);
        }


        private async Task<bool> AddReview(BookReview b)
        {
            try
            {
                string weblink = $"api/book/Insert";

                // set amd create the json payload for the request
                var json = JsonConvert.SerializeObject(b);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // utilise the api helper to send the post request
                var response = await ApiHelper.PostRequest(weblink, data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }


        private async Task<bool> UpdateReview(BookReview b)
        {
            try
            {
                string weblink = $"api/book/Update";

                // set amd create the json payload for the request
                var json = JsonConvert.SerializeObject(b);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // utilise the api helper to send the post request
                var response = await ApiHelper.PutRequest(weblink, data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        private async Task<BookReview> GetBookByID(int BDID)
        {
            try
            {
                string weblink = $"api/book/GetBookByID?bdid={BDID}";

                var response = await ApiHelper.GetSingleObject<BookReview>(weblink);

                return response;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                BookReview res = new();
                return res;
            }
        }

        private async Task<List<BookReview>> GetBooks()
        {
            List<BookReview> res = new();

            return res;
        }


        private async Task<List<BookReview>> GetBooks(int AID)
        {
            try
            {
                string weblink = $"api/book/GetAuthorBooks?aid={AID}";

                var response = await ApiHelper.GetList<BookReview>(weblink);

                return response;

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);

                List<BookReview> res = new();

                return res;
            }
        }

        private async Task<List<BookReview>> GetBooks(string authorname)
        {
            try
            {
                string weblink = $"api/book/GetAuthorBooksByName?name={authorname}";

                var response = await ApiHelper.GetList<BookReview>(weblink);

                return response;

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);

                List<BookReview> res = new();

                return res;
            }
        }
    }
}
