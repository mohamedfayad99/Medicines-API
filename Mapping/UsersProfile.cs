using AutoMapper;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Mapping
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>();
        }
    }
}
