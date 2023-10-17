using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValuationApp.DataAccess;
using ValuationApp.Entities;

namespace ValuationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VesselController : ControllerBase
    {
        public readonly ValauatioDbContext _valuationContext;

        public VesselController(ValauatioDbContext valauatioContext)
        {
            _valuationContext = valauatioContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vessel>>> GetAll()
        {
            return await _valuationContext.Vessels.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]Vessel vessel)
        {
            await _valuationContext.Vessels.AddAsync(vessel);
            await _valuationContext.SaveChangesAsync();
            return vessel.Id;
        }
    }
}