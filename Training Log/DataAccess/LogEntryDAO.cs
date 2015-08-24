using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Training_Log.Models;

namespace Training_Log.DataAccess
{
    public class LogEntryDAO
    {
        public void CreateLogEntry(LogEntry myEntrie)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Insert(myEntrie);
            }
        }

        public ObservableCollection<LogEntry> GetLogEntries(int exerciseID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var lstLogEntries = dbConn.Query<LogEntry>("select * from logentry where ExerciseID = ? order by LogDate DESC, SetNo DESC", exerciseID);
                ObservableCollection<LogEntry> output = new ObservableCollection<LogEntry>(lstLogEntries);
                return output;
            }
        }

        public List<LogEntry> GetLogEntriesByDate(int exerciseID, DateTime date)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var lstLogEntries = dbConn.Query<LogEntry>("select * from logentry where ExerciseID = ? and LogDate = ? order by SetNo", exerciseID, date);
                return lstLogEntries;
            }
        }

        public void DeleteLogEntry(LogEntry selectedLogEntry)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Delete(selectedLogEntry);
            }
        }

        internal int GetLastSetNo(Exercise selectedExercise, DateTime date)
        {
            int setNo = 0;

            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var output = dbConn.Query<LogEntry>("select * from logentry where ExerciseID = ? and LogDate = ?", selectedExercise.ExerciseID, date);
                setNo = output.Count();
            }

            return setNo;
        }

        public void UpdateLogEntry(LogEntry selectedLogEntry)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.Update(selectedLogEntry);
            }
        }

        public void DeleteLogEntriesByExerciseId(int id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                ObservableCollection<LogEntry> lstLogEntries = GetLogEntries(id);

                foreach (var item in lstLogEntries)
                {
                    dbConn.Delete(item);
                }
            }
        }
    }
}
