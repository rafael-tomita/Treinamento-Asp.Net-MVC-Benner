using System.Collections.Generic;
using System.Linq;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServiceCidade : ServiceBase<Cidade>, IServiceCidade
    {
        private readonly IRepositoryCidade repositoryCidade;

        public ServiceCidade(IRepositoryCidade repositoryCidade) : base(repositoryCidade)
        {
            this.repositoryCidade = repositoryCidade;
        }

        public IEnumerable<string> ListarEstados()
        {
            return repositoryCidade.All(true).GroupBy(q => q.Uf).Select(q => q.Key);
        }
    }
}
