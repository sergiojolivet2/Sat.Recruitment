using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            return _userService.CreateUserAsync(name, email, address, phone, userType, money);
        }
    }
}

