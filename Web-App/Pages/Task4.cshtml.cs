using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Web_App.Pages
{
    public class Task4Model : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }
    }

    public class Login
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        public string Password { get; set; }
    }
}
