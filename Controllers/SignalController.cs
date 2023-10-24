using Core.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIS.RealTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {

        private readonly AISDbContext _context;
        public SignalController(AISDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Signal( string? Device_ID, string? Customer_ID, decimal? SCS, decimal? pH_Value,
            decimal? Soil_humidity, decimal? Soil_Temperature, decimal? Soil_Conductivity, decimal? Nitrogen ,decimal? Phosphorus 
            ,decimal? Potassioum ,bool? Solenoid_State)
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
            signal.Solenoid_State = (bool)Solenoid_State;

            _context.SoilCells.Add(signal);
            await _context.SaveChangesAsync();

            
            return Ok("Saved");
        }
    }
}
