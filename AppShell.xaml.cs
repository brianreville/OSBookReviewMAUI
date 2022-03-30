using OSBookReviewMAUI.Views;

namespace OSBookReviewMAUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register routes for the shell
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(AuthorPage), typeof(AuthorPage));
            Routing.RegisterRoute(nameof(AuthorBooks), typeof(AuthorBooks));
            Routing.RegisterRoute(nameof(AuthorList), typeof(AuthorList));
        }

        // for login form
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}