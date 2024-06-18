using kurikulum.Controllers.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Models.Entity
{
    public class HeaderDetails:BaseEntity
    {
        public string? Title { get; set; }   

        public string? Description { get; set; }

        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? FormFile { get; set; } 
    }
}
