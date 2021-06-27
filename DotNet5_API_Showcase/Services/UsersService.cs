using DotNet5_API_Showcase.Interface.Services;
using DotNet5_API_Showcase.Models;
using DotNet5_API_Showcase.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository userRepository;

        public UsersService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            return await this.userRepository.CreateUser(user);
        }

        public async Task DeleteUser(Guid userId)
        {
            await this.userRepository.DeleteUser(userId);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await this.userRepository.GetUserById(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.userRepository.GetUsers();
        }

        public async Task<User> UpdateUser(User user)
        {
            return await this.userRepository.UpdateUser(user);
        }
    }
}
