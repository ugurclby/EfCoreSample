﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Student> Students { get; set; }
}
