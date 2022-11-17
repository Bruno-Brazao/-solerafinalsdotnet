namespace hpels_mx.Models
{
    public class Claims
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }
        public DateTime Date { get; set; }
        public Vehicles Vehicle_id { get; set; }
    }
}
