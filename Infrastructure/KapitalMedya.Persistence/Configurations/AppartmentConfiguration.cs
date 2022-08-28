using KapitalMedya.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KapitalMedya.Persistence.Configurations
{
    public class AppartmentConfiguration : IEntityTypeConfiguration<Appartment>
    {
        public void Configure(EntityTypeBuilder<Appartment> builder)
        {
            builder.ToTable("appartments");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            builder.Property(e => e.Address).HasColumnName("address");
            builder.Property(e => e.Address2).HasColumnName("address2");
            builder.Property(e => e.Booked).HasColumnName("booked");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.Country).HasColumnName("country");
            builder.Property(e => e.Direction).HasColumnName("direction");
            builder.Property(e => e.Image).HasColumnName("image");
            builder.Property(e => e.Latitude).HasColumnName("latitude");
            builder.Property(e => e.Longitude).HasColumnName("longitude");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.ZipCode).HasColumnName("zip_code");
        }
    }
}
