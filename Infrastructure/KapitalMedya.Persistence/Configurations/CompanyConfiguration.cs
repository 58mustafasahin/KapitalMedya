using KapitalMedya.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KapitalMedya.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            builder.Property(e => e.Address).HasMaxLength(50).HasColumnName("address").IsFixedLength();
            builder.Property(e => e.Age).HasColumnName("age");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Salary).HasColumnName("salary");
        }
    }
}
