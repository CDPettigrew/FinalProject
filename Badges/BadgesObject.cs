using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesObject
    {
        public int BadgeID { get; set; }
        public List<string> AllowedAccess { get; set; }

        public BadgesObject() { }
        public BadgesObject(int badgeId, List<string> allowedAccess)
        {
            BadgeID = badgeId;
            AllowedAccess = allowedAccess;
        }
    }
}
