using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;
using OSBookReviewMAUI.Services;
using OSBookReviewMAUI.Views;

namespace OSBookReviewMAUI;

public partial class App : Application
{
    public static Login CurrentLogin { get; set; } = new();
    public App()
    {
        InitializeComponent();

        // set the token web api
        Preferences.Set("WebUri", "https://bookreview2022.azurewebsites.net/");

        // register a singleton class for handling api class 
        var ApiService = new ApiHelper();
        DependencyService.RegisterSingleton(ApiService);

        // register the various viewmodel dependencies
        DependencyService.Register<AuthorDataClass>();

        // set the inital page
        // TODO: Login Page To Be Done and then switched from App Shell for secure login in
        // TODO: App Shell Tab and FlyOut Xaml to be added including pages
        MainPage = new LoginPage();
    }
}
