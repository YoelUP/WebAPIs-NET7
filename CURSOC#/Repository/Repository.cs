using CURSOC_.Data;
using CURSOC_.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CURSOC_.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            dbSet.Remove(entity);
            await Save();

        }

        public async Task<T> Obtain(Expression<Func<T, bool>> filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filtro !=null)
            {
                query = query.Where(filtro);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtainAll(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
