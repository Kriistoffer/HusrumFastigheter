using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAPInlämningsuppgift2.Entities
{
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
