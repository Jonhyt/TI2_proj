using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using TI2_proj.Models;

namespace TI2_proj.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class MusicasDB : IdentityDbContext<ApplicationUser>
    {
        public MusicasDB()
          : base("MusicasDBConnection", throwIfV1Schema: false) {
        }
        static MusicasDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<MusicasDB>(new ApplicationDbInitializer());
        }

        // ainda outro construtor
        public static MusicasDB Create()
        {
            return new MusicasDB();
        }

        //Representar as tabelas
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<ArtistaMusica> ArtistaMusica { get; set; }
        public virtual DbSet<Bandas> Bandas { get; set; }
        public virtual DbSet<CompositorMusica> CompositorMusica { get; set; }
        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Mood> Mood { get; set; }
        public virtual DbSet<MusicaGenero> MusicaGenero { get; set; }
        public virtual DbSet<MusicaMood> MusicaMood { get; set; }
        public virtual DbSet<Musicas> Musicas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // não podemos usar a chave seguinte, nesta geração de tabelas
            // por causa das tabelas do Identity (gestão de utilizadores)
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}