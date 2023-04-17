using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Business.Contract;
using System.Threading.Tasks;
using System;
using Sat.Recruitment.Common.DTO;
using Sat.Recruitment.Common.Entities;
using Microsoft.Extensions.Logging;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
        {
            _userBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost, Route("create-user")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                UserOutput response = await _userBusiness.CreateUser(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpGet, Route("GetUser")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUser([FromQuery] int userId)
        {
            try
            {
                User response = await _userBusiness.GetUser(userId);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
