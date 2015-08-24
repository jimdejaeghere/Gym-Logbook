using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Log.Models
{
    class Quote
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int QuoteID { get; set; }
        public string QuoteText { get; set; }

        public Quote()
        {

        }
    }
}
