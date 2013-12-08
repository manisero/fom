using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ClientAPI.Contract;
using DataAccess.Repository;
using DataSource.DataAccess;
using ClientAPI.AutoMapper.Extensions;
using System.Linq;

namespace ClientAPI
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ClientAPIService : IClientAPIService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ClientAPIService(IDataProvider dataProvider, IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            _dataProvider = dataProvider;
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _dataProvider.GetRestaurants().MapTo<Restaurant>().ToList();
        }

        public void CreateOrder(Order order)
        {
            var domainOrder = order.MapTo<Domain.Order>();

            _repositoryFactory.Create<Domain.Order>().Add(domainOrder);
            _unitOfWork.SaveChanges();
        }
    }
}