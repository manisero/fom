using AutoMapper;
using ClientAPI.AutoMapper.Extensions;

namespace ClientAPI.AutoMapper.Profiles
{
    public class ClientAPIProfile : Profile
    {
        protected override void Configure()
        {
            // DataSource -> Contract
            CreateMap<DataSource.Domain.Restaurant, Contract.Restaurant>()
                .Map(x => x.Restaurant_ID, x => x.RestaurantID)
                .Map(x => x.Phone_Number, x => x.PhoneNumber)
                .Map(x => x.Email_Address, x => x.EmailAddress);

            CreateMap<DataSource.Domain.Dish, Contract.Dish>()
                .Map(x => x.Dish_ID, x => x.DishID);

            // Domain -> Contract
            CreateMap<Domain.Order, Contract.Order>()
                .Map(x => x.DeliveryDate.ToShortDateString(), x => x.DeliveryDate);

            // Contract -> Domain
            CreateMap<Contract.Order, Domain.Order>();

            // Contrat -> Logic
            CreateMap<Contract.Order, Logic.DataManagement.Model.OrderInfo>();
            CreateMap<Contract.OrderItem, Logic.DataManagement.Model.OrderItemInfo>();
        }
    }
}