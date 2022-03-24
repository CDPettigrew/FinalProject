using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings;

namespace Outings_Tests
{
    [TestClass]
    public class OutingTests
    {
        private CompanyRepository _outingDirectory;
        private CompanyObject _companyObject;
        [TestInitialize]
        public void Arrange()
        {
            _outingDirectory = new CompanyRepository();
            DateTime outingDate1 = new DateTime(2022, 06, 25, 00, 00, 00);
            CompanyObject outing1 = new CompanyObject(20, outingDate1, 100, EventType.AmusementPark);
            CompanyObject outing2 = new CompanyObject(25, outingDate1, 100, EventType.Bowling);
            CompanyObject outing3 = new CompanyObject(15, outingDate1, 100, EventType.Concert);
            CompanyObject outing4 = new CompanyObject(10, outingDate1, 100, EventType.Golf);
            _outingDirectory.CreateNewOuting(outing1);
            _outingDirectory.CreateNewOuting(outing2);
            _outingDirectory.CreateNewOuting(outing3);
            _outingDirectory.CreateNewOuting(outing4);
        }
        [TestMethod]
        public void CreateNewOuting_ShouldReturnCorrectBool()
        {
            _outingDirectory = new CompanyRepository();
            _companyObject = new CompanyObject();
            bool result = _outingDirectory.CreateNewOuting(_companyObject);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DisplayAllOutings_ShouldReturnFullList()
        {
            DateTime outingDate1 = new DateTime(2022, 06, 25, 00, 00, 00);
            CompanyObject newOuting = new CompanyObject(30, outingDate1, 50, EventType.Golf);
            _outingDirectory.CreateNewOuting(newOuting);
            List<CompanyObject> outing = _outingDirectory.DisplayAllOutings();
            bool result = outing.Contains(newOuting);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ViewTotalConcertCost_ShouldReturnEqual()
        {
            List<CompanyObject> listOfOutings = _outingDirectory.DisplayAllOutings();
            decimal totalCost = 0m;
            foreach (CompanyObject outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.Concert)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            Assert.AreEqual(totalCost, 1500m);
        }
        [TestMethod]
        public void ViewTotalGolfCost_ShouldReturnEqual()
        {
            List<CompanyObject> listOfOutings = _outingDirectory.DisplayAllOutings();
            decimal totalCost = 0m;
            foreach (CompanyObject outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.Golf)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            Assert.AreEqual(totalCost, 1000m);
        }
        [TestMethod]
        public void ViewTotalBowlingCost_ShouldReturnEqual()
        {
            List<CompanyObject> listOfOutings = _outingDirectory.DisplayAllOutings();
            decimal totalCost = 0m;
            foreach (CompanyObject outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.Bowling)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            Assert.AreEqual(totalCost, 2500m);
        }
        [TestMethod]
        public void ViewTotalAmusementParkCost_ShouldReturnEqual()
        {
            List<CompanyObject> listOfOutings = _outingDirectory.DisplayAllOutings();
            decimal totalCost = 0m;
            foreach (CompanyObject outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.AmusementPark)
                {
                    totalCost += outing.CostPerEvent;
                }
            }
            Assert.AreEqual(totalCost, 2000m);
        }
    }
}
