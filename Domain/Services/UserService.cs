using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
