using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS_API2022.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Target Date")]
        public DateTime TargetDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Tag { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
    }
}
