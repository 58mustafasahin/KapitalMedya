using KapitalMedya.Application.Repositories.Users;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Users
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
