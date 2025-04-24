using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Repository;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Services
{
    public class UserRepository : DataGeneric<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<bool> PersonExistsAsync(int personId)
        {
            return await _dbSet.AnyAsync(u => u.person_id == personId && !u.is_deleted);
        }
        public async Task<User> CreateAsync(User entity)
        {
            if (await PersonExistsAsync(entity.person_id))
            {
                throw new InvalidOperationException("El Person ID ya está asociado a un usuario.");
            }

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllJoinAsync()
        {
            return await _dbSet
                       .Include(u => u.person)
                       .Where(u => !u.is_deleted)
                       .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllDeletesJoinAsync()
        {
            return await _dbSet
                       .Include(u => u.person)
                       .Where(u => u.is_deleted)
                       .ToListAsync();
        }

        public async Task<User?> GetByIdJoinAsync(int id)
        {
            return await _dbSet
                        .Include(u => u.person)
                        .Where(u => !u.is_deleted && u.id == id)
                        .FirstOrDefaultAsync();
        }
    }
}
