using MusicMVCApp_PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicMVCApp_PracticeProject.Data
{
    public class MusicMVCAppContext : DbContext
    {
        public MusicMVCAppContext(DbContextOptions<MusicMVCAppContext> options)
           : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<ArtistSong> ArtistSong { get; set; } = default!;       
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Playlist> Playlist { get; set; } = default!;

    }
}
