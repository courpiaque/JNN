using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNN.Models;
using Xamarin.Forms;

namespace JNN
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool _isClicked;

        public MainPage()
        {
            InitializeComponent();
        }

        private void RulesBtnClicked(object sender, EventArgs e)
        {
            if (_isClicked == false) App.Current.MainPage.Navigation.PushModalAsync(new RulesPage());
            _isClicked = true;
        }

        private void PlayBtnClicked(object sender, EventArgs e)
        {
            if (_isClicked == false) App.Current.MainPage.Navigation.PushModalAsync(new GamePage());
            _isClicked = true;
        }

        protected override void OnAppearing()
        {
            _isClicked = false;
            base.OnAppearing();
        }
    }
}
