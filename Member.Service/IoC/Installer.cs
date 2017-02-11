using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Member.Service.Database;

namespace Member.Service.IoC
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMemberDbContext>().ImplementedBy<MemberDbContext>().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
        }
    }
}
