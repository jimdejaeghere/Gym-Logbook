using System;
using Training_Log.DataAccess;
using Training_Log.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Training_Log.Views
{

    public sealed partial class WeightDetail : Page
    {
        public WeightDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Weighing myWeighing = new Weighing();

            myWeighing.WeighingDate = pckDate.Date.Date;

            if (!String.IsNullOrEmpty(txtWeight.Text))
            {
                myWeighing.Weight = Convert.ToDecimal(txtWeight.Text.Replace(',','.'));

                if (!String.IsNullOrEmpty(txtFat.Text))
                {
                    myWeighing.FatPercentage = Convert.ToDecimal(txtFat.Text.Replace(',','.'));
                }

                WeightDAO _dao = new WeightDAO();
                _dao.CreateWeighingEntry(myWeighing);

                Frame.GoBack();
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("No weight entered.");
                await msgbox.ShowAsync();
            }
        }

    }
}
