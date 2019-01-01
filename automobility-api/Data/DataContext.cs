using automobility_api.Features.Auth.Models;
using automobility_api.Features.Parking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace automobility_api.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ParkingSpace> ParkingSpaces {get; set;} 
    }
}