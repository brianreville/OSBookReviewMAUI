using OSBookReviewMAUI.Helpers;

namespace OSBookReviewMAUI.Services
{
    public interface IDataStore<T>
    {
        IApiHelper ApiHelper { get; }

        Task<bool> AddRecord(T item);
        Task<bool> UpdateRecord(T item);
        Task<IEnumerable<T>> GetListAsync();
        Task<IEnumerable<T>> GetListAsync(int AID);
        Task<IEnumerable<T>> GetListAsync(string authorname);
        Task<T> GetSingle(int ID);
    }
}