using OSBookReviewMAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBookReviewMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorList : ContentPage
    {
        private readonly AuthorListViewModel _viewModel;

        public AuthorList()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = new AuthorListViewModel();
        }
    }
}