using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Services;

namespace OSBookReviewMAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // set the token web api
        //TODO : Add WebUri
        Settings.WebUri = "";
        // register a singleton class for handling api class 
        ApiHelper ApiService = new();
        DependencyService.RegisterSingleton(ApiService);

        // register the various viewmodel dependencies
        DependencyService.Register<AuthorDataClass>();

        // set the inital page
        // TODO: Login Page To Be Done and then switched from App Shell for secure login in
        // TODO: App Shell Tab and FlyOut Xaml to be added including pages
        MainPage = new AppShell();
    }
}
