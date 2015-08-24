using SQLite;
using System.Collections.Generic;
using Training_Log.Models;

namespace Training_Log.DataAccess
{
    class QuoteDAO
    {
        public List<Quote> GetQuotes()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var lstQuotes = dbConn.Query<Quote>("select * from Quote");
                return lstQuotes;
            }
        }
    }
}
