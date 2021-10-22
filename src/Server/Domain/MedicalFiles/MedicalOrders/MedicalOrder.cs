using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalOrders
{
    public class MedicalOrder
    {
        public AptitudeCertificate    AptitudeCertificate { get; set; }
        public IEnumerable<Referrals> Referrals           { get; set; }
        public IEnumerable<Inability> Inability           { get; set; }

        public MedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            AptitudeCertificate = aptitudeCertificate;
        }
    }
}
