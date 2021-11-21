using Domain.MedicalFiles.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedLib.Persistence.Configurations
{
    public class PhysicalExamConfiguration : IEntityTypeConfiguration<PhysicalExam>
    {
        public void Configure(EntityTypeBuilder<PhysicalExam> builder)
        {
            builder.OwnsOne(exam => exam.VitalSignResults);
        }
    }
}
