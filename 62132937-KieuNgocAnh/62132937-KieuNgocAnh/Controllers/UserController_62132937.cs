﻿using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Aplicaion.Users.DTO;
using _62132937_KieuNgocAnh.Config;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class UserController_62132937
        : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController_62132937(  IUserService userService)
        {
            UserService=userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] SignInModel model)
        {
            var token = await UserService.Authenticate(model.Username,model.Password);

            if (token == null)
                return Ok(new { message = "Username of password incorrect" });

            return Ok( token);
        }

        

        [HttpPost("signup")]
        public  async Task<IActionResult> SignUp(SignUpModel SignUp)
        {
            var result = await UserService.Create(SignUp);
            return Ok(result);
        }


        [HttpGet("curren-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result =  await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);
            return Ok(result);
        }


    }
}
