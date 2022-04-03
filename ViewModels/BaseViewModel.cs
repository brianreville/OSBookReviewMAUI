using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;
using OSBookReviewMAUI.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OSBookReviewMAUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // register Api singleton dependency
        public IApiHelper ApiHelper => DependencyService.Get<ApiHelper>();
        // register dependency injection in base view model
        public IDataStore<Author> AuthorDataStore => DependencyService.Get<IDataStore<Author>>();
        public IDataStore<BookReview> BookDataStore => DependencyService.Get<IDataStore<BookReview>>();


        bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
