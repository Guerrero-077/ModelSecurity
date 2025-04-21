using Data.Interfaces;
using Data.Repository;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class FormModuleRepository : DataGeneric<FormModule>, IFormModuleRepository
    {
        public FormModuleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FormModule>> GetAllJoinAsync()
        {
            return await _dbSet
                       .Include(u => u.form)
                       .Include(u => u.module)
                       .Where(u => !u.is_deleted)
                       .ToListAsync();
        }

        public async Task<FormModule?> GetByIdJoinAsync(int id)
        {
            return await _dbSet
                        .Include(u => u.form)
                        .Include(u => u.module)
                        .Where(u => !u.is_deleted && u.id == id)
                        .FirstOrDefaultAsync();
        }
    }
}
