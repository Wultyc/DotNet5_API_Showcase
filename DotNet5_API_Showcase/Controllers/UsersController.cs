using DotNet5_API_Showcase.Models;
using DotNet5_API_Showcase.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5_API_Showcase.DTOs;

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
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            var returnList = (await this.userRepository.GetUsers()).Select(user => user.AsDto());
            return Ok(returnList);
        }

        // POST /api/users/
        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser(UserRequestCreateUpdate user)
        {
            User newUser;

            try { newUser = user.AsModel(); }
            catch { return BadRequest(); }

            User returnUser = await this.userRepository.CreateUser(newUser);

            return Ok(returnUser.AsDto());
        }

        // GET /api/users/{id}
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid userId)
        {
            User returnUser = await this.userRepository.GetUserById(userId);

            if (returnUser is null) return NotFound();

            return Ok(returnUser.AsDto());
        }

        // PUT /api/users/{id}
        [HttpPut("{userId}")]
        public async Task<ActionResult<UserResponse>> UpdateUser(Guid userId, UserRequestCreateUpdate user)
        {
            User newUser;

            try { newUser = user.AsModel(userId); }
            catch { return BadRequest(); }

            User returnUser = await this.userRepository.UpdateUser(userId, newUser);

            return Ok(returnUser.AsDto());
        }
    }
}
