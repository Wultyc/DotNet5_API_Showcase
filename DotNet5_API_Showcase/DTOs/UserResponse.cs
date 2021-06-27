using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase.DTOs
{
    public record UserResponse
    {
        public Guid userId { get; init; }
        public string name { get; init; }
        public string birthDate { get; init; }
        public string email { get; init; }
    }
}
