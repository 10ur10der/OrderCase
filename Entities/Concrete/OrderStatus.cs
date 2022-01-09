using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderStatus
    {
        public string CustomerOrderNo { get; set; }
        public int StatusValue { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
