using System;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public abstract class Image
    {
        [Key, Required]
        public Guid ID { get; set; }

        [Required]
        public Byte[] Name { get; set; }

        [Required]
        public Byte[] Data { get; set; }

        [Required]
        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
