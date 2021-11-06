using System.Collections.Generic;
using System.Linq;

namespace Domain.MedicalFiles.MedicalOrders
{
    public class MedicalOrder
    {
        public AptitudeCertificate AptitudeCertificate { get; set; }
        public IList<Referrals>    Referrals           { get; set; }
        public IList<Inability>    Inabilities         { get; set; }

        public MedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            AptitudeCertificate = aptitudeCertificate;
        }

        public void AddReferrals(string referralDepartment)
        {
            Referrals.Add(new Referrals(referralDepartment));
        }

        public void AddInability(string inabilityDescription)
        {
            Inabilities.Add(new Inability(inabilityDescription));
        }
    }
}
