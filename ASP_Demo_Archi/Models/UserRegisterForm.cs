using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_Archi.Models
{
    public class UserRegisterForm
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", 
            ErrorMessage = "Doit contenir les trucs de base ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Ne correspond au password entré")]
        public string ConfirmPassword { get; set;}

    }
}
