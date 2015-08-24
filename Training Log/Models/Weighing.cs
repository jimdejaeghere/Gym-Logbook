using System;

namespace Training_Log.Models
{
    class Weighing
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int WeightEntryID { get; set; }
        public DateTime WeighingDate { get; set; }
        public decimal Weight { get; set; }
        public decimal FatPercentage { get; set; }
        public decimal DifferenceWeight { get; set; }
        public decimal DifferenceWeightLast { get; set; }
        public decimal DifferenceFat { get; set; }

        public string FormattedWeighingDate
        {
            get
            {
                return WeighingDate.ToString("d");
            }
        }

        public string WeightColor
        {
            get
            {
                if (DifferenceWeight > 0)
                {
                    return "Red";
                }
                else
                {
                    return "Green";
                }
            }
        }

        public string WeightColorLast
        {
            get
            {
                if (DifferenceWeightLast > 0)
                {
                    return "Red";
                }
                else
                {
                    return "Green";
                }
            }
        }
    }
}
