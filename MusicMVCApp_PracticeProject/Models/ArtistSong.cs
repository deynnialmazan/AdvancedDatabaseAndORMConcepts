using System.ComponentModel.DataAnnotations;

namespace MusicMVCApp_PracticeProject.Models
{
    public class ArtistSong
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public Song Song { get; set; } 
        public int SongId { get; set;}

    }
}
