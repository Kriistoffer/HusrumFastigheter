namespace OOAPInlämningsuppgift2.Entities
{
    public class Tag
    {
        public Tag()
        {
            Doors = new List<Door>();
        }
        public string Id { get; set; }
        public string Designation { get; set; }
        public ICollection<Door> Doors { get; set; }
    }
}
