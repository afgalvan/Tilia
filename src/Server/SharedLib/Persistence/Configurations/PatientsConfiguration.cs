using Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedLib.Persistence.Configurations
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsOne(patient => patient.ContactData);
            builder.OwnsOne(patient => patient.SportsData);
            builder.Property(patient => patient.Occupation).HasMaxLength(255);
            builder.Property(patient => patient.Studies).HasMaxLength(255);
        }
    }
}
