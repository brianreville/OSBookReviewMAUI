using OSBookReviewMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBookReviewMAUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register routes for the shell
            Routing.RegisterRoute(nameof(AuthorList), typeof(AuthorList));

        }
    }
}