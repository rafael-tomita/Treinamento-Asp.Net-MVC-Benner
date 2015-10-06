using System.ComponentModel.DataAnnotations.Schema;

namespace TreinamentoBenner.Core.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int IdPessoa { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }
    }
}