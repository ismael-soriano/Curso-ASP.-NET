using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class Controller : IController
    {
        readonly IService _service;

        public Controller(IService service)
        {
            if(null == service)
                throw new ArgumentNullException("Service");

            _service = service;
        }

        public void Add()
        {
            _service.Add();
        }
    }
}
