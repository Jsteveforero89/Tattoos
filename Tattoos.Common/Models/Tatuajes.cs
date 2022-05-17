

namespace Tattoos.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Tatuajes
    {
        [Key]
        public int TattooId { get; set; }

        [Required]
        public string Description { get; set; }

        public Decimal Price { get; set; }

        [Required]
        public string Type { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime PublishOn { get; set; }

    }
}
