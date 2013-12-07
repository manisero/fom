using System.Collections.Generic;
using System.ServiceModel.Activation;
using ClientAPI.Contract;

namespace ClientAPI._Impl
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestaurantService : IRestaurantService
    {
        public List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>
                {
                    new Restaurant
                        {
                            RestaurantID = 3,
                            Name = "SampleName",
                            Address = "SampleAddress",
                            PhoneNumber = "SamplePhoneNumber",
                            EmailAddress = "Sample@Email.Address"
                        }
                };
        }
    }
}