using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public class Customer
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public Customer(uint id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"customerId:{Id}, CustomerName:{Name}";
        }
    }
}