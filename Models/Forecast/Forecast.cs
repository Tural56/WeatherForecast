using Newtonsoft.Json;


namespace WeatherSite.Models.Forecast
{
    public class Forecast
    {
        public List<Forecastday> forecastday { get; set; }
    }
}
