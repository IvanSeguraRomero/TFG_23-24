using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using FlashGamingHub.Data;
using FlashGamingHub.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FlashGamingHub.Business
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;

        public AuthService(IConfiguration configuration, IUserRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public string Login(LoginDtoIn loginDtoIn) {
            var user = _repository.GetUserFromCredentials(loginDtoIn);
            return GenerateToken(user);
        }

        public string Register(UserCreateDTO userAdd) {
            var user =new User{
                Name = userAdd.Name,
                Surname=userAdd.Surname,
                Password=userAdd.Password,
                Age=userAdd.Age,
                Email=userAdd.Email,
                RegisterDate=userAdd.RegisterDate,
                Active=userAdd.Active,
                Role=userAdd.Role
            };
            _repository.AddUser(user);
            var userOut=new UserDTOOut{
                UserId=user.UserID,
                UserName=userAdd.Name,
                Email=userAdd.Email,
                Role=userAdd.Role
            };
            return GenerateToken(userOut);
        }

        public string GenerateToken(UserDTOOut user) {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(new Claim[] 
                    {
                        new Claim("id", Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        } 
       public bool HasAccessToResource(int requestedUserID, ClaimsPrincipal user) 
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim is null || !int.TryParse(userIdClaim.Value, out int userId)) 
            { 
                return false; 
            }
            return userId == requestedUserID;
        }

        public bool IsAdmin(ClaimsPrincipal user) 
        {
            var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim != null && roleClaim.Value == Roles.Admin)
            {
                return true;
            }
            return false;
        }


     

    }
}
