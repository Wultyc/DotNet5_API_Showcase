using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.DTOs
{
    public record CommonBirthDate
    {
        [Required]
        public int day { get; init; }
        [Required]
        public int month { get; init; }
        [Required]
        public int year { get; init; }
    }
    
}
