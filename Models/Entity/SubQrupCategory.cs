using kurikulum.Controllers.Customers;

namespace kurikulum.Models.Entity
{
	public class SubQrupCategory:BaseEntity
	{
		public string Name { get; set;  }

		public Category Category { get; set; }
		public Guid SubCategoryId { get; set; }

		public ICollection<SubCategory>? SubCategories { get; set; }
	}
}
