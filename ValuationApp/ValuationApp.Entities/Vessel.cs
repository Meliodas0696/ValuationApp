namespace ValuationApp.Entities
{
    public class Vessel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Imo { get; set; }

        public DateTime Year { get; set; }

        public string Description { get; set; }
    }
}