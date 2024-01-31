using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Models;

namespace smartlivestock.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainingvideo> Trainingvideo { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }
        public object UserInformations { get; internal set; }
    }
}
