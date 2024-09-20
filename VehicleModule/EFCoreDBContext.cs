using Microsoft.EntityFrameworkCore;
using VehicleModule.Models;

namespace VehicleModule
{
    public class EFCoreDBContext: DbContext
    {
        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {
        }

        public EFCoreDBContext()
        {

        }

        public DbSet<VehicleGroup> VehicleGroups { get; set; }
    }
}
