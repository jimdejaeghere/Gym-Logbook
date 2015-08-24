using System;
using Training_Log.DataAccess;
using Training_Log.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Training_Log.Views
{

    public sealed partial class SetDetail : Page
    {
        private Exercise selectedExercise = new Exercise();
        private LogEntry selectedLogEntry = null;
        private ExerciseDAO _exerciseDao = new ExerciseDAO();
        private LogEntryDAO _logEntryDao = new LogEntryDAO();

        public SetDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.GetType() == typeof(Exercise))
            {
                selectedExercise = (Exercise)e.Parameter;
                int lastSetNo = _logEntryDao.GetLastSetNo(selectedExercise, pckDate.Date.Date);
                int newSetNo = ++lastSetNo;
                txtSet.Text = newSetNo.ToString();
            }
            else if (e.Parameter.GetType() == typeof(PayLoad))
            {
                PayLoad myPayload = new PayLoad();
                myPayload = (PayLoad)e.Parameter;

                selectedLogEntry = myPayload.Entry;
                selectedExercise = _exerciseDao.GetExerciseById(selectedLogEntry.ExerciseID);

                pckDate.Date = selectedLogEntry.LogDate;
                txtSet.Text = selectedLogEntry.SetNo;
                txtReps.Text =  selectedLogEntry.Reps;
                txtWeight.Text = selectedLogEntry.Weight;
                txtComments.Text = selectedLogEntry.Comments;

                if (myPayload.Status == "View")
                {
                    SetViewReadOnly();
                } else
                {
                    SetViewEdit();
                }
            }

            lblTitle.Text = selectedExercise.Name;
        }

        private void SetViewEdit()
        {
            pckDate.IsEnabled = true;
            txtReps.IsEnabled = true;
            txtWeight.IsEnabled = true;
            txtComments.IsEnabled = true;
            cmdBar.Visibility = Visibility.Visible;
        }

        private void SetViewReadOnly()
        {
            pckDate.IsEnabled = false;
            txtReps.IsEnabled = false;
            txtWeight.IsEnabled = false;
            txtComments.IsEnabled = false;
            cmdBar.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

            if (txtReps.Text == "")
            {
                MessageDialog msgbox = new MessageDialog("No reps entered.");
                await msgbox.ShowAsync();
            }
            else if (selectedLogEntry == null)
            {
                selectedLogEntry = new LogEntry();

                selectedLogEntry = UpdateLogEntry();

                _logEntryDao.CreateLogEntry(selectedLogEntry);                            
            }
            else
            {
                selectedLogEntry = UpdateLogEntry();
                _logEntryDao.UpdateLogEntry(selectedLogEntry);
            }

            Frame.GoBack();
        }

        private LogEntry UpdateLogEntry()
        {
            selectedLogEntry.ExerciseID = selectedExercise.ExerciseID;
            selectedLogEntry.LogDate = pckDate.Date.Date;
            selectedLogEntry.SetNo = txtSet.Text;
            selectedLogEntry.Reps = txtReps.Text;
            selectedLogEntry.Weight = txtWeight.Text;
            selectedLogEntry.Comments = txtComments.Text;

            return selectedLogEntry;
        }

        private void pckDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            int lastSetNo = _logEntryDao.GetLastSetNo(selectedExercise, pckDate.Date.Date);
            int newSetNo = ++lastSetNo;
            txtSet.Text = newSetNo.ToString();
        }
    }
}
