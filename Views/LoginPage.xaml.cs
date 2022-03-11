using OSBookReviewMAUI.ViewModels;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LoginViewModel();
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Password = e.NewTextValue;
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Username = e.NewTextValue;
        }
    }
}