using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Models;
using OSBookReviewMAUI.Services;
using OSBookReviewMAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OSBookReviewMAUI.ViewModels
{

    public partial class AuthorViewModel : ObservableObject
    {

        private int overallRating;

        public IDataStore<Author> AuthorDataStore => DependencyService.Get<IDataStore<Author>>();
        public AuthorViewModel()
        {
            Authors = new();
        }

        [ObservableProperty]
        string authorName;

        [ObservableProperty]
        string publisherName;

        [ObservableProperty]
        ObservableCollection<Author> authors;

        [ObservableProperty]
        Author author;


        public int OverallRating
        {
            get => overallRating;
            set => SetProperty(ref overallRating, value);
        }

        [ICommand]
        async Task LoadItemsCommand()
        {
            try
            {
                Authors.Clear();
                var authors = await AuthorDataStore.GetListAsync();
                foreach (Author a in authors)
                {
                    Authors.Add(a);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        [ICommand]
        private async Task Search(string name)
        {

            try
            {
                Authors.Clear();
                var authors = await AuthorDataStore.GetListAsync(name);
                foreach (Author a in authors)
                {
                    Authors.Add(a);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        [ICommand]
        async void OnAuthorSelected(Author author)
        {
            if (author == null)
                return;
            else
            {
                // This will push the AuthorDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(AuthorBooks)}?{nameof(AuthorBookViewModel.AID)}={author.AID}");
            }
        }
    }
}
