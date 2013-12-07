using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DataAccess.ModelConfiguration.Configurations
{
    public class PersonConfiguration : EntityConfigurationBase<Person>
    {
        protected override void ConfigureEntity(EntityTypeConfiguration<Person> entity)
        {
            entity.Property(x => x.Name).HasMaxLength(256);
        }
    }
}
