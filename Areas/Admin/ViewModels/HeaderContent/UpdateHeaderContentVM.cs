using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Areas.Admin.ViewModels.HeaderContent
{
	public class UpdateHeaderContentVM
	{
		public string Id { get; set; }
		public string? Icon { get; set; }
		[Required]
		public string? Title { get; set; }
		[Required]
		public string? Description { get; set; }

		[NotMapped]

		public IFormFile? FormFile { get; set; }
	}
}
