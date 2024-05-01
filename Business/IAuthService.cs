using System.Security.Claims;
using FlashGamingHub.Models;

namespace FlashGamingHub.Business
{
    public interface IAuthService
    {
        public string Login(LoginDtoIn userDtoIn);
        public string Register(UserDtoIn userDtoIn);
        public string GenerateToken(UserDTOOut userDTOOut);
        public bool HasAccessToResource(int requestedUserID, ClaimsPrincipal user);


    }
}
