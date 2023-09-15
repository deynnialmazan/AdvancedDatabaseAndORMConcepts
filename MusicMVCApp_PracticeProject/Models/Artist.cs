using System.ComponentModel.DataAnnotations;

namespace MusicMVCApp_PracticeProject.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public HashSet<ArtistSong> ArtistSongs { get; set; } = new HashSet<ArtistSong>();
    }
}
