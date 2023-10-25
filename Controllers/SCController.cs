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

        /*
         * Agri/SC/States 
         * Device_ID=SC_02
         * &Customer_ID=MP
         * &SCS=0.00
         * &pH_Value=3.56
         * &Soil_humidity=22.60
         * &Soil_Temperature=25.60
         * &Soil_Conductivity=245.00
         * &Nitrogen=17.00
         * &Phosphorus=26.00
         * &Potassioum=52.00
         * &Solenoid_State=0
         * 80 - 105.35.189.1 - - 404 0 2 69
         
         
         
         
         */





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
