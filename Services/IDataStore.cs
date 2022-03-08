using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;

namespace OSBookReviewMAUI.Services
{
    public interface IDataStore<T>
    {
        IApiHelper ApiHelper { get; }

        Task<IEnumerable<T>> GetListAsync();
    }
}