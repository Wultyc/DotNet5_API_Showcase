using DotNet5_API_Showcase.Models;
using DotNet5_API_Showcase.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {

        private IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET /api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await this.userRepository.GetUsers());
        }

        // GET /api/users/{id}
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            User returnUser = await this.userRepository.GetUserById(userId);

            if (returnUser is null) return NotFound();

            return Ok(returnUser);
        }
    }
}
