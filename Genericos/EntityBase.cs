using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    public class EntityBase<T> where T:class
    {
        public int Id { get; set; }

        public void Save()
        {
            Type t = this.GetType();
            var properties = t.GetProperties();
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("{0}S", t.Name.ToUpper()));
            foreach (var property in properties)
            {
                sb.AppendLine(String.Format("{0}: {1}", property.Name.ToUpper(), property.GetValue(this)));
            }

            Console.Write(sb);

        }
    }
}
