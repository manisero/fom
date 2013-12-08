using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DataAccess.ModelConfiguration.Configurations
{
    public class OrderConfiguration : EntityConfigurationBase<Order>
    {
        protected override void ConfigureEntity(EntityTypeConfiguration<Order> entity)
        {
            entity.Property(x => x.RestaurantName).IsRequired().HasMaxLength(256);
            entity.Property(x => x.RestaurantAddress).HasMaxLength(512);
            entity.Property(x => x.RestaurantPhoneNumber).HasMaxLength(32);
            entity.Property(x => x.RestaurantEmailAddress).HasMaxLength(256);
        }
    }
}
