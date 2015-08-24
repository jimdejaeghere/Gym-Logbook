using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Training_Log.Views;
using System;
using Training_Log.DataAccess;
using Training_Log.Models;
using System.Collections.Generic;

namespace Training_Log
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetQuote();
        }

        private void SetQuote()
        {
            QuoteDAO _dao = new QuoteDAO();
            List<Quote> lstQuotes = new List<Quote>();
            lstQuotes = _dao.GetQuotes();
            Random rnd = new Random();
            int random = rnd.Next(0, lstQuotes.Count);

            txtQuote.Text = lstQuotes[random].QuoteText;
           
        }

        private void btnWeight_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Weight));
        }

        private void btnExercise_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Exercises));
        }

        private void btnQuotes_Click(object sender, RoutedEventArgs e)
        {
            SetQuote();
        }
    }
}
