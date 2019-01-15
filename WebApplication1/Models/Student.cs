﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Display(Name="Student Name")]
        [Required]
        public string Name { get; set; }
        public List<Behavior> StudentBehaviors { get; set; }
    }
}
