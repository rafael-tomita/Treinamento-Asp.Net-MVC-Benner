using Ninject.Modules;
using TreinamentoBenner.Core.Context;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class InfraNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<TreinamentoBennerContext>().ToSelf();
        }
    }
}