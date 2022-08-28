using KapitalMedya.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace KapitalMedya.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
