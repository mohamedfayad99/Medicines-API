using AutoMapper;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDTO>();
            CreateMap<CartDTO, Cart>();
        }
    }
}
