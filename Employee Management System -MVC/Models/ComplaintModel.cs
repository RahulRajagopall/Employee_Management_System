using System.ComponentModel.DataAnnotations;

namespace ems.Models;

public class ComplaintModel
{
    
        [Key]
        
        public String? Email { get; set; }
        [Required]
        public String? Complaints { get; set; }

}