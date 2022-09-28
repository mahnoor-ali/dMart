using AutoMapper;
using DMART.Models;

namespace DMART.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Product, productCartModel>();
        }
    }
    
}
