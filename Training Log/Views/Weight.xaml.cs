using System.Collections.ObjectModel;
using Training_Log.DataAccess;
using Training_Log.Models;
using Training_Log.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Training_Log.Views
{
    public sealed partial class Weight : Page
    {
        private ObservableCollection<Weighing> lstWeighing = new ObservableCollection<Weighing>();
        private WeightDAO _dao = new WeightDAO();
        private WeighingService _service = new WeighingService();

        public Weight()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            lstWeighing = _dao.GetWeighingEntries();
            _service.CalculateDifference(ref lstWeighing);
            WeightLogEntryList.ItemsSource = lstWeighing;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WeightDetail));
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Weighing selectedWeighing = (e.OriginalSource as FrameworkElement).DataContext as Weighing;

            _dao.DeleteWeighingEntry(selectedWeighing);
            lstWeighing.Remove(selectedWeighing);
            _service.CalculateDifference(ref lstWeighing);
        }
    }
}
