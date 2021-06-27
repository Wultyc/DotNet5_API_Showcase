using DotNet5_API_Showcase.Models;
using DotNet5_API_Showcase.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.Repositories.InMemoryDB
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> userList = new()
        {
            new User { userId = Guid.NewGuid(), name = "Jonh", birthDate = new DateTime(1974, 06, 24, 0, 0, 0, DateTimeKind.Local), email = "john@example.com" },
            new User { userId = Guid.NewGuid(), name = "George", birthDate = new DateTime(1997, 05, 12, 0, 0, 0, DateTimeKind.Local), email = "george@example.com" },
            new User { userId = Guid.NewGuid(), name = "Michel", birthDate = new DateTime(1984, 09, 03, 0, 0, 0, DateTimeKind.Local), email = "michel@example.com" },
            new User { userId = Guid.NewGuid(), name = "Bella", birthDate = new DateTime(1996, 08, 30, 0, 0, 0, DateTimeKind.Local), email = "bella@example.com" }
        };

        public async Task<User> CreateUser()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            User returnUser = this.userList.Find(user => user.userId == userId);
            return await Task.FromResult( returnUser );
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(this.userList);
        }

        public async Task<User> UpdateUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
