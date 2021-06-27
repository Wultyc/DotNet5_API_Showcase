using DotNet5_API_Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.Interface.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<User>> GetUsers();

        public Task<User> CreateUser(User user);

        public Task<User> GetUserById(Guid userId);

        public Task<User> UpdateUser(User user);

        public Task DeleteUser(Guid userId);
    }
}
