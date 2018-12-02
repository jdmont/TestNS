using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using test_business;
using test_models.contracts;
using test_utils.contracts;
using test_utils.LoggerService;

namespace test_api.DI
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISearchProcess>().ImplementedBy<SearchProcessBusiness>().LifestylePerWebRequest(),
                Component.For<ILoggerService>().ImplementedBy<LoggerService>().LifestylePerWebRequest()
                );

            
        }
    }
}