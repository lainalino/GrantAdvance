using AutoMapper;
using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;
using GrantAdvance.Infras.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GrantAdvance.API.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create the user
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns>The user created</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCredentialsViewModel userCredentials)
        {
            var user = new User
            {
                Email = userCredentials.Email,
                Password = userCredentials.Password,
                Name = userCredentials.Name
            };

            if (ModelState.IsValid)
            {
                var response = await _userService.CreateUserAsync(user);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.User);
            }

            return BadRequest();
        }
    }
}
