//Email - Step 5
//Add a new class to Models - 'ContactViewModel' 
//Add a using statement 
//Add properties and validation 
using System.ComponentModel.DataAnnotations;

namespace SATScheduling.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Must provide a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Must provide an email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "* Email address must be formatted correctly (you@domain.com)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Must provide a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Must provide a message")]
        [DataType(DataType.MultilineText)]//ensures we will generate a multi-line textbox (<textarea>)
        public string Message { get; set; }
    }
}
