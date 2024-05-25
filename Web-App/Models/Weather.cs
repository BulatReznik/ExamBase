namespace Web_App.Models
{
    public class Weather
    {
        public string location { get; set; }
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public double windSpeed { get; set; }
        public double humidity { get; set; }
        public string dateString { get; set; }
    }
}
