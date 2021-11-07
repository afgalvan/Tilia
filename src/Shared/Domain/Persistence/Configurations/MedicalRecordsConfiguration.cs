using Domain.MedicalFiles.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Persistence.Configurations
{
    public class MedicalRecordsConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.OwnsOne(medicalRecord => medicalRecord.Anamnesis);
        }
    }
}
