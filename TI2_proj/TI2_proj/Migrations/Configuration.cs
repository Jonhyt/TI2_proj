using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TI2_proj.Models;

namespace TI2_proj.Migrations

{


    internal sealed class Configuration : DbMigrationsConfiguration<Models.MusicasDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.MusicasDB context)
        {
            //  This method will be called after migrating to the latest version.

            //----------------------------------------------------------
            //--------------------------------------------------------
            //Artistas a adicionar
            var artistas = new List<Artista>
            {
                new Artista { ArtistaID = 1, Nome = "The Beatles", Banda = true},
                new Artista { ArtistaID = 2, Nome = "John Lennon", Banda = false},
                new Artista { ArtistaID = 3, Nome = "Paul McCartney", Banda = false},
                new Artista { ArtistaID = 4, Nome = "Ringo Starr", Banda = false},
                new Artista { ArtistaID = 5, Nome = "George Harrison", Banda = false},
                new Artista { ArtistaID = 6, Nome = "Wings", Banda = true},
                new Artista { ArtistaID = 7, Nome = "Linda McCartney", Banda = false},
                new Artista { ArtistaID = 8, Nome = "Denny Laine", Banda = false},
                new Artista { ArtistaID = 9, Nome = "Henry McCullogh", Banda = false},
                new Artista { ArtistaID = 10, Nome = "Denny Seiwell", Banda = false},
                new Artista { ArtistaID = 11, Nome = "D.A.M.A", Banda = true},
                new Artista { ArtistaID = 12, Nome = "Francisco Pereira", Banda = false},
                new Artista { ArtistaID = 13, Nome = "Miguel Coimbra", Banda = false},
                new Artista { ArtistaID = 14, Nome = "Miguel Cristovinho", Banda = false},
                new Artista { ArtistaID = 15, Nome = "Shawn Mendes", Banda = false},
                new Artista { ArtistaID = 16, Nome = "Sia", Banda = false},
                new Artista { ArtistaID = 17, Nome = "Sean Paul", Banda = false},
                new Artista { ArtistaID = 18, Nome = "Pharrell Williams", Banda = false}

                //adicionar artistas
            };

            artistas.ForEach(art => context.Artista.AddOrUpdate(a => a.ArtistaID, art));
            context.SaveChanges();

            //Ligar artistas �s suas bandas
            var bandas = new List<Bandas>
            {
                new Bandas {BandaID=1,BandaFK=1,MembroFK=2 },
                new Bandas {BandaID=2,BandaFK=1,MembroFK=3 },
                new Bandas {BandaID=3,BandaFK=1,MembroFK=4 },
                new Bandas {BandaID=4,BandaFK=1,MembroFK=5 },
                new Bandas {BandaID=5,BandaFK=6,MembroFK=2 },
                new Bandas {BandaID=6,BandaFK=6,MembroFK=7 },
                new Bandas {BandaID=5,BandaFK=6,MembroFK=8 },
                new Bandas {BandaID=7,BandaFK=6,MembroFK=9 },
                new Bandas {BandaID=8,BandaFK=6,MembroFK=10 },
                new Bandas {BandaID=9,BandaFK=11,MembroFK=12 },
                new Bandas {BandaID=10,BandaFK=11,MembroFK=13 },
                new Bandas {BandaID=11,BandaFK=11,MembroFK=14 },

            };

            bandas.ForEach(b => context.Bandas.AddOrUpdate(bb => bb.BandaID, b));
            context.SaveChanges();

            //Adicionar editoras
            var editoras = new List<Editora>
            {
                new Editora {EditoraId=1,Nome="Apple" },
                new Editora {EditoraId=2,Nome="Parlophone" },
                new Editora {EditoraId=3,Nome="Sony Music Portugal" },
                new Editora {EditoraId=4,Nome="Universal" },
                new Editora {EditoraId=5,Nome="Inertia" },
                new Editora {EditoraId=6,Nome="i Am Other" }
            };

            editoras.ForEach(e => context.Editora.AddOrUpdate(ee => ee.EditoraId, e));
            context.SaveChanges();

            //Genero
            var generos = new List<Genero>
            {
                new Genero { GeneroID=1,Nome="Rock"},
                new Genero { GeneroID=2,Nome="Pop"},
                new Genero { GeneroID=3,Nome="Rap"},
                new Genero { GeneroID=3,Nome="R&B"}
            };

            generos.ForEach(g => context.Genero.AddOrUpdate(gg => gg.GeneroID,g));
            context.SaveChanges();

            //Album
            var albuns = new List<Album>
            {
                new Album { AlbumId = 1, Titulo = "Live and Let Die", AutorFK = 11, EditFK=1},
                new Album { AlbumId = 2, Titulo = "Revolver", AutorFK = 1, EditFK=2},
                new Album { AlbumId = 3, Titulo = "D�-me um segundo", AutorFK = 11, EditFK=3},
                new Album { AlbumId = 4, Titulo = "Illuminate", AutorFK = 15, EditFK=4},
                new Album { AlbumId = 5, Titulo = "This is Acting", AutorFK = 16, EditFK=5},
                new Album { AlbumId = 6, Titulo = "Girl", AutorFK = 16, EditFK=6}
            };

            albuns.ForEach(alb => context.Album.AddOrUpdate(a => a.AlbumId, alb));
            context.SaveChanges();

            //Mood
            var moods = new List<Mood>
            {
                new Mood { MoodID=1,Nome="Sadness"},
                new Mood { MoodID=2,Nome="Anxiety"},
                new Mood { MoodID=3,Nome="Exitement"},
                new Mood { MoodID=4,Nome="Happyness"},
                new Mood { MoodID=5,Nome="Melancholy"}
            };

            moods.ForEach(m => context.Mood.AddOrUpdate(mm => mm.MoodID,m));
            context.SaveChanges();

            //Adicionar musicas
            var musicas = new List<Musicas>
            {
                new Musicas {MusicaID=1,Titulo="Live and Let Die",Duracao=192,NumFaixa=1,AlbumFK=1},
                new Musicas {MusicaID=2,Titulo="Eleanor Rigby",Duracao=128,NumFaixa=2,AlbumFK=2},
                new Musicas {MusicaID=3,Titulo="Agora � tarde",Duracao=315,NumFaixa=3,AlbumFK=3},
                new Musicas {MusicaID=4,Titulo="Treat You Better",Duracao=187,NumFaixa=4,AlbumFK=4},
                new Musicas {MusicaID=5,Titulo="Cheap Thrills",Duracao=324,NumFaixa=6,AlbumFK=5},
                new Musicas {MusicaID=6,Titulo="Happy",Duracao=333,NumFaixa=5,AlbumFK=6},

            };

            musicas.ForEach(mm => context.Musicas.AddOrUpdate(m => m.MusicaID, mm));
            context.SaveChanges();


            //Ligar musicas aos seus compositores
            var compositores = new List<CompositorMusica>
            {
                new CompositorMusica {ComMusID=1, MusicaFK=1,CompositorFK=3},
                new CompositorMusica {ComMusID=2,MusicaFK=1,CompositorFK=7},
                new CompositorMusica {ComMusID=3,MusicaFK=2,CompositorFK=2},
                new CompositorMusica {ComMusID=4,MusicaFK=3,CompositorFK=11},
                new CompositorMusica {ComMusID=5,MusicaFK=4,CompositorFK=15},
                new CompositorMusica {ComMusID=6,MusicaFK=5,CompositorFK=16},
                new CompositorMusica {ComMusID=7,MusicaFK=6,CompositorFK=18}
            };

            compositores.ForEach(c => context.CompositorMusica.AddOrUpdate(cm => cm.ComMusID, c));
            context.SaveChanges();

            //Ligar as musicas aos artistas que as atuam
            var musicaArtista = new List<ArtistaMusica>
            {
                new ArtistaMusica {ArtMusId=1,ArtistaFK=1,MusicaFK=2 },
                new ArtistaMusica {ArtMusId=2,ArtistaFK=6,MusicaFK=1 },
                new ArtistaMusica {ArtMusId=3,ArtistaFK=11,MusicaFK=3 },
                new ArtistaMusica {ArtMusId=4,ArtistaFK=15,MusicaFK=4 },
                new ArtistaMusica {ArtMusId=5,ArtistaFK=16,MusicaFK=5 },
                new ArtistaMusica {ArtMusId=6,ArtistaFK=17,MusicaFK=5 },
                new ArtistaMusica {ArtMusId=7,ArtistaFK=18,MusicaFK=6 },

            };

            musicaArtista.ForEach(ma => context.ArtistaMusica.AddOrUpdate(a => a.ArtMusId, ma));
            context.SaveChanges();

            //Ligar musicas a emo��es
            var musicaMood = new List<MusicaMood>
            {
                new MusicaMood { MusGenID=1,MusicaFK=1,MoodFK=1},
                new MusicaMood { MusGenID=2,MusicaFK=1,MoodFK=2},
                new MusicaMood { MusGenID=3,MusicaFK=2,MoodFK=3},
                new MusicaMood { MusGenID=4,MusicaFK=3,MoodFK=1},
                new MusicaMood { MusGenID=5,MusicaFK=4,MoodFK=3},
                new MusicaMood { MusGenID=6,MusicaFK=5,MoodFK=4},
                new MusicaMood { MusGenID=7,MusicaFK=5,MoodFK=5},
                new MusicaMood { MusGenID=8,MusicaFK=6,MoodFK=4}

            };

            musicaMood.ForEach(mm => context.MusicaMood.AddOrUpdate(m => m.MusGenID, mm));
            context.SaveChanges();

            //Ligar musicas a generos
            var musicaGenero = new List<MusicaGenero>
            {
                new MusicaGenero { MusGenID=1,MusicaFK=1,GeneroFK=1},
                new MusicaGenero { MusGenID=2,MusicaFK=2,GeneroFK=1},
                new MusicaGenero { MusGenID=3,MusicaFK=2,GeneroFK=2},
                new MusicaGenero { MusGenID=4,MusicaFK=3,GeneroFK=2},
                new MusicaGenero { MusGenID=5,MusicaFK=3,GeneroFK=3},
                new MusicaGenero { MusGenID=6,MusicaFK=4,GeneroFK=2},
                new MusicaGenero { MusGenID=7,MusicaFK=5,GeneroFK=2},
                new MusicaGenero { MusGenID=8,MusicaFK=6,GeneroFK=2},
                new MusicaGenero { MusGenID=9,MusicaFK=6,GeneroFK=4}
            };

            musicaGenero.ForEach(mg => context.MusicaGenero.AddOrUpdate(m => m.MusGenID, mg));
            context.SaveChanges();

        }
    }
}
