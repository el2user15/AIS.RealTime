using Core.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Agri.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SCController : ControllerBase
    {

        private readonly AISDbContext _context;
        public SCController(AISDbContext context)
        {
            _context = context;
        }

        [HttpGet("States")]
        public async Task<IActionResult> States( string? Device_ID, string? Customer_ID, decimal? SCS, decimal? pH_Value,
            decimal? Soil_humidity, decimal? Soil_Temperature, decimal? Soil_Conductivity, decimal? Nitrogen ,decimal? Phosphorus 
            ,decimal? Potassioum ,int? Solenoid_State)
        {
            var signal = new SoilCell();

            signal.Device_ID = Device_ID;
            signal.Customer_ID = Customer_ID;
            signal.SCS = SCS;
            signal.pH_Value = pH_Value;
            signal.Soil_humidity = Soil_humidity;
            signal.Soil_Temperature = Soil_Temperature;
            signal.Soil_Conductivity = Soil_Conductivity;
            signal.Nitrogen = Nitrogen;
            signal.Phosphorus = Phosphorus;
            signal.Potassioum = Potassioum;
            signal.Solenoid_State = Solenoid_State;
            signal.TimeStamp = DateTime.UtcNow;

            _context.SoilCells.Add(signal);
            await _context.SaveChangesAsync();

            
            return Ok("Saved");
        }

    }
}
