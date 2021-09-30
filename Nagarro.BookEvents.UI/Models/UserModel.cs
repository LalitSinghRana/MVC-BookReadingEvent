using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nagarro.BookEvents.UI
{
    public class UserModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(20, ErrorMessage =
            "Name should be less than or equal to 20 characters.")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                    ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public string Role { get; set; }
    }
}
