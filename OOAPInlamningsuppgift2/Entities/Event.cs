namespace OOAPInlamningsuppgift2.Entities
{
    // This is the entity for Event
    public class Event
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Event(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
