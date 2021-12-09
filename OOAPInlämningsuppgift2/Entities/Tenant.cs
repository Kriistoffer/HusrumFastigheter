namespace OOAPInlämningsuppgift2.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Tag Tag { get; set; }
    }
}
