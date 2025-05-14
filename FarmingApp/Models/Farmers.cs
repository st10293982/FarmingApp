using System.ComponentModel.DataAnnotations;

namespace FarmingApp.Models
{
    public class Farmers
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }
    }
}
