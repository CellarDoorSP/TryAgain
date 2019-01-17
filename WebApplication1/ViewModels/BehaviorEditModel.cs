using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class BehaviorEditModel
    {        
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string BehaviorName { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
