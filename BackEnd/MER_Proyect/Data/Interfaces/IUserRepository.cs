using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    // En Data/Interfaces/IUserRepository.cs
    using Entity.Model;

    public interface IUserRepository : IData<User>
    {
        Task<IEnumerable<User>> GetAllJoinAsync();
        Task<User?> GetByIdJoinAsync(int id);

    }

}
