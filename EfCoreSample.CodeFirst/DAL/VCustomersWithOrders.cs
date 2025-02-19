using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public class VCustomersWithOrders
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }
}
