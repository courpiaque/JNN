using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JNN
{
    public partial class RulesPage : ContentPage
    {
        bool _isClicked;

        public RulesPage()
        {
            InitializeComponent();
        }

        private void PlayBtnClicked(object sender, EventArgs e)
        {

            if (_isClicked == false)
            {
                App.Current.MainPage.Navigation.PopModalAsync();
                App.Current.MainPage.Navigation.PushModalAsync(new GamePage());
            } 
            _isClicked = true;
        }

        protected override void OnAppearing()
        {
            _isClicked = false;
            base.OnAppearing();
        }
    }
}
