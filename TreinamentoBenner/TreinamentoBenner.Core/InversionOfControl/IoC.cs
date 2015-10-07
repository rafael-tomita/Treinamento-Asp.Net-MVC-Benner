using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using TreinamentoBenner.Core.InversionOfControl.Modules;

namespace TreinamentoBenner.Core.InversionOfControl
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        private IKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfraNinjectModule(),
                new RepositoryNinjectModule()
            );
        }
    }
}
