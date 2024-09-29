using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUaersAsync();
        Task<Users> GetUserAsync(int? id);
        Task<RegisterDTO> Registration(UserDTO userDTO);
        Task<RegisterDTO> Login(LoginDTO loginDTO);
        Task<UserDTO?> UpdateProfile(int? id,UserDTO user);
        Task DeleteUser(int? id);


    }
}
