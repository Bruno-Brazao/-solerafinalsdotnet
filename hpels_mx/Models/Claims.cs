namespace hpels_mx.Models
{
    public class Claims
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

        public int VehicleId { get; set; }
        public Vehicles? Vehicle { get; set; }
    }
}
