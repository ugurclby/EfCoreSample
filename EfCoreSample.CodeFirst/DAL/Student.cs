using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public class Student : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Teacher> Teachers { get; set; } = new();
    public DateTime? DtCreated { get; set; }
    public DateTime? DtUpdated { get; set; }
}
