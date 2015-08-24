namespace Training_Log.Models
{
    public class Exercise
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ExerciseID { get; set; }
        public string Name { get; set; }

        public Exercise()
        {

        }

        public Exercise(int id, string name)
        {
            ExerciseID = id;
            Name = name;
        }
    }
}
