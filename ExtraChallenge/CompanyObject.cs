using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{ 
    public enum EventType { Golf, Bowling, AmusementPark, Concert};
    public class CompanyObject
    {
        public EventType TypeOfEvent { get; set; }
        public int NumOfPeople { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostPerEvent 
        {
            get
            {
                decimal totalCost = NumOfPeople * CostPerPerson;
                return totalCost;
            }
        }
        public CompanyObject() { }
        public CompanyObject(int numOfPeople, DateTime eventDate, decimal costPerPerson, EventType typeOfEvent)
        {
            NumOfPeople = numOfPeople;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
            TypeOfEvent = typeOfEvent;
        }
    }
}
