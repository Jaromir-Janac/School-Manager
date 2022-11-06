using SchoolWebApp.Models;
using System.ComponentModel;

namespace SchoolWebApp.ViewModels {
    public class GradesVM {
        public int Id { get; set; }
        [DisplayName("Student's Name")]
        public int StudentId { get; set; }
        [DisplayName("Subject")]
        public int SubjectId { get; set; }
        public string What { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
    }
}
