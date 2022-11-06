using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models {
    public class Student {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        //[DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
