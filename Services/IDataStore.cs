using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;

namespace OSBookReviewMAUI.Services
{
    public interface IDataStore<T>
    {
        IApiHelper ApiHelper { get; }

        Task<IEnumerable<T>> GetListAsync();
        Task<IEnumerable<T>> GetListAsync(int AID);
        Task<IEnumerable<T>> GetListAsync(string authorname);
    }
}