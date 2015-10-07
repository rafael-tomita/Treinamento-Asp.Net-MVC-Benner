using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServiceTelefone : ServiceBase<Telefone>, IServiceTelefone
    {
        public ServiceTelefone(IRepositoryTelefone repositoryTelefone) : base(repositoryTelefone)
        {
        }
    }
}
