using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.RegularExpressions;
using Web_App.Models;

namespace Web_App.Pages
{
    public class RoomsModel : PageModel
    {
        public List<Room> Rooms;

        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://vm.nathoro.ru/")
            };

            var result = await client.GetAsync("timetable/rooms");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Rooms = JsonSerializer.Deserialize<List<Room>>(content);
            }

            return Page();
        }
    }
}
