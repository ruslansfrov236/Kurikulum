using kurikulum.Controllers.Customers;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace kurikulum.Models.Entity
{
    public class Collaboration:BaseEntity
    {

        public string FullName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string WorkEducation { get; set; }

        [MaxLength(50)]
        public byte Seniority { get; set; }

        public string Subject { get; set; }
    }
}
