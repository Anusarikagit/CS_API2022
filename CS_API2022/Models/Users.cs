using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS_API2022.Models
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Employee Id")]
        public int UserId { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
