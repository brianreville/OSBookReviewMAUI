using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;

namespace OSBookReviewMAUI.Services
{
    public class BookDataClass : IDataStore<BookReview>
    {
        private Task<IEnumerable<BookReview>> result;

        public IApiHelper ApiHelper => DependencyService.Get<ApiHelper>();
        public BookDataClass()
        {

        }

        public Task<IEnumerable<BookReview>> GetListAsync()
        {
            return result;
        }

        public async Task<IEnumerable<BookReview>> GetListAsync(int AID)
        {
            return await GetBooks(AID);
        }

        public async Task<IEnumerable<BookReview>> GetListAsync(string authorname)
        {
            return await GetBooks(authorname);
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
