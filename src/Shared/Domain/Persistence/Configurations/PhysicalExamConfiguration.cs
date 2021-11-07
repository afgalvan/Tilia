using Domain.MedicalFiles.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Persistence.Configurations
{
    public class PhysicalExamConfiguration : IEntityTypeConfiguration<PhysicalExam>
    {
        public void Configure(EntityTypeBuilder<PhysicalExam> builder)
        {
            builder.OwnsOne(physicalExam => physicalExam.VitalSignResults);
        }
    }
}
