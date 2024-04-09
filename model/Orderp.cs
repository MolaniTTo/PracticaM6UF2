using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaM6UF2.model
{
    public class Orderp
    {
        public virtual int Id { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual int Amount { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual double Cost { get; set; }

        

    }
}
