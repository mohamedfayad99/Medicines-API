using EMedicineBE.Exceptions;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;
using EMedicineBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EMedicineBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository1;

        public UsersController( IConfiguration configuration,IUserRepository userRepository1)
        {
            _configuration=configuration;
            _userRepository1 = userRepository1;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var allusers = await _userRepository1.GetAllUaersAsync();
            if (allusers == null)
            {
                return NotFound("No Found Any User!!!");
            }
            return Ok(allusers);
        }
        [AllowAnonymous] // Allow access to everyone
        [HttpGet("{id?}")]
        public async Task<ActionResult<Users>> GetUser(int? id)
        {
            var user = await _userRepository1.GetUserAsync(id);
            return Ok(user);
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("UserDTO is null");
            }
            var newuser = await _userRepository1.Registration(userDTO);
            if (newuser == null)
            {
                return BadRequest("Invalid UserDTO provided");
            }
            return Ok(newuser);
        }
        [HttpPost("login")]
        public async Task<ActionResult<RegisterDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userRepository1.Login(loginDTO);
            if (user == null)
            {
                return BadRequest("Pass Or Email incorrect!!!");
            }
            return user;
        }

        [HttpPut("updateProfile/{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProfile([FromRoute]int? id,[FromBody]UserDTO user)
        {
            var updateduser = await _userRepository1.UpdateProfile(id, user);
            if (updateduser == null)
            {
                return NotFound($"User with id {id} not found.");
            }
            return Ok(updateduser);
        }

       
        [HttpDelete("deleteuser/{id?}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUser(int? id)
        {
            try
            {
                await _userRepository1.DeleteUser(id);
                return NoContent(); // 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound($"no found user with id {id}"); // 404 Not Found
            }
        }


    }




    }

