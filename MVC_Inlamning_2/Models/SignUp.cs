using System.ComponentModel.DataAnnotations;

namespace MVC_Inlamning_2.Models
{
    public class SignUp
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain a minium of 2 characters", MinimumLength = 2)]
        [RegularExpression(@"^([a-öA-Ö]+?)([-][a-öA-Ö]+)*?$", ErrorMessage = "Must be a valid first name")]
        public string FirstName { get; set; } = "";

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain a minium of 2 characters", MinimumLength = 2)]
        [RegularExpression(@"^([a-öA-Ö]+?)([-\s][a-öA-Ö]+)*?$", ErrorMessage = "Must be a valid last name")]
        public string LastName { get; set; } = "";

        [Display(Name = "Address")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain a minium of 2 characters", MinimumLength = 2)]
        [RegularExpression(@"^([a-öA-Ö]+?)([\s][0-9]+)*?$", ErrorMessage = "Must be a valid streetname")]
        public string Address { get; set; } = "";

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain 5 digits and a whitespace", MinimumLength = 5)]
        [RegularExpression(@"^\d{3}(\s\d{2})?$", ErrorMessage = "Must be a valid postal code (eg. 123 45)")]
        public string PostalCode { get; set; } = "";

        [Display(Name = "City")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain a minium of 2 characters", MinimumLength = 2)]
        [RegularExpression(@"^([a-öA-Ö]+?)([\s][a-öA-Ö]+)*?$", ErrorMessage = "Must be a valid name")]
        public string City { get; set; } = "";

        [Display(Name = "Country")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(256, ErrorMessage = "Must contain a minium of 2 characters", MinimumLength = 2)]
        [RegularExpression(@"^([a-öA-Ö]+?)([\s][a-öA-Ö]+)*?$", ErrorMessage = "Must be a valid name")]
        public string Country { get; set; } = "Sverige";

        [Display(Name = "Email")]
        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Must contain a valid email address")]
        public string Email { get; set; } = "";

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must meet the minimum requirements")]
        public string Password { get; set; } = "";

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This is a required field")]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = "";

        public string ErrorMessage { get; set; } = "";
        public string ReturnUrl { get; set; } = "/";
        public string RoleName { get; set; } = "user";
    }
}
