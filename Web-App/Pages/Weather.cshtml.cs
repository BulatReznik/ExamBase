using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Web_App.Models;

namespace Web_App.Pages
{
    public class WeatherModel : PageModel
    {
        public List<Weather> WeatherList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://vm.nathoro.ru/")
            };

            var result = await client.GetAsync("weather?lattitude=54.3&longitude=48.8");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                WeatherList = JsonSerializer.Deserialize<List<Weather>>(content);

                foreach (var weather in WeatherList)
                {
                    weather.dateString = weather.date.ToString("yyyy MMMM dd hh:mm");
                }
            }

            return Page();
        }
    }
}
