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
        //C
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
        //R
        public List<CompanyObject> DisplayAllOutings()
        {
            return _outingDirectory;
        }
        public decimal ViewTotalGolfCost()
        {
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Golf)
                {
                    _golf += outing.CostPerEvent; 
                }
            }
            return _golf;
        }
        public decimal ViewTotalBowlingCost()
        {
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Bowling)
                {
                    _bowling += outing.CostPerEvent;
                }
            }
            return _bowling;
        }
        public decimal ViewTotalAmusementParkCost()
        {
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.AmusementPark)
                {
                    _amusmentPark += outing.CostPerEvent;
                }
            }
            return _amusmentPark;
        }
        public decimal ViewTotalConcertCost()
        {
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Concert)
                {
                    _concert += outing.CostPerEvent;
                }
            }
            return _concert;
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
