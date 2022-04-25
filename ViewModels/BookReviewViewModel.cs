using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Models;
using OSBookReviewMAUI.Services;

namespace OSBookReviewMAUI.ViewModels
{
    [QueryProperty(nameof(BDID), nameof(BDID))]
    public partial class BookReviewViewModel : ObservableObject
    {

        public IDataStore<BookReview> BookDataStore => DependencyService.Get<IDataStore<BookReview>>();
        public List<int> Ratings { get; set; }

        public BookReviewViewModel()
        {
            Book = new();
            Ratings = new(Enumerable.Range(1, 10).ToList());
        }

        public async void OnAppearing()
        {
            await LoadItem();
        }

        [ObservableProperty]
        BookReview book;

        [ObservableProperty]
        int bDID;

        [ObservableProperty]
        int rating;

        [ICommand]
        private async Task LoadItem()
        {
            try
            {
                Book = await BookDataStore.GetSingle(BDID);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        [ICommand]
        private async Task AddReview()
        {
            try
            {
                Book.Userid = App.CurrentLogin.Userid;
                Book.Rating = Rating;

                bool res = await BookDataStore.AddRecord(Book);
                if (res)
                {
                    await App.Current.MainPage.DisplayAlert("Review Notification", "Book Review Successfully Added", "Okay");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Review Notification", "Book Review UnSuccessfully Added", "Okay");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex); await App.Current.MainPage.DisplayAlert("Error Notification", " Error Adding Book Review", "Okay");
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
