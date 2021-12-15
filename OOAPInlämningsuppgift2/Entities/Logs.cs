namespace OOAPInlämningsuppgift2.Entities
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string TagId { get; set; }

        public Logs( DateTime dateTime, string designation, string firstName, string lastName, string code, string description, string tagId)
        {
            DateTime = dateTime;
            Designation = designation;
            FirstName = firstName;
            LastName = lastName;
            Code = code;
            Description = description;
            TagId = tagId;
        }
    }
}
