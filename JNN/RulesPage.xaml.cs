using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JNN
{
    public partial class RulesPage : ContentPage
    {
        public RulesPage()
        {
            InitializeComponent();
        }

        private void PlayBtnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
            App.Current.MainPage.Navigation.PushModalAsync(new GamePage());
        }
    }
}
