using System.ComponentModel.DataAnnotations;
namespace Task.Models
{
    public class Register
    {
     [Required]
     [RegularExpression(@"^(?!.*([A-Za-z])\1)[A-Za-z\s]+$",ErrorMessage ="Username is not valid")]
     public string? FullName{get;set;}
      [Required]
        [DataType(DataType.EmailAddress)]
        public string? mailid { get; set; }
        [Required]
        [RegularExpression("^[6789][0-9]{9}$",ErrorMessage ="Mobile number is in incorrect format" )]
        public string? phonenumber { get; set; }
          [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must in between 8-15")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contains atleast 1 Lowercase, 1 Uppercase, 1 specialcase and 1 Numeric value")]
        public string? Password { get; set; }
         [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be same")]
        public string? ConfirmPassword { get; set; }
    }
}