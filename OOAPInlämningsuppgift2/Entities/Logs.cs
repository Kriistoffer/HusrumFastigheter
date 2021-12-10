using System.ComponentModel.DataAnnotations;

namespace OOAPInlämningsuppgift2.Entities
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Door Door { get; set; }
        public Tenant Tenant { get; set; }
        public Event Event { get; set; }

    }
}
