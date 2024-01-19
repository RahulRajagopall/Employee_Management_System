using System;
using System.ComponentModel.DataAnnotations;
namespace ems.Models
{
    public class TaskBase
    {
        [Key]
        public string? Task{get; set;}
        [Required]
        public string? DeadLine{get; set;}
    }
}
