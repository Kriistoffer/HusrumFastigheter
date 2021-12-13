using System.ComponentModel.DataAnnotations;

namespace OOAPInlämningsuppgift2.Entities
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string TagId { get; set; }

    }
}
