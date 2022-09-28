using AutoMapper;
using DMART.Models;
using DMART.Models.ViewModels;

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
