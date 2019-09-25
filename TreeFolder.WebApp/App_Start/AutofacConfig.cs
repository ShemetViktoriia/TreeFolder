using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.BaseRepository;
using TreeFolder.Repository.Repositories;

namespace TreeFolder.WebApp.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<FolderContext>().AsSelf().Named<FolderContext>("context").InstancePerRequest();

            builder.RegisterType<FolderRepository>()
              .As<IFolderRepository>()
              .WithParameter((pi, c) => pi.Name == "context", (pi, c) => c.Resolve<FolderContext>()).ExternallyOwned();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}