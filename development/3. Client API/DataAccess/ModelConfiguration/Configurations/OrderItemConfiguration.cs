using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DataAccess.ModelConfiguration.Configurations
{
    public class OrderItemConfiguration : EntityConfigurationBase<OrderItem>
    {
        protected override void ConfigureEntity(EntityTypeConfiguration<OrderItem> entity)
        {
            entity.Property(x => x.DishName).IsRequired().HasMaxLength(512);
        }
    }
}
