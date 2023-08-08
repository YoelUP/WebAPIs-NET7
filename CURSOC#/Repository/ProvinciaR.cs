using CURSOC_.Data;
using CURSOC_.Models;
using CURSOC_.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CURSOC_.Repository
{
    public class ProvinciaR : Repository<ProvinciaC>, IProvinciaC
    {
        private readonly ApplicationDbContext _context;

        public ProvinciaR(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<ProvinciaC> UpdateP(ProvinciaC entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
