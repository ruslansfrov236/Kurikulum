using System.ComponentModel.DataAnnotations.Schema;
using kurikulum.Controllers.Customers;

namespace kurikulum.Models.Entity
{
    public class Header:BaseEntity
	{
		public string?  Photo { get; set; }

		[NotMapped]

		public IFormFile? FormFile { get; set; }	
	}
}
