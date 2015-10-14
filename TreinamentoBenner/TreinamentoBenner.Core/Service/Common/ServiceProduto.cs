using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        public ServiceProduto(IRepositoryProduto repositoryProduto) : base(repositoryProduto)
        {
        }
    }
}
