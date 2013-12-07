using System.Data.Entity;

namespace DataAccess.ModelConfiguration
{
    public interface IEntityConfiguration
    {
        void Configure(DbModelBuilder modelBuilder);
    }
}
