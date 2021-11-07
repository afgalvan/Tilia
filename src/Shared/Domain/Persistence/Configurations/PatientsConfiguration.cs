using Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Persistence.Configurations
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsOne(patient => patient.ContactData);
            builder.OwnsOne(patient => patient.SportsData);
        }
    }
}
