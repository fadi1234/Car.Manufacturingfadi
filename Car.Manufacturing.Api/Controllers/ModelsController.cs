using Car.Manufacturing.Core.Interfaces;
using Car.Manufacturing.Core.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace Car.Manufacturing.Api.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IBaseRepository<CarMake> _carMakeRepository;
        private readonly IApiRepository _apiRepository;

        public ModelsController(IBaseRepository<CarMake> carMakeRepository, IApiRepository apiRepository)
        {
            _carMakeRepository = carMakeRepository;
            _apiRepository = apiRepository;
        }

        /// <summary>
        /// This Api working to get model makes by year model and make name
        /// </summary>
        /// <param name="modelyear"></param>
        /// <param name="make"></param>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetModels([FromQuery] int modelyear, [FromQuery] string make)
        {
            try
            {
                // Read and convert CSV data to List<CarModel>
                var carModels = _carMakeRepository.ReadCsvFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads"), "CarMake.csv"));

                long MakeID = 0;
                foreach (var record in carModels)
                {
                    if (record.make_name == make)
                        MakeID = record.make_id;

                }
                if (MakeID == 0)
                {
                    return BadRequest("There are no data");
                }

                var ApiUrl = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{MakeID}/modelyear/{modelyear}?format=json";

                // Call Api to get models
                var Response = Task.Run(() => _apiRepository.GetURL(new Uri(ApiUrl)));
                Response.Wait();

                if (!string.IsNullOrEmpty(Response.Result) && Response.IsCompleted)
                {
                    var result = new
                    {
                        Models = JsonConvert.DeserializeObject<ModelsForMakeIdYear>(Response.Result).Results.Select(c => c.Model_Name).Distinct().ToList()
                    };

                    return Ok(JsonConvert.SerializeObject(result, Formatting.Indented));

                }
                return BadRequest("There are no data");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
