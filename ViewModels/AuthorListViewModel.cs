using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Models;
using System.Collections.ObjectModel;

namespace OSBookReviewMAUI.ViewModels
{
    public class AuthorListViewModel : BaseViewModel
    {
        private Author _selectedItem;

        public ObservableCollection<Author> Authors { get; }
        public Command LoadAuthorsCommand { get; }
        public Command<Author> AuthorTapped { get; }

        public AuthorListViewModel()
        {
            Authors = new ObservableCollection<Author>();
            LoadAuthorsCommand = new Command(async () => await ExecuteLoadAuthorsCommand());

            AuthorTapped = new Command<Author>(OnAuthorSelected);
        }

        private async Task ExecuteLoadAuthorsCommand()
        {
            IsBusy = true;

            try
            {
                Authors.Clear();
                var authors = await AuthorDataStore.GetListAsync();
                foreach (var Author in authors)
                {
                    Authors.Add(Author);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Author SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnAuthorSelected(value);
            }
        }

        private async void OnAuthorSelected(Author author)
        {
            if (author == null)
                return;

            //TODO: Create Author Detail Page
            // This will push the AuthorDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(AuthorDetailPage)}?{nameof(AuthorDetailViewModel.AuthorID)}={author.AID}");
        }
    }
}

