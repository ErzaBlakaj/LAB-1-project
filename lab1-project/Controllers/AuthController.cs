using lab1_project.Models;
using lab1_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace lab1_project.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController
    {
        private AuthService _authService;

        public AuthController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _authService = new AuthService(connectionString);
        }


        [HttpPost("createUser")]
        public dynamic CreateUser([FromBody] RegisterUserModel request)
        {
            try
            {
                var userId = _authService.RegisterNewUser(request.Emri, request.Mbiemri, request.Email,request.Fjalekalimi,request.Id_role);

                return userId;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("login")]
        public dynamic LoginUser([FromBody] LoginRequest request)
        {
            try
            {
                var response = _authService.LoginUser(request.Email, request.Password);

                return response;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
