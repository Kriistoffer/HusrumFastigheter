namespace OOAPInlämningsuppgift2.Entities
{
    public class Tenant
    {
        //public int Id { get; set; }
        public string ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TagId { get; set; }
        public Tenant(string apartmentNumber, string firstName, string lastName, string tagId)
        {
            //Id = id;
            ApartmentNumber = apartmentNumber;
            FirstName = firstName;
            LastName = lastName;
            TagId = tagId;
        }
    }
}
