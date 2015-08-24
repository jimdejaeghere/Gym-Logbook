using System;

namespace Training_Log.Models
{
    public class LogEntry
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int LogEntryId { get; set; }
        public int ExerciseID { get; set; }
        public DateTime LogDate { get; set; }
        public string SetNo { get; set; }
        public string Weight { get; set; }
        public string Reps { get; set; }
        public string Comments { get; set; }

        public LogEntry()
        {

        }

        public LogEntry(int logEntryID, int exerciseID, DateTime myDate, string setNo, string weight, string reps, string comments)
        {
            LogEntryId = logEntryID;
            ExerciseID = exerciseID;
            LogDate = myDate;
            SetNo = setNo;
            Weight = weight;
            Reps = reps;
            Comments = comments;
        }

        public string FormattedLogDate
        {
            get
            {
                return LogDate.ToString("d");
            }
        }




    }
}
