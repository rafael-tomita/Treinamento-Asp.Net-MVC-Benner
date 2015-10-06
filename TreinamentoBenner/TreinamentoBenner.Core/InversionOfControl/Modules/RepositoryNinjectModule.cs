using Ninject.Modules;
using TreinamentoBenner.Core.Repository.Common;
using TreinamentoBenner.Core.Repository.Interfaces;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryPessoa>().To<RepositoryPessoa>();
        }
    }
}