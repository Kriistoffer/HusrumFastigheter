﻿namespace OOAPInlämningsuppgift2.Entities
{
    public class Door
    {
        public Door(string designation, string tagId)
        {
            Tags = new List<Tag>();
            designation = Designation;
            tagId = tagId;
        }

        public string Designation { get; set; }
        public string TagId { get; set; }
        public ICollection<Tag> Tags { get; set; }

        
    }
}
