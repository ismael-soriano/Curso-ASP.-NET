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

            var querySyntax = from invoice in invoices
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
            foreach (var item in querySyntax)
                Console.WriteLine(String.Format("Name: {0}, Invoices: {1}, Total amount: {2}", item.Name, item.Count, item.Amount));

            var methodSyntax = invoices.Join(customers, i => i.Customer.Id, c => c.Id, (i, c) => new
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
            foreach (var item in methodSyntax)
                Console.WriteLine(String.Format("Name: {0}, Invoices: {1}, Total amount: {2}", item.Name, item.Count, item.Amount));

            Console.WriteLine("\n");

            var pages = PagingExtensions.GetPage(invoices, 1, 3);
            foreach (var item in pages)
                Console.WriteLine(item);

            var customers2 = new List<Customer>() {
                new Customer() {Id = 1, Name = "Miguel", Phone = "931236754"},
                new Customer() {Id = 5, Name = "Adrian", Phone = "937653489"},
                new Customer() {Id = 2, Name = "Roger", Phone = "934526374"},
                new Customer() {Id = 3, Name = "Ares", Phone = "935675438"},
                new Customer() {Id = 4, Name = "Carlos", Phone = "938675940"},
            };

            //var orderDescending = customers2.OrderByDescending(c => c.Phone).OrderBy(c => c.Name).OrderBy(c => c.Id);
            var orderDescending = from customer in customers2
                          orderby customer.Name, customer.Id ascending, customer.Phone descending
                          select customer;

            Console.WriteLine("\nOrder By");
            foreach (var item in orderDescending)
                Console.WriteLine(String.Format("ID: {0}, Name: {1}, Phone: {2}", item.Id, item.Name, item.Phone));

            var a = "10";
            var b = "2";

            Console.WriteLine("\nComparación de cadenas");
            var stringResultado = String.Empty;
            if (String.Compare(a, b) > 0)
                stringResultado = string.Concat(stringResultado, "Mayor cadena a");
            else if (String.Compare(a, b) == 0)
                stringResultado = string.Concat(stringResultado, "las cadenas son iguales");
            else
                stringResultado = string.Concat(stringResultado, "Mayor cadena b");
            Console.WriteLine(stringResultado);

            Console.WriteLine("\nCompare to");
            customers2.Add(null);
            customers2.Sort();
            foreach (var item in customers2)
            {
                if (null != item)
                Console.WriteLine(String.Format("ID: {0}, Name: {1}, Phone: {2}", item.Id, item.Name, item.Phone));
            }

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
            customers[0].Id = 40;
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
