using System.ComponentModel.DataAnnotations;

namespace MusicMVCApp_PracticeProject.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [Range(1940, 2023)]
        public int Year { get; set; }

        public HashSet<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
