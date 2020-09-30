using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareControl_Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CareControl_Service.Services._1._0;
using Microsoft.Extensions.Configuration;

namespace CareControl_Web.Controllers
{
    public class LoginController : Controller
    {
        #region Object intialization 
        private IConfiguration _config;
        private LoginService _loginService = new LoginService();
        private JWTEntity _JWTEntity = new JWTEntity();
        #endregion


        public LoginController(IConfiguration config)
        {
            _config = config;
            _JWTEntity.Key = _config["Jwt:Key"];
            _JWTEntity.Issuer = _config["Jwt:Issuer"];


        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Login", Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            var response = await _loginService.AuthenticateUser(loginRequest, _JWTEntity);
            var actionResult = response.IsError ? new ObjectResult(response.Model.ResponseMessage) { StatusCode = response.Model.StatusCode } : new OkObjectResult(response.Model);
            return actionResult;

        }




        [HttpPost("Home", Name = "Home")]
        [Authorize]
        public async Task<IActionResult> Home()
        {

            return new OkObjectResult("Hello");

        }

    }
}
