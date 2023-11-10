namespace ValuationApp.Entities
{
    public class Valuation
    {
        public int Id { get; set; }

        public double EstimatedValue { get; set; }

        public string Comment { get; set; }

        public int VesselId { get; set; }

        public Vessel Vessel { get; set; }

        public int BundleId { get; set; }

        public Bundle Bundle { get; set; }
    }
}
