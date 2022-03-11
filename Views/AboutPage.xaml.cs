using OSBookReviewMAUI.ViewModels;

namespace OSBookReviewMAUI.Views
{
    public partial class AboutPage : ContentPage
    {
        readonly AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AboutViewModel();
        }

    }
}