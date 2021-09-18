using System.ComponentModel.DataAnnotations;

namespace PlaformService.Models
{
    public class Platform
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
        
        [Required]
        public string Name { get; set; }
    }    
}