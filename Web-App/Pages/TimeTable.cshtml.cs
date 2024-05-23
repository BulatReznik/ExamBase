using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Web_App.Models;

namespace Web_App.Pages
{
    public class TimeTableModel : PageModel
    {
        public List<TimeTable> TimeTables { get; set; }

        public string GroupName { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GroupName = "ПИбд-41";
                var client = new HttpClient()
                {
                    BaseAddress = new Uri("https://vm.nathoro.ru/")
                };

                var encodedGroupName = Uri.EscapeDataString(GroupName);
                var url = $"timetable/by-group/{encodedGroupName}";

                var result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    TimeTables = JsonSerializer.Deserialize<List<TimeTable>>(content);
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Ошибка при запросе: {result.ReasonPhrase}");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Исключение: {ex.Message}");
                return Page();
            }
        }

    }
}
