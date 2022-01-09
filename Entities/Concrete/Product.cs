using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
