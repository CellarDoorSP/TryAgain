using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {        
        [Display(Name="Student Name")]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentName { get; set; }
        public List<Behavior> StudentBehaviors { get; set; }
    }
}
