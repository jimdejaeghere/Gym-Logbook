using System.Collections.ObjectModel;
using System.Linq;
using Training_Log.Models;

namespace Training_Log.Services
{
    class WeighingService
    {
        public void CalculateDifference(ref ObservableCollection<Weighing> myWeighings)
        {

            for (int i = 0; i < (myWeighings.Count() - 1); i++)
            {
                myWeighings[i].DifferenceWeight = myWeighings[i].Weight - myWeighings[myWeighings.Count() - 1].Weight;
                myWeighings[i].DifferenceWeightLast = myWeighings[i].Weight - myWeighings[i + 1].Weight;
                myWeighings[i].DifferenceFat = myWeighings[i].FatPercentage - myWeighings[myWeighings.Count() - 1].FatPercentage;
            }
        }
    }
}
