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
    public class AuthorDataClass : IDataStore<Author>
    {
        private List<Author> _data;
        public IApiHelper ApiHelper => DependencyService.Get<ApiHelper>();
        public AuthorDataClass()
        {
            _data = new List<Author>();
        }

        // for getting the list of all residents in a venue
        // TODO: TIDY UP RETURN TYPE TO SINGLE LINE ONCE DEBUGGING COMPLETED
        public async Task<IEnumerable<Author>> GetListAsync()
        {
            _data = await GetAuthors();
            return _data;
        }

        // get the list of auhtors with the criteria of a name serach
        // in the event of error return an empty list
        private async Task<List<Author>> GetAuthorsByName()
        {
            try
            {
                //TODO Add Weblink
                string weblink = "";

                var response = await ApiHelper.GetList<Author>(weblink);

                return response;

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);

                List<Author> res = new();

                return res;
            }
        }
        // get the list of Top 50 Authors in the event of error return an empty list
        private async Task<List<Author>> GetAuthors()
        {
            try
            {
                //TODO Add Weblink
                string weblink = "api/book/getauthors";
                var response = await ApiHelper.GetList<Author>(weblink);

                return response;

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);

                List<Author> res = new();

                return res;
            }
        }
    }
}
