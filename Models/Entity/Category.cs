using kurikulum.Controllers.Customers;

namespace kurikulum.Models.Entity
{
	public class Category : BaseEntity
	{
		public string? Name { get; set; }

		public Guid SubQrupCategoryId { get; set; }
		public SubQrupCategory SubQrupCategory { get; set; }
	}
}
