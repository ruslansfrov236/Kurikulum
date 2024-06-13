using System.ComponentModel.DataAnnotations.Schema;
using kurikulum.Controllers.Customers;

namespace kurikulum.Models.Entity
{
    public class HeaderContent:BaseEntity
	{
		public string? Icon { get; set; }	

		public string? Title { get; set; }

		public string? Description { get; set; }

		[NotMapped]

		public IFormFile FormFile { get; set; }
	}
}
