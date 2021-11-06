using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalOrders
{
    public class MedicalOrder
    {
        public AptitudeCertificate AptitudeCertificate { get; set; }
        public IList<Inability>    Inabilities         { get; set; }

        public MedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            AptitudeCertificate = aptitudeCertificate;
        }

        public void AddInability(string inabilityDescription)
        {
            Inabilities.Add(new Inability(inabilityDescription));
        }
    }
}
