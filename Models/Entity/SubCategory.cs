using kurikulum.Controllers.Customers;

namespace kurikulum.Models.Entity
{
    public class SubCategory:BaseEntity
    {
        public string Name { get; set; }    

        public Category Category { get; set; }  
    }
}
