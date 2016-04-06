using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Controllers;
using Repositories;

namespace ContenedorDependencias
{
    public class ConsoleNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IController>().To<Controller>().InTransientScope();
            this.Bind<IService>().To<Service>().InThreadScope();
            this.Bind<IRepository>().To<Repository>().InSingletonScope();
        }
    }
}
