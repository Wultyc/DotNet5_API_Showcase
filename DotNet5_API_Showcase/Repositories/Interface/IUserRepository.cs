using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5_API_Showcase.Models;

namespace DotNet5_API_Showcase.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(Guid userId);
        public Task<User> CreateUser();
        public Task<User> UpdateUser(Guid userId);
        public Task DeleteUser(Guid userId);
    }
}
