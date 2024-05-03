using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.Models;
using FlashGamingHub.Business;

namespace FlashGamingHub.API.Controllers;

[ApiController]
[Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDtoIn loginDtoIn)
        {
            try
            {
                if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

                var token = _authService.Login(loginDtoIn);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest
                ("Error generating the token: " + ex.Message);
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(UserCreateDTO userCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

                var token = _authService.Register(userCreateDTO);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest
                ("Error generating the token: " + ex.Message);
            }
        }

    }