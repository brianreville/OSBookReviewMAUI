using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Models;
using OSBookReviewMAUI.Services;
using System.Collections.ObjectModel;

namespace OSBookReviewMAUI.ViewModels
{

    public partial class AuthorViewModel : ObservableObject
    {

        private int overallRating;

        public IDataStore<Author> AuthorDataStore => DependencyService.Get<IDataStore<Author>>();
        public AuthorViewModel()
        {
            Authors = new();
            Author = new();
        }

        [ObservableProperty]
        string authorName;

        [ObservableProperty]
        string publisherName;

        [ObservableProperty]
        Author author;

        [ObservableProperty]
        ObservableCollection<Author> authors;


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

        public async void OnAppearing()
        {
            await LoadItemsCommand();
        }
    }
}
