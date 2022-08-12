namespace WeatherSite.Models.Forecast
{
    public class Current
    {
        public string? last_updated { get; set; }

        public float temp_c { get; set; }

        public float temp_f { get; set; }

        public float wind_kph { get; set; }

        public float wind_mph { get; set; }

        public int humidity { get; set; }

        public float vis_km { get; set; }



    }
}
