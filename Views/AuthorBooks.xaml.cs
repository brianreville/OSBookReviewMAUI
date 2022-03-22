using OSBookReviewMAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorBooks : ContentPage
    {
        private readonly AuthorBookViewModel _viewModel;

        public AuthorBooks()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = new AuthorBookViewModel();
        }
    }
}