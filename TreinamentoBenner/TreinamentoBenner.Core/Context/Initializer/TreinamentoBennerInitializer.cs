using System.Data.Entity;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Context.Initializer
{
    public class TreinamentoBennerInitializer : DropCreateDatabaseAlways<TreinamentoBennerContext>
    {
        protected override void Seed(TreinamentoBennerContext context)
        {
            var maringa = new Cidade
            {
                Nome = "Maringá",
                Uf = "PR"
            };
            context.Cidades.Add(maringa);

            var antaGorda = new Cidade
            {
                Nome = "Anta Gorda",
                Uf = "RS"
            };
            context.Cidades.Add(antaGorda);

            context.Pessoas.Add(new Pessoa { Nome = "Erick", Cidade = maringa });
            context.Pessoas.Add(new Pessoa { Nome = "Outro cara", Cidade = antaGorda });

            base.Seed(context);
        }
    }
}
