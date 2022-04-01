using System;
using System.ComponentModel.DataAnnotations;

namespace Parks.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Message title must be between 5 and 50 characters long", MinimumLength = 5)]
        public string Name{ get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Message body must be between 5 and 50 characters long", MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Message body must be between 5 and 50 characters long", MinimumLength = 2)]
        public string State { get; set; }

        [Required]
        public int Size { get; set; }
    }
}