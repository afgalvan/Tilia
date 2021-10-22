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

        public void AddReferrals(Referrals referral)
        {
            Referrals.Add(referral);
        }

        public void AddInability(Inability inability)
        {
            Inabilities.Add(inability);
        }
    }
}
