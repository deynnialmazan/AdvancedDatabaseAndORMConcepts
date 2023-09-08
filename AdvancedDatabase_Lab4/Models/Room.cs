using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabase_Lab4.Models
{
    public class Room
    {
        [Key]
        [DisplayName("Room number")]
        public int RoomNumber { get; set; }

        [Range(1, 6)]
        [DisplayName("Room capacity")]
        public int Capacity { get; set; }

        [DisplayName("Room section")]
        public RoomSection Section { get; set; }

    }
}

public enum RoomSection
{
    First,
    Second,
    Third
}
