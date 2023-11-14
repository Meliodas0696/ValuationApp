
using ValuationApp.ValuationDto;

namespace ValuationApp.Services.Contract
{
    public interface IVesselService
    {
        Task<VesselDto> GetById(int id);
        Task<List<VesselDto>> GetAll();

        Task<int> Create(VesselDto vessel);

        Task<int> Update(VesselDto vessel);
    }
}