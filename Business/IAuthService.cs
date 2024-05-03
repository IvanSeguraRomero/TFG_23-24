using System.Security.Claims;
using FlashGamingHub.Models;

namespace FlashGamingHub.Business
{
    public interface IAuthService
    {
        public string Login(LoginDtoIn userDtoIn);
        public string Register(UserCreateDTO userCreateDTO);
        public string GenerateToken(UserDTOOut userDTOOut);
        public bool HasAccessToResource(int requestedUserID, ClaimsPrincipal user);

         public bool IsAdmin(ClaimsPrincipal user);


    }
}
