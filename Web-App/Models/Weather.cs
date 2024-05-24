namespace Web_App.Models
{
    public class Weather
    {
        public string location { get; set; }
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public string name { get; set; }
        public string windSpeed { get; set; }
        public string humidity { get; set; }
        public string dateString { get; set; }
    }
}
