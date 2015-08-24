using System.Linq;
using SQLite;
using Training_Log.Models;
using System.Collections.ObjectModel;

namespace Training_Log.DataAccess
{
    public class ExerciseDAO
    {
        public void CreateExercise(string name)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                Exercise newExercise = new Exercise();
                newExercise.Name = name;
                dbConn.Insert(newExercise);
            }
        }

        public ObservableCollection<Exercise> GetExercises()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var lstExercises = dbConn.Query<Exercise>("select * from exercise order by name");
                ObservableCollection<Exercise> output = new ObservableCollection<Exercise>(lstExercises);
                return output;
            }
        }

        public Exercise GetExerciseById(int id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var exercise = dbConn.Query<Exercise>("select * from exercise where ExerciseID = ?", id).FirstOrDefault<Exercise>();
                return exercise;
            }
        }

        public void UpdateExercise(Exercise myExercise)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Update(myExercise);
            }
        }

        public void DeleteExercise(Exercise myExercise)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Delete(myExercise);
            }
        }
    }
}
