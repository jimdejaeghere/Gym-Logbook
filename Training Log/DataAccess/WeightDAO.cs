using SQLite;
using System.Collections.ObjectModel;
using Training_Log.Models;

namespace Training_Log.DataAccess
{
    class WeightDAO
    {
        public void CreateWeighingEntry(Weighing myWeighing)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Insert(myWeighing);
            }
        }

        public ObservableCollection<Weighing> GetWeighingEntries()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var lstWeighingEntries = dbConn.Query<Weighing>("select * from Weighing order by WeighingDate DESC");
                ObservableCollection<Weighing> output = new ObservableCollection<Weighing>(lstWeighingEntries);
                return output;
            }
        }

        public void DeleteWeighingEntry(Weighing selectedWeighing)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Delete(selectedWeighing);
            }
        }
    }
}
