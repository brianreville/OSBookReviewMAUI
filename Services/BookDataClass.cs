using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await GetBooks(AID); ;
        }

        private async Task<List<BookReview>> GetBooks(int AID)
        {
            try
            {
                string weblink = "api/book/GetAuthorByName?name=";

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
