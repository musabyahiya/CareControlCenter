using CareControl_Service.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareControl_Service.Constant;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CareControl_Service.Services._1._0
{
    public class LoginService
    {
        #region Object Initialization
        private const string ClassName = nameof(LoginService);
      

        #endregion

        public LoginService()
        {///
          

        }



        public async Task<SingleModelResponse<LoginResponse>> AuthenticateUser(LoginRequest loginRequest, JWTEntity entity)
        {
            #region Object Initialization
            string source = ClassName + ".AuthenticateUser";

            var singleModelResponse = new SingleModelResponse<LoginResponse>();
            singleModelResponse.Model = new LoginResponse();
        

            #endregion
            try
            {
                if (loginRequest.Email == "musabyahiya@hotmail.com") // authenticate
                {
                    singleModelResponse.Model.Token = GenerateJSONWebToken(loginRequest, entity);
                    singleModelResponse.Model.StatusCode = Constant.Constant.Success;
                    singleModelResponse.Model.ResponseCode = "0000";
                    singleModelResponse.Model.ResponseMessage = "Successfully Login.";
                    singleModelResponse.IsError = false;
                }
                else
                {
                    singleModelResponse.Model.StatusCode = Constant.Constant.Unauthorized;
                    singleModelResponse.Model.ResponseCode = "9999";
                    singleModelResponse.Model.ResponseMessage = "Unauthorized.";
                    singleModelResponse.IsError = true;


                }


            }
            catch (Exception ex)
            {

            }

            return singleModelResponse;
        }

        private string GenerateJSONWebToken(LoginRequest loginRequest, JWTEntity entity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(entity.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Email", loginRequest.Email),


            };

            var token = new JwtSecurityToken(entity.Issuer,
                entity.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      
    }
}
