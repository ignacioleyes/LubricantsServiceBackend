using LubricantsServiceBackend.DTOs;
using LubricantsServiceBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static LubricantsServiceBackend.Utils.Constants;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations such as creating users, retrieving users, and user login.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersServices userServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userServices">Service for handling user-related operations.</param>
        public UsersController(UsersServices userServices)
        {
            this.userServices = userServices;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="model">The user creation model.</param>
        /// <returns>An authentication response DTO.</returns>
        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{Roles.ADMIN}")]
        public async Task<ActionResult<AuthResponseDTO>> CreateUser([FromBody] ApplicationUserCreationDTO model)
        {
            return await userServices.CreateUser(model);
        }

        /// <summary>
        /// Retrieves a list of users based on the specified filter.
        /// </summary>
        /// <param name="filter">The filter criteria for retrieving users.</param>
        /// <returns>A list response containing user DTOs.</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{Roles.ADMIN}")]
        public async Task<ActionResult<ListResponse<ApplicationUserDTO>>> GetUsers([FromQuery] UsersFilter filter)
        {
            return await userServices.GetUsers(filter);
        }

        /// <summary>
        /// Authenticates a user and generates a token.
        /// </summary>
        /// <param name="model">The login model containing user credentials.</param>
        /// <returns>An authentication response DTO.</returns>
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginDTO model)
        {
            return await userServices.Login(model);
        }
    }
}
