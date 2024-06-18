using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Areas.Admin.ViewModels.HeaderDetails
{
    public class CreateHeaderDetailsVM
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Photo { get; set; }
        [Required]
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
