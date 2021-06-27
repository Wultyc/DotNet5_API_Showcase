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
    }
}
