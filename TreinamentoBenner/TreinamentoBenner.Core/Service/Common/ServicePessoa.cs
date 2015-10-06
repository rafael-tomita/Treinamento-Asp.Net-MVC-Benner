using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServicePessoa : ServiceBase<Pessoa>, IServicePessoa
    {
        public ServicePessoa(IRepositoryPessoa repositoryPessoa) : base(repositoryPessoa)
        {
        }
    }
}
