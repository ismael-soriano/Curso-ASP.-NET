using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (var ctx = new ContextCurso())
            {
                
                var customer = new Customer()
                {
                    Name = "Pedro",
                    Phone = "616647015"
                };
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }*/

            using (var ctx = new ContextCurso())
            {
                var x = ctx.Database.Connection.ConnectionString;
                var customers = ctx.Customers;
                foreach (var item in customers)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
    }
}
