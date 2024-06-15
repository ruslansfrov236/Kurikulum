using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace kurikulum.Areas.Admin.ViewModels.Header
{
	public class CreateHeaderVM
	{
		public string? Photo { get; set; }

		[Required]
		[NotMapped]

		public IFormFile? FormFile { get; set; }
	}
}
