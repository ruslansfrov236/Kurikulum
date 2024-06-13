using kurikulum.Controllers.Customers;
using kurikulum.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace kurikulum.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } 

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Header> Headers { get; set; }

        public DbSet<HeaderContent> HeaderContents { get; set; }

        public DbSet<SubQrupCategory> SubQrupCategories { get; set; }
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			
			TimeZoneInfo azerbaijanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time");

			var datas = ChangeTracker
				.Entries<BaseEntity>();

			foreach (var data in datas)
			{
				switch (data.State)
				{
					case EntityState.Added:
						data.Entity.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, azerbaijanTimeZone);
						break;
					case EntityState.Modified:
						data.Entity.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, azerbaijanTimeZone);
						break;
					default:
						break;
				}
			}

			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
