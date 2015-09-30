using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreinamentoBenner.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [UIHint("Albuns")]
        public virtual ICollection<Album> Albuns { get; set; }
    }
}