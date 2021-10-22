using System.Collections.Generic;
using System.Linq;

namespace Domain.MedicalFiles.MedicalOrders
{
    public class MedicalOrder
    {
        public AptitudeCertificate    AptitudeCertificate { get; set; }
        public IEnumerable<Referrals> Referrals           { get; set; }
        public IEnumerable<Inability> Inabilities         { get; set; }

        public MedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            AptitudeCertificate = aptitudeCertificate;
        }

        public IEnumerable<Referrals> AddReferrals(Referrals referral)
        {
            return Referrals.Append(referral);
        }

        public IEnumerable<Inability> AddInability(Inability inability)
        {
            return Inabilities.Append(inability);
        }
    }
}
