using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAPInlamningsuppgift2.Entities
{
    // This is the entity for door
    public class Door
    {
        public int Id { get; set; }
        public string DoorDesignation { get; set; }

        public Door(string doorDesignation)
        {
            DoorDesignation = doorDesignation;
        }
    }
}
