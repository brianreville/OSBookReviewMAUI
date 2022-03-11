using Microsoft.AppCenter.Crashes;
using OSBookReviewMAUI.Helpers;
using OSBookReviewMAUI.Models;

namespace OSBookReviewMAUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }


        public string Password { get; set; }
        public Login Userlogin { get; set; }
        private string DeviceGuid { get; set; }
        public string Username { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            Username = "";
            Password = "";
            Userlogin = new Login();
        }

        private async void OnLoginClicked(object obj)
        {
            try
            {

                // TODO: Enable Log In Process only requried to uncomment
                Userlogin = await VerifyLogin();

                if (!Userlogin.ValidUser)
                {
                    // username and password not matched
                    await App.Current.MainPage.DisplayAlert("Notification", "No Matching Records", "Okay");
                }
                //TODO: Add registering devices at db level
                //    else if (!Userlogin.DeviceRegistered)
                //    {
                //        // device not registerd
                //        await App.Current.MainPage.DisplayAlert("Notification", "Device Not Registered. Please submit device for registration to admin.\n" +
                //                                                    " Device Reg Number : " + DeviceGuid + " ", "Okay");
                //    }
                else
                {
                    App.CurrentLogin = Userlogin;
                    //set the Api Client Login in User
                    await ApiHelper.SetLogin(Userlogin);
                    //proceed to main page
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//AboutPage");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                await App.Current.MainPage.DisplayAlert("Notification", "Error in Connecting to the Server. Please Check Network Status", "Okay");
            }
        }

        private async Task<Login> VerifyLogin()
        {
            try
            {
                await RegisterGuid();
                Userlogin.UserName = Username;
                Userlogin.UserPword = Password;
                Userlogin.RegisteredDeviceCode = DeviceGuid;

                var result = await ApiHelper.Authenticate(Userlogin);

                return result;
            }
            catch (Exception ex)
            {
                Login res = new()
                {
                    UserName = ex.Message
                };
                return res;
            }
        }
        // sets the guid for the device
        private async Task RegisterGuid()
        {
            try
            {
                await Task.Run(() =>
                {
                    // guid for app installation
                    var deviceId = Preferences.Get("my_deviceId", string.Empty);
                    Preferences.Set("my_deviceId", deviceId);

                    if (string.IsNullOrWhiteSpace(deviceId))
                    {
                        deviceId = Guid.NewGuid().ToString();
                        Preferences.Set("my_deviceId", deviceId);
                    }

                    DeviceGuid = deviceId;
                });
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}
