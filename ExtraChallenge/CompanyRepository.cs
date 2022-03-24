using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class CompanyRepository
    {
        protected readonly List<CompanyObject> _outingDirectory = new List<CompanyObject>();
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
            decimal totalCost = 0m;
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Golf)
                {
                    totalCost += outing.CostPerEvent; 
                }
            }
            return totalCost;
        }
        public decimal ViewTotalBowlingCost()
        {
            decimal totalCost = 0m;
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Bowling)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            return totalCost;
        }
        public decimal ViewTotalAmusementParkCost()
        {
            decimal totalCost = 0m;
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.AmusementPark)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            return totalCost;
        }
        public decimal ViewTotalConcertCost()
        {
            decimal totalCost = 0m;
            foreach (CompanyObject outing in _outingDirectory)
            {
                if (outing.TypeOfEvent == EventType.Concert)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            return totalCost;
        }
        public decimal TotalCostOfAllOutings()
        {
            decimal totalCost = 0m;
            foreach (CompanyObject outing in _outingDirectory)
            {
                totalCost += outing.CostPerEvent;
            }
            return totalCost;
        }
    }
}
