using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Areas.Admin.ViewModels.Header
{
	public class UpdateHeaderVM
	{
		public string Id { get; set; }
		public string? Photo { get; set; }

		[NotMapped]

		public IFormFile? FormFile { get; set; }
	}
}
