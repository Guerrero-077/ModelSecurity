using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Entity.DTOs;
using Entity.DTOs.Select;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    // En Data/Services/UserRepository.cs
    public class UserRepository : DataGeneric<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllJoinAsync()
        {
            return await _dbSet
                .Include(u => u.person)
                .Where(u => !u.is_deleted)
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
