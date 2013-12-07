using System.Collections.Generic;
using System.ServiceModel.Activation;
using ClientAPI.Contract;
using DataSource.DataAccess;
using ClientAPI.AutoMapper.Extensions;
using System.Linq;

namespace ClientAPI._Impl
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ClientAPIService : IClientAPIService
    {
        private readonly IDataProvider _dataProvider;

        public ClientAPIService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _dataProvider.GetRestaurants().MapTo<Restaurant>().ToList();
        }
    }
}