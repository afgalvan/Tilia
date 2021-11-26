using Domain.MedicalFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedLib.Persistence.Configurations
{
    public class MedicalAppointmentConfiguration : IEntityTypeConfiguration<MedicalAppointment>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointment> builder)
        {
            builder.OwnsOne(medicalAppointment => medicalAppointment.Anamnesis);
        }
    }
}
