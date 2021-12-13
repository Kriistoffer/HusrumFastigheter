namespace OOAPInlämningsuppgift2.Entities
{
    public class Tag
    {
        public Tag(string id, string designation)
        {
            Doors = new List<Door>();
            Id = id;
            Designation = designation;
        }
        public string Id { get; set; }
        public string Designation { get; set; }
        public ICollection<Door> Doors { get; set; }
    }
}
