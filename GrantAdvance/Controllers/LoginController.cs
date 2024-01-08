using GrantAdvance.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using GrantAdvance.Infras.Services.Interface;
using AutoMapper;
using GrantAdvance.Domain.Models.Security;

namespace GrantAdvance.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        public LoginController(IAuthenticateService authenticateService, IMapper mapper)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns>Token</returns>

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsViewModel userCredentials)
        {
            var response = await _authenticateService.CreateAccessTokenAsync(userCredentials.Email!, userCredentials.Password!);
            
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessToken = new AccessTokenResource
            {
                AccessToken = response.Token.Token,
                Expiration = response.Token.Expiration
            };

            return Ok(accessToken);
        }

        [HttpPost("token/refresh")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            var response = await _authenticateService.RefreshTokenAsync(refreshTokenResource.Token!, refreshTokenResource.UserEmail!);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(_mapper.Map<AccessTokenResource>(response.Token));
        }
    }
}
