using Asignaturas.Models;
using Microsoft.EntityFrameworkCore;

namespace Asignaturas
{
    public class AsignaturesContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<AsignatureUser> AsignatureUsers { get; set; }

        public AsignaturesContext(DbContextOptions<AsignaturesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignatureUser>(asignatureUser =>
            {
                asignatureUser.ToTable("AsignatureUser");
                asignatureUser.HasKey(x => x.AsignatureUserId);
                asignatureUser.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
                asignatureUser.Property(x => x.NameAsignature).IsRequired().HasMaxLength(50);
                asignatureUser.Property(x => x.AreaTypes);
                asignatureUser.Property(x => x.CreationDate);
                asignatureUser.Ignore(x => x.Detail);
            });

            modelBuilder.Entity<Models.User>(user =>
            {
                user.ToTable("User");
                user.HasKey(x => x.UserId);
                user.Property(x => x.Name).IsRequired().HasMaxLength(50);
                user.Property(x => x.Email).IsRequired().HasMaxLength(100);
                user.Property(x => x.IdentificationType);
                user.Property(x => x.IdentificationNumber);
                user.Property(x => x.CreationDate);
            });
        }
    }
}
