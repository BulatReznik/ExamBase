using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Web_App.Models;

namespace Web_App.Pages
{
    public class WeatherModel : PageModel
    {
        public Weather Weather { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://www.7timer.info/")
            };

            var lon = "113.17";
            var lat = "23.09";
            var product = "astro";
            var output = "json";

            var url = $"bin/api.pl?lon={lon}&lat={lat}&product={product}&output={output}";

            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                Weather = JsonSerializer.Deserialize<Weather>(content);

                // Форматируем каждую дату и время в объекте Weather
                foreach (var dataSeries in Weather.dataseries)
                {
                    dataSeries.DateTime = DateTime.Today.AddHours(dataSeries.timepoint);
                }
            }

            return Page();
        }
    }
}