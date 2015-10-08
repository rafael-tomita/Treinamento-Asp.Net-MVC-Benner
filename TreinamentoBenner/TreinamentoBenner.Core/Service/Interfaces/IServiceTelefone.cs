using System.Linq;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Service.Interfaces
{
    public interface IServiceTelefone : IService<Telefone>
    {
        IQueryable<Telefone> ListarPorPessoa(int id);
    }
}
