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
        [Required(ErrorMessage = "��� �����������")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "������ ����������")]
        [MinLength(6, ErrorMessage = "������ ������ ��������� �� ����� 6 ��������")]
        public string Password { get; set; }
    }
}
