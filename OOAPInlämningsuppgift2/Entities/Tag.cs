namespace OOAPInlämningsuppgift2.Entities
{
    public class Tag
    {
        public Tag(string id)
        {
            Doors = new List<Door>();
            Id = id;
        }
        public string Id { get; set; }
        public ICollection<Door> Doors { get; set; }
    }
}
