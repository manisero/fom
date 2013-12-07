using System.Data.Entity;
using System.Linq;
using Core.Extensions;

namespace DataAccess.ModelConfiguration
{
    public class ModelConfigurator
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            var configurationTypes = GetType().Assembly.GetConcreteTypes<IEntityConfiguration>();

            configurationTypes.Select(x => x.CreateInstance<IEntityConfiguration>())
                              .ForEach(x => x.Configure(modelBuilder));
        }
    }
}
