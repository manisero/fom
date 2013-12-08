using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DataAccess.ModelConfiguration.Configurations
{
    public class PaymentConfiguration : EntityConfigurationBase<Payment>
    {
        protected override void ConfigureEntity(EntityTypeConfiguration<Payment> entity)
        {
            entity.HasRequired(x => x.Person).WithMany(x => x.Payments).HasForeignKey(x => x.PersonID).WillCascadeOnDelete(false);
            entity.HasRequired(x => x.Order).WithMany(x => x.Payments).HasForeignKey(x => x.OrderID);
        }
    }
}
