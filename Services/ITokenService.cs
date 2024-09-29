using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Services
{
    public interface ITokenService
    {
        string CreateToken(Users users);
    }
}
