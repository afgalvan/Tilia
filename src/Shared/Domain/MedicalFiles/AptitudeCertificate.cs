namespace Domain.MedicalFiles
{
    public enum AptitudeCertificate
    {
        Able,
        Unfit,
        Limited,
        Recommendation
    }

    public static class AptitudeCertificateExtensions
    {
        public static string AsString(this AptitudeCertificate certificate) =>
            certificate switch
            {
                AptitudeCertificate.Unfit => "Incapacidades",
                AptitudeCertificate.Limited => "Limitados",
                AptitudeCertificate.Recommendation => "Con Recomendaciones",
                _ => "Capaces"
            };
    }
}
