using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using AdvancedDatabase_Lab4.Models;

namespace AdvancedDatabase_Lab4.Data
{
    public class HotelMVCAppContext : DbContext
    {
        public HotelMVCAppContext(DbContextOptions<HotelMVCAppContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
    }
}
