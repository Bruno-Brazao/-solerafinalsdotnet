namespace hpels_mx.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Owners Owner_id { get; set; }
        public ICollection<Claims> Claims { get; set; }
    }
}
