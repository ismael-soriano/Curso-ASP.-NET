using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Services;

namespace ContenedorDependencias
{
    public class ServiceLocator
    {
        readonly IKernel _kernel;

        public ServiceLocator(IKernel kernel)
        {
            if (null == kernel)
                throw new ArgumentNullException("kernel");

            _kernel = kernel;
        }

        public IService Service
        {
            get
            {
                return _kernel.Get<IService>();
            }
        }
    }
}
