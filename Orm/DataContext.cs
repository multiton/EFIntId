using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Entity;

namespace Orm
{
    public class DataContext : DbContext
    {
	    public DbSet<OrderHeader> OrderHeaders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());
		}
	}
}