using System.Collections.Generic;
using System;
using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void EnterNewClaim_ShouldReturnCorrectBool()
        {
            ClaimsObject claim = new ClaimsObject();
            ClaimsRepository claimQueue = new ClaimsRepository();
            bool result = claimQueue.EnterNewClaim(claim);
            Assert.IsTrue(result);
        }
        private ClaimsRepository _claimsRepository;
        private ClaimsObject _claimsObject;
        [TestInitialize]
        public void Arrange()
        {
            _claimsRepository = new ClaimsRepository();
            _claimsObject = new ClaimsObject(1, ClaimType.Theft, "someone stole something", 500, true);
            _claimsObject = new ClaimsObject(2, ClaimType.Car, "someeone broke my window", 250, true);
            _claimsRepository.EnterNewClaim(_claimsObject);
        }
        [TestMethod]
        public void ShowAllCurrentClaims_ShouldReturnCorrectBool()
        {
            Queue<ClaimsObject> claim = _claimsRepository.GetAllClaims();
            bool result = claim.Contains(_claimsObject);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TakeCareOfNextClaim_ShouldReturnNextItemInQueueAndRemoveIt()
        {
            ClaimsObject claim = _claimsRepository.TakeCareOfNextClaim();
            Assert.AreEqual(_claimsObject , claim);
        }
        [TestMethod]
        public void GetFirstInQueue_ShouldReturnNextItemInQueueAndNotRemoveIt()
        {
            ClaimsObject claim = _claimsRepository.GetFirstInQueue();
            Assert.AreEqual(_claimsObject, claim);
        }
    }
}
