using System;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Image
    {
        [Key]
        public Guid ID { get; set; }

        public Byte[] Name { get; set; }

        public Byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
