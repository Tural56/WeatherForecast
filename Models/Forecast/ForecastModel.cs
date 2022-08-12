

namespace WeatherSite.Models.Forecast
{
    public class ForecastModel
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }

    }
}
