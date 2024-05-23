using System.Collections.Generic;

namespace Web_App.Models
{
    public class Weather
    {
        public string product { get; set; }
        public string init { get; set; }
        public List<DataSeries> dataseries { get; set; }
    }

    public class DataSeries
    {
        public DateTime DateTime { get; set; }

        public int timepoint { get; set; }
        public int cloudcover { get; set; }
        public int seeing { get; set; }
        public int transparency { get; set; }
        public int liftedindex { get; set; }
        public int rh2m { get; set; }
        public WindInfo wind10m { get; set; }
        public int temp2m { get; set; }
        public string prec_type { get; set; }
    }

    public class WindInfo
    {
        public string direction { get; set; }
        public int speed { get; set; }
    }
}