using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group = Web_App.Models.Group;

namespace Web_App.Pages
{
    public class GroupsModel : PageModel
    {
        public List<Group> Groups;

        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://vm.nathoro.ru/")
            };

            var result = await client.GetAsync("timetable/groups");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Groups = JsonSerializer.Deserialize<List<Group>>(content);
            }

            return Page();
        }
    }
}