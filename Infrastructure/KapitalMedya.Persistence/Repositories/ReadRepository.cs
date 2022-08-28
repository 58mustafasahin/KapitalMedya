using KapitalMedya.Application.Repositories;
using KapitalMedya.Domain.Entities.Common;
using KapitalMedya.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KapitalMedya.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly KapitalMedyaDbContext _context;
        public ReadRepository(KapitalMedyaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
