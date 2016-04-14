using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Insert
            using (var ctx = new ContextCurso())
            {
                var x = ctx.Database.Connection.ConnectionString;
                var customer = new Customer()
                {
                    Name = "Pedro",
                    Phone = "616647015"
                };
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }

           // Update
            using (var ctx = new ContextCurso())
            {
                var customer = ctx.Customers.Where(c => c.Id == 1).FirstOrDefault();
                if (null != customer)
                {
                    customer.Nif = "nif";
                    ctx.SaveChanges();
                }
            }

            // Update optimo
            //using (var ctx = new ContextCurso())
            //{
            //    var customer = new Customer() { Id = 1, Nif = "nif" };
            //    ctx.Entry(customer).State = EntityState.Modified;
            //    ctx.SaveChanges();
            //}

            // Delete
            using (var ctx = new ContextCurso())
            {
                var customer = ctx.Customers.Where(c => c.Id == 1).FirstOrDefault();
                if (null != customer)
                {
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                }
            }

            // Delete optimo
            //using (var ctx = new ContextCurso())
            //{
            //    ctx.Entry<Customer>(new Customer() { Id = 1 }).State = EntityState.Deleted;
            //    ctx.SaveChanges();
            //}

            // Select
            using (var ctx = new ContextCurso())
            {
                var x = ctx.Database.Connection.ConnectionString;
                var customers = ctx.Customers.AsNoTracking();
                foreach (var item in customers)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
    }
}
