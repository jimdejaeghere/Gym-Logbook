using Training_Log.DataAccess;
using Training_Log.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Training_Log.Views
{
    public sealed partial class ExerciseDetail : Page
    {
        Exercise selectedExercise;

        public ExerciseDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            selectedExercise = (Exercise)e.Parameter;

            if (selectedExercise == null)
            {
                lblTitle.Text = "New Exercise";
            }
            else
            {
                lblTitle.Text = "Edit Exercise";
                txtName.Text = selectedExercise.Name;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            ExerciseDAO _dao = new ExerciseDAO();

            if (selectedExercise == null)
            {
                _dao.CreateExercise(txtName.Text);
                Frame.GoBack();
            }
            else
            {
                selectedExercise.Name = txtName.Text;
                _dao.UpdateExercise(selectedExercise);
                Frame.GoBack();
            }
        }
    }
}
