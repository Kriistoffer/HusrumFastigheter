namespace OOAPInlämningsuppgift2.Entities
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Event Event { get; set; }
        public Tenant Tenant { get; set; }
        public Door Door { get; set; }
    }
}
