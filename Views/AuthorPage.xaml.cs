using OSBookReviewMAUI.ViewModels;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage : ContentPage
    {
        private readonly AuthorViewModel _viewModel;

        public AuthorPage()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = new AuthorViewModel();
        }

    }
}