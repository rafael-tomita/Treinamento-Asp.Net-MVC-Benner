using Ninject.Modules;
using TreinamentoBenner.Core.Service.Common;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServicePessoa>().To<ServicePessoa>();
            Bind<IServiceCidade>().To<ServiceCidade>();
            Bind<IServiceTelefone>().To<ServiceTelefone>();
            Bind<IServiceProduto>().To<ServiceProduto>();
        }
    }
}