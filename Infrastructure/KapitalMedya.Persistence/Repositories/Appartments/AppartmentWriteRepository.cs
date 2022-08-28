using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Appartments
{
    public class AppartmentWriteRepository : WriteRepository<Appartment>, IAppartmentWriteRepository
    {
        public AppartmentWriteRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
