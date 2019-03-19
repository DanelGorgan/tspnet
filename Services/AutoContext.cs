using Microsoft.EntityFrameworkCore;
using ModelDesignFirst_L1;

namespace Persistence
{
    public class AutoContext : DbContext
    {
        public DbSet<Auto> Autoes { get; set; }

        public DbSet<Client> Clienti { get; set; }

        public DbSet<Comanda> Comenzi { get; set; }

        public DbSet<DetaliuComanda> DetaliuComenzi { get; set; }

        public DbSet<Imagine> Imagini { get; set; }

        public DbSet<Material> Materiale { get; set; }

        public DbSet<Mecanic> Mecanici { get; set; }

        public DbSet<Operatie> Operatii { get; set; }

        public DbSet<Sasiu> Sasiuri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DGORGAN-L; Database = EMS; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>()
                .HasOne(a => a.Comandas)
                .WithOne(c => c.Auto)
                .HasForeignKey<Comanda>(c => c.Auto_Id);

            modelBuilder.Entity<Auto>()
                 .HasOne(a => a.Sasiu)
                 .WithOne(s => s.Autoes)
                 .HasForeignKey<Sasiu>(s => s.Auto_Id);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Autoes)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.Client_Id);

            modelBuilder.Entity<Client>()
                .HasOne(cl => cl.Comandas)
                .WithOne(c => c.Client)
                .HasForeignKey<Comanda>(c => c.Client_Id);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.DetaliuComandas)
                .WithOne(dc => dc.Comanda)
                .HasForeignKey<DetaliuComanda>(dc => dc.Comanda_Id);

            modelBuilder.Entity<DetaliuComanda>()
                .HasMany(dc => dc.Materials)
                .WithOne(m => m.DetaliuComanda)
                .HasForeignKey(m => m.DetaliuComanda_Id);

            modelBuilder.Entity<DetaliuComanda>()
                .HasMany(dc => dc.Mecanics)
                .WithOne(mc => mc.DetaliuComanda)
                .HasForeignKey(mc => mc.DetaliuComanda_Id);

            modelBuilder.Entity<DetaliuComanda>()
                .HasMany(dc => dc.Operaties)
                .WithOne(o => o.DetaliuComanda)
                .HasForeignKey(o => o.DetaliuComanda_Id);

            modelBuilder.Entity<DetaliuComanda>()
                .HasMany(dc => dc.Imagines)
                .WithOne(i => i.DetaliuComanda)
                .HasForeignKey(i => i.DetaliuComanda_Id);
        }

    }
}
