using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.DTOs
{
    public record UserRequestCreateUpdate
    {
        [Required]
        public string name { get; init; }
        [Required]
        public CommonBirthDate birthDate { get; init; }
        [Required]
        public string email { get; init; }
    }
}
