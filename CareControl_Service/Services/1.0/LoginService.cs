using CareControl_Service.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CareControl_Service.Services._1._0
{
    class LoginService
    {
        #region Object Initialization
        private const string ClassName = nameof(LoginService);
        private IConfiguration _config;
        #endregion

        public LoginService(IConfiguration config)
        {
            _config = config;
        }



        public async Task<SingleModelResponse<LoginResponse>> AuthenticateUser(LoginRequest loginRequest)
        {
            #region Object Initialization
            string source = ClassName + ".AuthenticateUser";
            var singleModelResponse = new SingleModelResponse<LoginResponse>();
            LoginResponse response = new LoginResponse();
         
            #endregion
            try
            {
                if (loginRequest.Email == "musabyahiya@hotmail.com") // authenticate
                {
                    response.Token = GenerateJSONWebToken(loginRequest);
                    response.StatusCode = "200";
                    response.ResponseCode = "0000";
                    response.ResponseMessage = "Successfully Login.";
                }
                else
                {
                    response.StatusCode = "401";
                    response.ResponseCode = "9999";
                    response.ResponseMessage = "Unauthorized.";

                }
            }
            catch (Exception ex)
            {
              
            }
           
            return singleModelResponse;
        }

        private string GenerateJSONWebToken(LoginRequest loginRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, loginRequest.Email),
       

            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
