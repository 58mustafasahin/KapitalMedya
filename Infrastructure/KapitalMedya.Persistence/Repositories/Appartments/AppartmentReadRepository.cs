using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Appartments
{
    public class AppartmentReadRepository : ReadRepository<Appartment>, IAppartmentReadRepository
    {
        public AppartmentReadRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
