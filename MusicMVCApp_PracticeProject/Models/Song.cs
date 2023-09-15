using System.ComponentModel.DataAnnotations;

namespace MusicMVCApp_PracticeProject.Models
{
    public class Song
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Length in seconds")]
        public int Lenght { get; set; }

        [Required]
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        

        [Required]
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; } 

        public HashSet<Artist> ArtistSongs { get; set; } = new HashSet<Artist>(); 
    }
}
