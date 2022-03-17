using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car, Home, Theft}
    public class ClaimsObject
    {
        public int ClaimId { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool IsValid { get; set; }

        public ClaimsObject() { }

        public ClaimsObject(int claimId, ClaimType typeOfClaim, string description, int claimAmount, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            ClaimId = claimId;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            IsValid = isValid;
        }
    }
}
