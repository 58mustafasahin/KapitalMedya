using KapitalMedya.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KapitalMedya.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            //builder.HasNoKey();
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.Country).HasColumnName("country");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.FirstName).HasColumnName("first_name");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Image).HasColumnName("image");
            builder.Property(e => e.JobTitle).HasColumnName("job_title");
            builder.Property(e => e.JobType).HasColumnName("job_type");
            builder.Property(e => e.LastName).HasColumnName("last_name");
            builder.Property(e => e.OnboardingCompletion).HasColumnName("onboarding_completion");
            builder.Property(e => e.Phone).HasColumnName("phone");
        }
    }
}
