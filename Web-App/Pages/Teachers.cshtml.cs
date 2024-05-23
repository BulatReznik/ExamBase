using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Web_App.Models;

namespace Web_App.Pages
{
    public class TeachersModel : PageModel
    {
        public List<Teacher> Teachers;

        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://vm.nathoro.ru/")
            };

            var result = await client.GetAsync("timetable/teachers");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Teachers = JsonSerializer.Deserialize<List<Teacher>>(content);
            }

            return Page();
        }

    }
}
