using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace iMusicaCorp.Infra.CrossCutting.IoC
{
    public class Container
    {
        public Container()
        {
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(GetModule()));
        }

        public StandardKernel GetModule()
        {
            return new StandardKernel(new MusicaModulo() );
        }
    }
}
