using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OOAPInlamningsuppgift2.Entities
{
    // This is the entity for Tenant
    public class Tenant
    {
        public int Id { get; set; }
        public string ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tag { get; set; }

        public Tenant(string apartmentNumber, string firstName, string lastName, string tag)
        {
            ApartmentNumber = apartmentNumber;
            FirstName = firstName;
            LastName = lastName;
            Tag = tag;
        }
    }
}
