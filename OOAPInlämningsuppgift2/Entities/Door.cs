namespace OOAPInlämningsuppgift2.Entities
{
    public class Door
    {
        public Door()
        {
            Tags = new List<Tag>();
        }
        public string Designation { get; set; }
        public ICollection<Tag> Tags { get; set; }

        
    }
}
