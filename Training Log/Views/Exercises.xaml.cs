using Training_Log.DataAccess;
using Training_Log.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace Training_Log.Views
{
    public sealed partial class Exercises : Page
    {
        private ObservableCollection<Exercise> lstExercises = new ObservableCollection<Exercise>();
        private ExerciseDAO _exerciseDao = new ExerciseDAO();

        public Exercises()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            lstExercises = _exerciseDao.GetExercises();
            ExercisesList.ItemsSource = lstExercises;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExerciseDetail));
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Exercise selectedExercise = (e.OriginalSource as FrameworkElement).DataContext as Exercise;
            Frame.Navigate(typeof(ExerciseDetail), selectedExercise);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            LogEntryDAO _logEntryDao = new LogEntryDAO();
            Exercise selectedExercise = (e.OriginalSource as FrameworkElement).DataContext as Exercise;
            _logEntryDao.DeleteLogEntriesByExerciseId(selectedExercise.ExerciseID);
            _exerciseDao.DeleteExercise(selectedExercise);
            lstExercises.Remove(selectedExercise);
        }
        
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Exercise selectedExercise = (e.OriginalSource as FrameworkElement).DataContext as Exercise;
            Frame.Navigate(typeof(LogEntries), selectedExercise);
        }
    }
}
