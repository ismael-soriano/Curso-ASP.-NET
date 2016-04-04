using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInvoice2
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = populateCostumers();
            var invoices = populateInvoices(customers);

            var result = from invoice in invoices
                         join customer in customers on invoice.Customer.Id equals customer.Id
                         group invoice by customer into gb
                         select new
                         {
                             ID = gb.Key.Id,
                             Name = gb.Key.Name,
                             Count = gb.Count(),
                             Amount = gb.Sum(x => x.Amount)
                         };

            Console.WriteLine("Query syntax");
            foreach (var item in result)
                Console.WriteLine(String.Format("Name: {0}, Invoices: {1}, Total amount: {2}", item.Name, item.Count, item.Amount));

            var result2 = invoices.Join(customers, i => i.Customer.Id, c => c.Id, (i, c) => new
                {
                    invoice = i,
                    customer = c
                }).GroupBy(c => c.customer, c => c.invoice).Select(c => new
                    {
                        ID = c.Key.Id,
                        Name = c.Key.Name,
                        Count = c.Count(),
                        Amount = c.Sum(x => x.Amount)
                    });

            Console.WriteLine("\nMethodSyntax");
            foreach (var item in result2)
                Console.WriteLine(String.Format("Name: {0}, Invoices: {1}, Total amount: {2}", item.Name, item.Count, item.Amount));

            Console.WriteLine("\n");

            var result3 = PagingExtensions.GetPage(invoices, 1, 3);
            foreach (var item in result3)
                Console.WriteLine(item);

            Console.ReadLine();
        }

        public static List<Customer> populateCostumers()
        {
            return new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Patata1" },
                new Customer() { Id = 2, Name = "Patata2" },
                new Customer() { Id = 3, Name = "Patata3" },
                new Customer() { Id = 4, Name = "Patata4" }
            };
        }

        public static List<Invoice> populateInvoices(List<Customer> customers)
        {
            return new List<Invoice>()
            {
                new Invoice() { Id = 1, Customer = customers[0], Amount = 1000},
                new Invoice() { Id = 2, Customer = customers[0], Amount = 1000},
                new Invoice() { Id = 3, Customer = customers[1], Amount = 500},
                new Invoice() { Id = 4, Customer = customers[2], Amount = 250}
            };
        }
    }
}
