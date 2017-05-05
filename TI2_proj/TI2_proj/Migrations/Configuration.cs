namespace TI2_proj.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TI2_proj.Models.MusicasDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TI2_proj.Models.MusicasDB context)
        {
            //  This method will be called after migrating to the latest version.

            //----------------------------------------------------------
            //Album
            var albuns = new List<Album>
            {
                new Album { AlbumId = 1, Titulo = "Live and Let Die", AutorFK = 11, EditFK=1},
                new Album { AlbumId = 2, Titulo = "Revolver", AutorFK = 1, EditFK=2},
                new Album { AlbumId = 3, Titulo = "Dá-me um segundo", AutorFK = 11, EditFK=3},
                new Album { AlbumId = 4, Titulo = "Illuminate", AutorFK = 15, EditFK=4},
                new Album { AlbumId = 5, Titulo = "This is Acting", AutorFK = 16, EditFK=5},
                new Album { AlbumId = 6, Titulo = "Girl", AutorFK = 16, EditFK=6}
            };

            albuns.ForEach(alb => context.Album.AddOrUpdate());
            context.SaveChanges();
            //--------------------------------------------------------
            //Artistas a adicionar
            var artistas = new List<Artista>
            {
                new Artista { idArtista = 1, nome = "The Beatles", banda = true},
                new Artista { idArtista = 2, nome = "John Lennon", banda = false},
                new Artista { idArtista = 3, nome = "Paul McCartney", banda = false},
                new Artista { idArtista = 4, nome = "Ringo Starr", banda = false},
                new Artista { idArtista = 5, nome = "George Harrison", banda = false},
                new Artista { idArtista = 6, nome = "Wings", banda = true},
                new Artista { idArtista = 7, nome = "Linda McCartney", banda = false},
                new Artista { idArtista = 8, nome = "Denny Laine", banda = false},
                new Artista { idArtista = 9, nome = "Henry McCullogh", banda = false},
                new Artista { idArtista = 10, nome = "Denny Seiwell", banda = false},
                new Artista { idArtista = 11, nome = "D.A.M.A", banda = true},
                new Artista { idArtista = 12, nome = "Francisco Pereira", banda = false},
                new Artista { idArtista = 13, nome = "Miguel Coimbra", banda = false},
                new Artista { idArtista = 14, nome = "Miguel Cristovinho", banda = false},
                new Artista { idArtista = 15, nome = "Shawn Mendes", banda = false},
                new Artista { idArtista = 16, nome = "Sia", banda = false},
                new Artista { idArtista = 17, nome = "Sean Paul", banda = false},
                new Artista { idArtista = 18, nome = "Pharrell Williams", banda = false}

                //adicionar artistas
            };

            artistas.ForEach(art => context.Artista.AddOrUpdate());
            context.SaveChanges();

            //Ligar as musicas aos artistas que as atuam
            var musicaArtista = new List<ArtistaMusica>
            {
                new ArtistaMusica {ArtistaFK=1,MusicaFK=1 },
                new ArtistaMusica {ArtistaFK=6,MusicaFK=2 },
                new ArtistaMusica {ArtistaFK=11,MusicaFK=3 },
                new ArtistaMusica {ArtistaFK=15,MusicaFK=4 },
                new ArtistaMusica {ArtistaFK=16,MusicaFK=5 },
                new ArtistaMusica {ArtistaFK=17,MusicaFK=5 },
                new ArtistaMusica {ArtistaFK=18,MusicaFK=6 },

            };

            musicaArtista.ForEach(ma => context.ArtistaMusica.AddOrUpdate());
            context.SaveChanges();

            //Ligar artistas às suas bandas
            var bandas = new List<Bandas>
            {
                new Bandas {BandaFK=1,MembroFK=2 },
                new Bandas {BandaFK=1,MembroFK=3 },
                new Bandas {BandaFK=1,MembroFK=4 },
                new Bandas {BandaFK=1,MembroFK=5 },
                new Bandas {BandaFK=6,MembroFK=2 },
                new Bandas {BandaFK=6,MembroFK=7 },
                new Bandas {BandaFK=6,MembroFK=8 },
                new Bandas {BandaFK=6,MembroFK=9 },
                new Bandas {BandaFK=6,MembroFK=10 },
                new Bandas {BandaFK=11,MembroFK=12 },
                new Bandas {BandaFK=11,MembroFK=13 },
                new Bandas {BandaFK=11,MembroFK=14 },

            };

            bandas.ForEach(b => context.Bandas.AddOrUpdate());
            context.SaveChanges();

            //Ligar musicas aos seus compositores
            var compositores = new List<CompositorMusica>
            {
                new CompositorMusica {MusicaFK=1,CompositorFK=2},
                new CompositorMusica {MusicaFK=1,CompositorFK=7},
                new CompositorMusica {MusicaFK=2,CompositorFK=2},
                new CompositorMusica {MusicaFK=3,CompositorFK=11},
                new CompositorMusica {MusicaFK=4,CompositorFK=15},
                new CompositorMusica {MusicaFK=5,CompositorFK=16},
                new CompositorMusica {MusicaFK=6,CompositorFK=18}
            };

            compositores.ForEach(c => context.CompositorMusica.AddOrUpdate());
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

            editoras.ForEach(e => context.Editora.AddOrUpdate());
            context.SaveChanges();

            //Genero
            var generos = new List<Genero>
            {
                new Genero { GeneroID=1,Nome="Rock"},
                new Genero { GeneroID=2,Nome="Pop"},
                new Genero { GeneroID=3,Nome="Rap"},
                new Genero { GeneroID=3,Nome="R&B"}
            };

            generos.ForEach(g => context.Genero.AddOrUpdate());
            context.SaveChanges();

            //Mood
            var moods = new List<Mood>
            {
                new Mood { MoodID=1,Nome="Tristeza"},
                new Mood { MoodID=2,Nome="Ansiedade"},
                new Mood { MoodID=3,Nome="Excitação"},
                new Mood { MoodID=4,Nome="Felicidade"},
                new Mood { MoodID=5,Nome="Melancolia"}
            };

            moods.ForEach(m => context.Mood.AddOrUpdate());
            context.SaveChanges();

            //Ligar musicas a generos
            var musicaGenero = new List<MusicaGenero>
            {
                new MusicaGenero { MusicaFK=1,GeneroFK=1},
                new MusicaGenero { MusicaFK=2,GeneroFK=1},
                new MusicaGenero { MusicaFK=2,GeneroFK=2},
                new MusicaGenero { MusicaFK=3,GeneroFK=2},
                new MusicaGenero { MusicaFK=3,GeneroFK=3},
                new MusicaGenero { MusicaFK=4,GeneroFK=2},
                new MusicaGenero { MusicaFK=5,GeneroFK=2},
                new MusicaGenero { MusicaFK=6,GeneroFK=2},
                new MusicaGenero { MusicaFK=6,GeneroFK=4}
            };

            musicaGenero.ForEach(mg => context.MusicaGenero.AddOrUpdate());
            context.SaveChanges();

            //Ligar musicas a emoções
            var musicaMood = new List<MusicaMood>
            {
                new MusicaMood { MusicaFK=1,MoodFK=1},
                new MusicaMood { MusicaFK=1,MoodFK=2},
                new MusicaMood { MusicaFK=2,MoodFK=3},
                new MusicaMood { MusicaFK=3,MoodFK=1},
                new MusicaMood { MusicaFK=4,MoodFK=3},
                new MusicaMood { MusicaFK=5,MoodFK=4},
                new MusicaMood { MusicaFK=5,MoodFK=5},
                new MusicaMood { MusicaFK=6,MoodFK=4}

            };

            musicaMood.ForEach(mm => context.MusicaMood.AddOrUpdate());
            context.SaveChanges();

            //Adicionar musicas
            var musicas = new List<Musicas>
            {
                new Musicas {MusicaID=1,Titulo="Live and Let Die",Duracao=192,NumFaixa=1,AlbumFK=1},
                new Musicas {MusicaID=2,Titulo="Eleanor Rigby",Duracao=128,NumFaixa=2,AlbumFK=2},
                new Musicas {MusicaID=3,Titulo="Agora é tarde",Duracao=315,NumFaixa=3,AlbumFK=3},
                new Musicas {MusicaID=4,Titulo="Treat You Better",Duracao=187,NumFaixa=4,AlbumFK=4},
                new Musicas {MusicaID=5,Titulo="Cheap Thrills",Duracao=324,NumFaixa=6,AlbumFK=5},
                new Musicas {MusicaID=6,Titulo="Happy",Duracao=333,NumFaixa=5,AlbumFK=6},

            };

        }
    }
}
