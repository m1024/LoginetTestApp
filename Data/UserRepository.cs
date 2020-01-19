using Data.Models;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        private static IEnumerable<UserData> _users;

        private async Task<IEnumerable<UserData>> GetUsersAsync(string url = "http://jsonplaceholder.typicode.com/users")
        {
            if (_users != null) return _users; //по идее кешировать не надо, но тут данные неизменяемые

            var json = await RemoteJsonLoader.Load(url);
            return _users = JsonSerializer.Deserialize<IEnumerable<UserData>>(json);
        }

        public async Task<User> GetById(int id)
        {
            var users = await GetUsersAsync();
            var user = users.FirstOrDefault(u => u.Id == id);
            return user == null ? null : new User() { Id = user.Id, Name = user.Name, UserName = user.UserName, Email = user.Email };
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await GetUsersAsync();
            return users.Select(u => new User() { Id = u.Id, Name = u.Name, UserName = u.UserName, Email = u.Email }).ToList();
        }
    }
}
