using OSBookReviewMAUI.ViewModels;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorList : ContentPage
    {
        AuthorListViewModel _viewModel;

        public AuthorList()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = new AuthorListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}