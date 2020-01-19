using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetById(int id);
    }
}
