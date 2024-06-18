using kurikulum.Controllers.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurikulum.Models.Entity
{
    public class Lesson:BaseEntity
    {

        public string Title { get; set; }   

        public string Video { get; set; }

        [NotMapped]

        public IFormFile? FormFile { get; set; }
        public SubCategory? SubCategory { get; set; }

        public Guid SubCategoryId { get; set; }
    }
}
