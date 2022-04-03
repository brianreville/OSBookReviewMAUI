using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Services;
using System.Collections.ObjectModel;

namespace OSBookReviewMAUI.ViewModels
{
    [QueryProperty(nameof(AID), nameof(AID))]
    public partial class AuthorBookViewModel : ObservableObject
    {

        public IDataStore<Models.BookReview> BookDataStore => DependencyService.Get<IDataStore<Models.BookReview>>();

        public AuthorBookViewModel()
        {
            Books = new();
        }

        [ObservableProperty]
        string authorName;

        [ObservableProperty]
        string publisherName;

        [ObservableProperty]
        int aID;

        [ObservableProperty]
        ObservableCollection<Models.BookReview> books;

        [ICommand]
        async Task LoadItemsCommand()
        {
            try
            {
                Books.Clear();
                var sbooks = await BookDataStore.GetListAsync(AID);
                foreach (Models.BookReview b in sbooks)
                {
                    Books.Add(b);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
        [ICommand]
        public async void BookTapped(Models.BookReview book)
        {
            if (book == null)
                return;
            else
            {
                // This will push the AuthorDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(Views.BookReview)}?{nameof(BookReviewViewModel.BDID)}={book.BDID}");
            }
        }
        public async void OnAppearing()
        {
            await LoadItemsCommand();
        }

    }
}
