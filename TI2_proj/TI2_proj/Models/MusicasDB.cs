using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TI2_proj.Models
{
    public class MusicasDB : DbContext
    {
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
        
        public MusicasDB() : base("MusicasDBConnection") { }

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