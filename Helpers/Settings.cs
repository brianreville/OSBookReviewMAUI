using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBookReviewMAUI.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);

        }

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(nameof(Token), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Token), value);
        }

        public static string WebUri
        {
            get => AppSettings.GetValueOrDefault(nameof(WebUri), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(WebUri), value);
        }

    }
}
