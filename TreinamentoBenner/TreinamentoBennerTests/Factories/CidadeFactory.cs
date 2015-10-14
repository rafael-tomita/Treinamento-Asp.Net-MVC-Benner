using TreinamentoBenner.Core.Model;

namespace TreinamentoBennerTests.Factories
{
    public class CidadeFactory
    {
        public static Cidade Create(int id, string nome, string uf)
        {
            return new Cidade
            {
                Id = id,
                Nome = nome,
                Uf = uf
            };
        }
    }
}