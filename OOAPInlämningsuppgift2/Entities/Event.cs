namespace OOAPInlämningsuppgift2.Entities
{
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
