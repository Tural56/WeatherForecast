using System.Text.Json;

namespace WeatherSite.Models.Forecast
{
    public class ForecastDeserialize
    {
        
        public static async Task<ForecastModel> deserialize(string name)
        {
            string key = "17c7a31e5a68489797a195744220808";


            string request = $"http://api.weatherapi.com/v1/forecast.json?key={key}&q={name}&days=7&aqi=no&alerts=no";
            HttpClient client = new HttpClient();
            var res = await client.GetStringAsync(request);
            

            


            ForecastModel model = JsonSerializer.Deserialize<ForecastModel>(res);
            return model;
        }
    }
}
