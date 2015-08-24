using System;
using System.Collections.Generic;
using System.Linq;
using Training_Log.DataAccess;
using Training_Log.Models;

namespace Training_Log.Services
{
    public class LogEntryService
    {
        public void RenumberLogEntries(LogEntry logEntry, DateTime logDate)
        {
            LogEntryDAO _dao = new LogEntryDAO();
            List<LogEntry> logEntriesToRenumber = _dao.GetLogEntriesByDate(logEntry.ExerciseID, logDate);

            for (int i = logEntriesToRenumber.Count(); i > 0; i--)
            {
                logEntriesToRenumber[i - 1].SetNo = i.ToString();
                _dao.UpdateLogEntry(logEntriesToRenumber[i - 1]);
            }
        }
    }
}
