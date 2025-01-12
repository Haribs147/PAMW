using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LAB1.Pages
{
    public class Zadanie3Model : PageModel
    {
        
        [BindProperty]
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [MinLength(6, ErrorMessage = "Hasło musi mieć co najmniej 6 znaków.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[0-9])(?=.*[a-z]).{6,}$", 
            ErrorMessage = "Hasło musi zawierać co najmniej jedną dużą literę, jedną małą literę, jeden znak specjalny i jedną cyfrę.")]
        public string Password { get; set; } = string.Empty;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Only if the data is valid, assign it to ViewData
                ViewData["Username"] = Username;
                ViewData["Email"] = Email;
                ViewData["Password"] = Password;
            }
        }
    }
}
