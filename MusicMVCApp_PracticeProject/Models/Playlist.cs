using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicMVCApp_PracticeProject.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public HashSet<Song> Songs { get; set; }

    }
}
