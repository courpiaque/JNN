using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JNN.Models;
using JNN.ViewModels;
using Xamarin.Forms;

namespace JNN
{
    public partial class GamePage : ContentPage
    {
        DirectoryInfo d;
        bool _isClicked;
        bool _saving;

        public GamePage()
        {
            InitializeComponent();

            BindingContext = new GamePageModel();

            SetValue(NavigationPage.HasNavigationBarProperty, false);

            d = new DirectoryInfo(Pytania.dataDir);

            if (d.Exists)
            {
                ViewModel.LoadQuestions();
                lbl.Text = "Stuknij w ekran, aby kontynuować";
            }
        }

        GamePageModel ViewModel
        {
            get => (BindingContext as GamePageModel);
            set => BindingContext = value;
        }

        private void BackBtnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void NextBtnClicked(object sender, EventArgs e)
        {
            if (_isClicked) return;
            _isClicked = true;
            if (BackBtn.IsVisible) HideBtn();
            if (!_saving) _saving = true;
            lbl.Text = ViewModel.GetQuest();

            await Task.Delay(500);
            _isClicked = false;
        }

        private void SetBtnClicked(object sender, EventArgs e)
        {
            if (BackBtn.IsVisible == true)
            {
                HideBtn();
                return;
            }

            setImg.Source = ImageSource.FromFile("wideSet.png");
            setImg.Margin = new Thickness(10, 10, 10, 0);
            menuFrame.WidthRequest = 100;
            menuFrame.HeightRequest = 130;
            BackBtn.IsVisible = true;
            box.IsVisible = true;
            restBtn.IsVisible = true;
        }

        private void ElsewhereClicked(object sender, EventArgs e)
        {
            if (BackBtn.IsVisible) HideBtn();
            if (alert.IsVisible) alert.IsVisible = false;
            if (mask.IsVisible) mask.IsVisible = false;
        }

        private void AlertBtnClicked(object sender, EventArgs e)
        {
            if (!alert.IsVisible) alert.IsVisible = true;
            if (!mask.IsVisible) mask.IsVisible = true;
        }

        private void HideBtn()
        {   
            setImg.Source = ImageSource.FromFile("set.png");
            setImg.Margin = new Thickness(5,6,5,5);

            menuFrame.WidthRequest = 50;
            menuFrame.HeightRequest = 50;

            box.IsVisible = false;
            BackBtn.IsVisible = false;
            restBtn.IsVisible = false;

        }

        private async void RestartBtnClicked(object sender, EventArgs e)
        {
            if (Directory.Exists(Pytania.dataDir))
            {
                File.Delete(Pytania.dataDir + "/pytania.txt");
                Directory.Delete(Pytania.dataDir);
            }

            _saving = false;

            if (_isClicked == false)
            {
                App.Current.MainPage.Navigation.PopModalAsync();
                App.Current.MainPage.Navigation.PushModalAsync(new GamePage());
            }

            _isClicked = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_saving) ViewModel.SaveQuestions();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _isClicked = false;
        }
    }
}
