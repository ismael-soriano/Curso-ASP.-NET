using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var factura = new Factura() { Id = 1, Date = "10/08/2014" };
            factura.Save();

            var cliente = new Cliente() { Id = 1, Name = "patata", Phone = "936756341" };
            cliente.Save();

            var cliente2 = new Cliente() { Name = "012345678910" };
            var property = cliente2.GetType().GetProperty("Name");
            var value = property.GetValue(cliente2);
            var attributes = property.GetCustomAttributes(true);

            foreach (var attribute in attributes)
            {
                var attr = attribute as ValidationAttribute;
                if (null != attr)
                {
                    if (!attr.IsValid(value))
                        throw new Exception(attr.ErrorMessage);
                }
            }*/

            var clientes = new List<Cliente>()
            {
                new Cliente() { Id = 1, Name = "Patata", Phone = "934561287" },
                new Cliente() { Id = 2, Name = "Patata1", Phone = "937865463" },
                new Cliente() { Id = 3, Name = "Patata2", Phone = "938764536" },
                new Cliente() { Id = 4, Name = "Patata3", Phone = "937653425" }
            };

            var facturas = new List<Factura>()
            {
                new Factura() { Id = 1, Date = DateTime.Now, Cliente = clientes[0]},
                new Factura() { Id = 2, Date = DateTime.Now, Cliente = clientes[1]},
                new Factura() { Id = 3, Date = DateTime.Now, Cliente = clientes[2]}
            };

            var results = from f in facturas
                         join c in clientes on f.Cliente.Id equals c.Id
                         select new { f.Id, f.Date, c.Name };

            Console.WriteLine(String.Format("Impresión de Facturas."));
            foreach(var item in results)
                Console.WriteLine(String.Format("ID Factura: {0}, Fecha: {1}, Cliente: {2}", item.Id, item.Date.ToString(), item.Name));

            var results2 = from c in clientes
                           join f in facturas on c.Id equals f.Cliente.Id into ccf
                           from c2 in ccf.DefaultIfEmpty()
                           where c2 == null
                           select new { c.Id, c.Name };

            Console.WriteLine(String.Format("Clientes sin facturas."));
            foreach (var item in results2)
                Console.WriteLine(String.Format("ID: {0}, Name: {1}", item.Id, item.Name));


            Console.ReadLine();
        }
    }
}
