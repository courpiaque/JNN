using System;
using System.IO;
using System.Threading.Tasks;
using JNN.Models;
using Xamarin.Forms;

namespace JNN.ViewModels
{
    public class GamePageModel
    {
        Pytania pytania = new Pytania();
        Random random = new Random();
        int x = 0;

        private static readonly string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rate");
        DirectoryInfo d = new DirectoryInfo(dir);

        public string GetQuest()
        {
            x++;
            if (x == 50) RateUs();
            return pytania.GetRandomQuestion();
        }

        public void SaveQuestions()
        {
            pytania.SaveQuestionsToTxt();
        }

        public void LoadQuestions()
        {
            pytania.LoadQuestionsFromTxt();
        }

        public async Task RateUs()
        {
            var action = await App.Current.MainPage.DisplayAlert("Jedną chwilkę!", "Nie chcemy przeszkadzać w rozmowie, ale jesteśmy ciekawi, czy podoba Wam się nasza aplikacja?", "Oceń!", "Nie, dziękuję");
            if (action)
            {
                Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=pl.billog_studio.janigdynie_graimprezowa"));
            }
        }
    }
}
