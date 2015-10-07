using System.Collections.Generic;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Service.Interfaces
{
    public interface IServiceCidade : IService<Cidade>
    {
        IEnumerable<string> ListarEstados();
    }
}
