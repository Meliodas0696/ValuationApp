namespace ValuationApp.Entities
{
    public class Bundle
    {

        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Comment { get; set; }

        public List<Valuation> Valuations { get; set; }
    }
}
