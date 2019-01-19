﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class StudentEditModel
    {
        [Required(ErrorMessage = "Name required")]
        public string StudentName { get; set; }
    }
}
