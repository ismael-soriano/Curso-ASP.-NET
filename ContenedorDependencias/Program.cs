using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Services;
using Repositories;
using Ninject;
using Autofac;

namespace ContenedorDependencias
{
    class Program
    {
        static void Main(string[] args)
        {
            //var controller = new Controller(new Service(new Repository()));
            //controller.Add();

            /*var controllerType = Type.GetType("Controllers.Controller, Controllers");
            var serviceType = Type.GetType(typeof(Service).AssemblyQualifiedName.ToString());
            var repositoryType = Type.GetType(typeof(Repository).AssemblyQualifiedName.ToString());

            var repository = repositoryType.GetConstructors()[0].Invoke(new object[] { });
            var serviceConstructors = serviceType.GetConstructors();
            var service = serviceConstructors[0].Invoke(new object[] { repository });
            var parametersService = serviceConstructors[0].GetParameters();
            var controller = controllerType.GetConstructors()[0].Invoke(new object[] { service });

            controllerType.GetMethod("Add").Invoke(controller, new object[] { });*/

            //RegisterDependencies();
            ResolveDependencies();
            Console.ReadLine();
        }

        public static void RegisterDependencies()
        {
            IKernel kernel = new Ninject.StandardKernel(new ConsoleNinjectModule());
            var controller = kernel.Get<IController>();
            controller.Add();

            var sl = new ServiceLocator(kernel);
            sl.Service.Add();
        }

        public static void ResolveDependencies()
        {
            ContainerSetup containerSetup = new ContainerSetup();
            IContainer container = containerSetup.BuildContainer();
            container.Resolve<IController>().Add();
        }
    }
}
