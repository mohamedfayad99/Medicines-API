using AutoMapper;
using EMedicineBE.Controllers;
using EMedicineBE.DBContext;
using EMedicineBE.Exceptions;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EMedicineBE.Services
{
    public class UsersRepository :IUserRepository
    {
        private readonly ApplicationDB _applicationDB1;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsersRepository(ApplicationDB applicationDB1 ,ILogger<UsersController> logger,IMapper mapper,ITokenService tokenService)
        {
            _applicationDB1 = applicationDB1;
            _logger = logger;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        private bool IsValidUserDTO(UserDTO userDTO)
        {
            // FirstName must not be null or empty
            if (string.IsNullOrEmpty(userDTO.FirstName))
            {
                _logger.LogWarning("FirstName is required.");
                return false;
            }

            // LastName must not be null or empty
            if (string.IsNullOrEmpty(userDTO.LastName))
            {
                _logger.LogWarning("LastName is required.");
                return false;
            }

            // Password must meet complexity requirements (e.g., length, characters)
            if (string.IsNullOrEmpty(userDTO.Password) || userDTO.Password.Length < 8)
            {
                _logger.LogWarning("Password must be at least 8 characters long.");
                return false;
            }

            // Email must be a valid email address
            if (string.IsNullOrEmpty(userDTO.Email) || !IsValidEmail(userDTO.Email))
            {
                _logger.LogWarning("A valid Email is required.");
                return false;
            }

            // Fund must be a non-negative value
            if (userDTO.Fund < 0)
            {
                _logger.LogWarning("Fund must be zero or greater.");
                return false;
            }

            // Type must not be null or empty
            if (string.IsNullOrEmpty(userDTO.Type))
            {
                _logger.LogWarning("Type is required.");
                return false;
            }

            // Status must be a valid value (e.g., 0 for inactive, 1 for active)
            if (userDTO.status < 0 || userDTO.status > 1)
            {
                _logger.LogWarning("Status must be either 0 (inactive) or 1 (active).");
                return false;
            }

            // CreatedOn should not be in the future
            if (userDTO.createdon > DateTime.Now)
            {
                _logger.LogWarning("CreatedOn date cannot be in the future.");
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Users>> GetAllUaersAsync()
        {
            var allusers = await _applicationDB1.users.Include(c=>c.Carts)
                                 .Include(o=>o.Orders).ToListAsync();
            if (allusers == null)
            {
                _logger.LogWarning("No Found Any User!!!");
                return null;
            }
            return allusers;
        }
        public async Task<Users> GetUserAsync(int? id)
        {
            if (id == null || id==0)
            {
                _logger.LogError("Invalid id");
                throw new ArgumentException("Invalid id. Please enter a valid id.");
            }
            var user = await _applicationDB1.users.Include(c => c.Carts)
                             .Include(o => o.Orders).FirstOrDefaultAsync(m => m.ID==id);
            if (user == null)
            {
                _logger.LogInformation($"user with id {id} not found.");
                throw new NotFoundException($"user with id {id} not found.");

            }
            return user;
        }
        public async Task<RegisterDTO> Registration(UserDTO userDTO)
        {
            if (await isExist(userDTO.Email)) throw new ArgumentException("this Email is taken !");
            // Validate the DTO (if applicable)
            if (!IsValidUserDTO(userDTO))
            {
                _logger.LogWarning("Invalid UserDTO provided.");
               // throw new ArgumentException("Invalid UserDTO provided.");
                return null;
            }
            var newuser= _mapper.Map<Users>(userDTO);
            _applicationDB1.users.Add(newuser);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation($"the City that have id {newuser.ID} is created");
           
            return new RegisterDTO
            {
                email= newuser.Email,
                Token=_tokenService.CreateToken(newuser)
            };
        }
        public async Task<RegisterDTO> Login(LoginDTO loginDTO)
        {
            var user=await _applicationDB1.users.SingleOrDefaultAsync(u => u.Email== loginDTO.email.ToLower() && u.Password==loginDTO.password);
            if (user == null) return null;

            return new RegisterDTO
            {
                email = loginDTO.email,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> isExist(string email)
        {
            return await _applicationDB1.users.AnyAsync(s => s.Email == email.ToLower());
        }
        public async Task<UserDTO> UpdateProfile(int? id, UserDTO userDTO)
        {
            if (await isExist(userDTO.Email)) throw new ArgumentException("this Email is taken !");
            // Validate the DTO (if applicable)
            if (!IsValidUserDTO(userDTO))
            {
                _logger.LogWarning("Invalid UserDTO provided.");
                // throw new ArgumentException("Invalid UserDTO provided.");
                return null;
            }
            if (id == null || id == 0)
            {
                _logger.LogError("Invalid id. Please enter a valid id");
                throw new ArgumentException("Invalid id. Please enter a valid id.");
            }
            var updateduser =await _applicationDB1.users.FirstOrDefaultAsync(f => f.ID == id);
            if (updateduser == null)
            {
                _logger.LogInformation($"User with id {id} not found.");
                return null;
            }
            _mapper.Map(userDTO, updateduser);
            _applicationDB1.users.Update(updateduser);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation($"User with id : {updateduser.ID} is Updated");
            return userDTO;

        }
        public async Task DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                _logger.LogError("Invalid id");
                throw new ArgumentException("Invalid id. Please enter a valid id.");
            }
            var user = await _applicationDB1.users.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                _logger.LogWarning($"user with id {id} not found.");
                throw new NotFoundException($"user with id {id} not found.");
            }
            _applicationDB1.users.Remove(user);
            await _applicationDB1.SaveChangesAsync();
        }
   
    }
}
