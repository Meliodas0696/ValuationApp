namespace ValuationApp.DataAccess.Repository
{
    public class BaseRepository
    {
        public readonly ValauatioDbContext _valuationContext;

        public BaseRepository(ValauatioDbContext valuationContext)
        {
            _valuationContext = valuationContext;
        }
    }
}
