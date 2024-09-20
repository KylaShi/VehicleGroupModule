using Microsoft.AspNetCore.Mvc;
using VehicleModule.Models;
using VehicleModule;

namespace VehicleModuleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var contextFactory = new EFCoreDBContextFactory();
            var dbContext = contextFactory.CreateDbContext(new string[] { });
            var vehicle = dbContext.VehicleGroups;

            return Ok(vehicle.ToList());
        }

        [HttpPost]
        public ActionResult Create([FromBody] VehicleGroup vehicleGroup)
        {
            try
            {
                var contextFactory = new EFCoreDBContextFactory();
                var dbContext = contextFactory.CreateDbContext(new string[] { });
                dbContext.VehicleGroups.Add(vehicleGroup);
                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] VehicleGroup vehicleGroup)
        {
            try
            {
                var contextFactory = new EFCoreDBContextFactory();
                var dbContext = contextFactory.CreateDbContext(new string[] { });
                dbContext.VehicleGroups.Update(vehicleGroup);
                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
