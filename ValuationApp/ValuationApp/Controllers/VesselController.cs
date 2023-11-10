using Microsoft.AspNetCore.Mvc;
using ValuationApp.Services.Contract;
using ValuationApp.ValuationDto;

namespace ValuationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VesselController : ControllerBase
    {
        public readonly IVesselService _vesselService;

        public VesselController(IVesselService vesselService)
        {
            _vesselService = vesselService;
        }

        [HttpGet]
        public async Task<ActionResult<VesselDto>> GetById(int id)
        {
            return await _vesselService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] VesselDto vessel)
        {
            return await _vesselService.Create(vessel);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] VesselDto vessel)
        {
            return await _vesselService.Update(vessel);
        } 
    }
}