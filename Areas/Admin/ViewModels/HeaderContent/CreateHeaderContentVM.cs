using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Areas.Admin.ViewModels.HeaderContent
{
	public class CreateHeaderContentVM
	{
		
		public string? Icon { get; set; }

		[Required]
		public string? Title { get; set; }
		[Required]
		public string? Description { get; set; }

		[Required]
		[NotMapped]

		public IFormFile FormFile { get; set; }
	}
}
