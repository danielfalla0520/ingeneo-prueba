using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business
{
    public class LoginBusiness
    {
        public static Model.Response.LoginResponse Login(Model.Request.LoginRequest request)
        {
            Model.Response.LoginResponse response = new Model.Response.LoginResponse();
            try
            {
                if (ValidateRequest(request))
                {
                    response = Data.LoginData.Login(request);
                    if (ValidateResponse(response))
                    {
                        if(string.IsNullOrEmpty(response.userEntity.error))
                        {
                            var secretKey = Data.Util.ConfigReader.GetValue("SecretKey");
                            var key = Encoding.ASCII.GetBytes(secretKey);
                            var claims = new[]
                            {
                            new Claim(ClaimTypes.NameIdentifier, response.userEntity.id.ToString())
                            };
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(claims),
                                Expires = DateTime.UtcNow.AddDays(1),
                                NotBefore = DateTime.UtcNow,
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                            };
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                            response.accessToken = tokenHandler.WriteToken(createdToken);
                        }
                        else
                        {
                            response.code = 101;
                            response.message = "User or password incorrect";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        private static bool ValidateRequest(Model.Request.LoginRequest request)
        {
            Model.Response.CodeResponse codeResponse = new Model.Response.CodeResponse();
            if (string.IsNullOrEmpty(request.email))
            {
                codeResponse.code = 101;
                codeResponse.message = "Email invalid";
                return false;
            }
            if (string.IsNullOrEmpty(request.password))
            {
                codeResponse.code = 102;
                codeResponse.message = "Password invalid";
                return false;
            }
            return true;
        }
        private static bool ValidateResponse(Model.Response.LoginResponse response)
        {
            if (!string.IsNullOrEmpty(response.message))
            {
                return false;
            }
            return true;
        }
    }
}
