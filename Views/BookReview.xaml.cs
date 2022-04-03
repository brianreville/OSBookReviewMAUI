using OSBookReviewMAUI.ViewModels;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookReview : ContentPage
    {
        private readonly BookReviewViewModel _viewModel;

        public BookReview()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = new BookReviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}