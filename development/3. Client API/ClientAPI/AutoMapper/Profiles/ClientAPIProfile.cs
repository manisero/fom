using AutoMapper;
using ClientAPI.AutoMapper.Extensions;

namespace ClientAPI.AutoMapper.Profiles
{
    public class ClientAPIProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<DataSource.Domain.Restaurant, Contract.Restaurant>()
                .Map(x => x.Restaurant_ID, x => x.RestaurantID)
                .Map(x => x.Phone_Number, x => x.PhoneNumber)
                .Map(x => x.Email_Address, x => x.EmailAddress);
        }
    }
}