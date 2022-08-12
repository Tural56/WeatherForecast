using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeatherSite.Models.Forecast;

namespace WeatherSite.Controllers
{
    public class ForecastController : Controller
    {

        public IMemoryCache _memoryCache;

        

        public ForecastController(IMemoryCache cache)
        {
            _memoryCache = cache;

        }
        
        [HttpGet]
        public async Task<ActionResult> Search()
        {
            if (_memoryCache.Get("Object") != null)
            {

                ForecastModel forecast = (ForecastModel)_memoryCache.Get("Object");
                if (forecast.current != null & forecast.forecast != null & forecast.location != null)
                {
                    return View(forecast);
                }
                return View();

            }
            else
            {
                ForecastModel forecast = new ForecastModel();
                forecast = await ForecastDeserialize.deserialize("London");
                return View(forecast);
            }
            

        }

        [HttpPost]
        public async Task<ActionResult> Search(string name)
        {
            ForecastModel forecastModel = new ForecastModel();
            forecastModel = await ForecastDeserialize.deserialize(name);
            
            if (forecastModel.current != null & forecastModel.forecast != null & forecastModel.location != null)
            {
                _memoryCache.Set("Object", forecastModel);

                return RedirectToAction("Search");
            }
            else
            {
                forecastModel = await ForecastDeserialize.deserialize("London");
                _memoryCache.Set("Object", forecastModel);
                return RedirectToAction("Search");
            }
            
            
                
            
            

            
        }
    }
}
