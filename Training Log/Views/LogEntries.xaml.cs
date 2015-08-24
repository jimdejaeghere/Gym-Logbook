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
    public sealed partial class LogEntries : Page
    {
        private Exercise selectedExercise = new Exercise();
        private ObservableCollection<LogEntry> lstLogEntries = new ObservableCollection<LogEntry>();
        private LogEntryDAO _dao = new LogEntryDAO();

        public LogEntries()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            selectedExercise = (Exercise)e.Parameter;
            txtName.Text = selectedExercise.Name;
            lstLogEntries = _dao.GetLogEntries(selectedExercise.ExerciseID);
            LogEntrieList.ItemsSource = lstLogEntries;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetDetail), selectedExercise);
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            LogEntry selectedLogEntry = (e.OriginalSource as FrameworkElement).DataContext as LogEntry;
            PayLoad myPayLoad = new PayLoad();
            myPayLoad.Status = "Edit";
            myPayLoad.Entry = selectedLogEntry;
            Frame.Navigate(typeof(SetDetail), myPayLoad);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            LogEntryService myLogEntryService = new LogEntryService();
            LogEntry selectedLogEntry = (e.OriginalSource as FrameworkElement).DataContext as LogEntry;
            
            _dao.DeleteLogEntry(selectedLogEntry);
            lstLogEntries.Remove(selectedLogEntry);

            myLogEntryService.RenumberLogEntries(selectedLogEntry, selectedLogEntry.LogDate);

            lstLogEntries = _dao.GetLogEntries(selectedLogEntry.ExerciseID);
            LogEntrieList.ItemsSource = lstLogEntries;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LogEntry selectedLogEntry = (e.OriginalSource as FrameworkElement).DataContext as LogEntry;
            PayLoad myPayLoad = new PayLoad();
            myPayLoad.Status = "View";
            myPayLoad.Entry = selectedLogEntry;
            Frame.Navigate(typeof(SetDetail), myPayLoad);
        }
    }
}
