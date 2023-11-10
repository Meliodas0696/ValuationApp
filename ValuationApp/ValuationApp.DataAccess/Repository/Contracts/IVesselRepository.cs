using ValuationApp.Entities;

namespace ValuationApp.DataAccess.Repository.Contracts
{
    public interface IVesselRepository
    {
        Task<Vessel> GetById(int id);
        Task<Vessel> GetByImo(string imo);
        Task<List<Vessel>> GetAll();
        Task<int> Create(Vessel vessel);
        Task<int> Update(Vessel vessel);
    }
}
