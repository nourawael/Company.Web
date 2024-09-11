using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]

        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{6,}$" , ErrorMessage ="invalid password format")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare(nameof(Password),ErrorMessage ="Confirm password does not match password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Required")]
        public bool IsAgree { get; set; }
    }
}
