using KapitalMedya.Application.Repositories.Users;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Users
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
