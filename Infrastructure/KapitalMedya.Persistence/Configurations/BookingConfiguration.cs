using KapitalMedya.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KapitalMedya.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");
            //builder.HasNoKey();
            builder.Property(e => e.ApartmentId).HasColumnName("apartment_id");
            builder.Property(e => e.BookedAt).HasColumnName("booked_at");
            builder.Property(e => e.BookedFor).HasColumnName("booked_for");
            builder.Property(e => e.Confirmed).HasColumnName("confirmed");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.StartsAt).HasColumnName("starts_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");
        }
    }
}
