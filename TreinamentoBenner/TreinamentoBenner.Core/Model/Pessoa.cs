using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreinamentoBenner.Core.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public virtual Cidade Cidade { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}
