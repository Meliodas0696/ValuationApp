using Microsoft.EntityFrameworkCore;
using ValuationApp.DataAccess.Repository.Contracts;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess.Repository
{
    public class VesselRepository : BaseRepository, IVesselRepository
    {
        public VesselRepository(ValauatioDbContext valuationContext) : base(valuationContext)
        {
        }

        public async Task<int> Create(Vessel vessel)
        {
            await _valuationContext.Vessels.AddAsync(vessel);
            await _valuationContext.SaveChangesAsync();
            return vessel.Id;
        }

        public async Task<List<Vessel>> GetAll()
        {
            return await _valuationContext.Vessels.ToListAsync();
        }

        public async Task<Vessel> GetById(int id)
        {
            return await _valuationContext.Vessels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vessel> GetByImo(string imo)
        {
            return await _valuationContext.Vessels.FirstOrDefaultAsync(x => x.Imo == imo);
        }
    }
}
