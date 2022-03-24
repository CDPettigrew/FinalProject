using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraChallenge
{
    public class CompanyRepository
    {
        protected readonly List<CompanyObject> _outingDirectory = new List<CompanyObject>();
        private decimal _golf;
        private decimal _bowling;
        private decimal _amusmentPark;
        private decimal _concert;
        private decimal _totalOutingCost;
        public bool CreateNewOuting(CompanyObject outing)
        {
            int startingCount = _outingDirectory.Count();
            if (!_outingDirectory.Contains(outing))
            {
                _outingDirectory.Add(outing);
                if (_outingDirectory.Count() > startingCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public List<CompanyObject> DisplayAllOutings()
        {
            return _outingDirectory;
        }
        public decimal ViewTotalCostByOuting()
        {
            foreach(CompanyObject outing in _outingDirectory)
            {
                if(outing.TypeOfEvent == EventType.Golf)
                {
                    decimal totalOutingsCostG = outing.CostPerEvent + _golf;
                    return totalOutingsCostG;
                }
                else if(outing.TypeOfEvent == EventType.Bowling)
                {
                    decimal totalOutingsCostB = outing.CostPerEvent + _bowling;
                    return totalOutingsCostB;
                }
                else if(outing.TypeOfEvent == EventType.AmusementPark)
                {
                    decimal totalOutingsCostA = outing.CostPerEvent + _amusmentPark;
                    return totalOutingsCostA;
                }
                else if(outing.TypeOfEvent == EventType.Concert)
                {
                    decimal totalOutingsCostC = outing.CostPerEvent + _concert;
                    return totalOutingsCostC;
                }
            }
            return 0;
        }
        public decimal TotalCostOfAllOutings()
        {
            foreach(CompanyObject outing in _outingDirectory)
            {
                _totalOutingCost += outing.CostPerEvent;
            }
            return _totalOutingCost;
        }
    }
}
