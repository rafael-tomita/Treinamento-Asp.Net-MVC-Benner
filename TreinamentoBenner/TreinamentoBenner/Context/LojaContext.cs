using System.Data.Entity;
using TreinamentoBenner.Models;

namespace TreinamentoBenner.Context
{
    public class LojaContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public System.Data.Entity.DbSet<TreinamentoBenner.Core.Model.Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<TreinamentoBenner.Core.Model.Cidade> Cidades { get; set; }
    }
}