using Badges;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Badges_Tests
{
    [TestClass]
    public class BagesTests
    {
        [TestMethod]
        public void CreateNewBadgeAndAddToDictionary_ShouldReturnCorrectBool()
        {
            BadgesObject badge = new BadgesObject();
            BadgesRepository badgeDirectory = new BadgesRepository();
            bool createResult = badgeDirectory.CreateNewBadgeAndAddToDictionary(badge);
            Assert.IsTrue(createResult);
        }
        private BadgesObject _badges;
        private BadgesRepository _badgesRepository;
        [TestInitialize]
        public void Arrange()
        {
            _badgesRepository = new BadgesRepository();
            List<string> allowedAccess = new List<string>(new string[] { "a1", "a2", "a3" });
            _badges = new BadgesObject(26, allowedAccess);
            _badgesRepository.CreateNewBadgeAndAddToDictionary(_badges);
        }
        [TestMethod]
        public void SeeAllBadges_ShouldReturnListOfBadges()
        {
            Dictionary<int, List<string>> badges = _badgesRepository.SeeAllBadges();
            bool hasBadges = badges.ContainsKey(_badges.BadgeID);
            Assert.IsTrue(hasBadges);
        }
        [TestMethod]
        public void AddDoorToBadge_ShoulReturnTheCorrectBool()
        {
            bool addDoor = _badgesRepository.AddDoorToBadge(26, "a4");
            Assert.IsTrue(addDoor);
        }
        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTheCorrectBool()
        {
            bool removeDoor = _badgesRepository.RemoveDoorFromBadge(26, "a1");
            Assert.IsTrue(removeDoor);
        }
    }
}
