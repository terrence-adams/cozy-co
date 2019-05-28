using System.ComponentModel.DataAnnotations;

namespace CozyCo.Domain.Models
{
    public class PropertyType
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}