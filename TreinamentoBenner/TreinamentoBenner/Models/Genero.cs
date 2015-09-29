using System.Collections.Generic;

namespace TreinamentoBenner.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Album> Type { get; set; }
    }
}