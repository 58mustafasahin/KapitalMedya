using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Application.Repositories.Users;
using KapitalMedya.Persistence.Contexts;
using KapitalMedya.Persistence.Repositories.Appartments;
using KapitalMedya.Persistence.Repositories.Bookings;
using KapitalMedya.Persistence.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KapitalMedya.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<KapitalMedyaDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<IAppartmentReadRepository, AppartmentReadRepository>();
            services.AddScoped<IAppartmentWriteRepository, AppartmentWriteRepository>();
            services.AddScoped<IBookingReadRepository, BookingReadRepository>();
            services.AddScoped<IBookingWriteRepository, BookingWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            return services;
        }
    }
}
