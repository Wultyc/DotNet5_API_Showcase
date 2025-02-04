﻿using DotNet5_API_Showcase.DTOs;
using DotNet5_API_Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5_API_Showcase
{
    public static class Extensions
    {
        public static UserResponse AsDto(this User user)
        {
            return new UserResponse
            {
                userId = user.userId,
                name = user.name,
                birthDate = user.birthDate.ToString("yyyy-MM-dd"),
                email = user.email
            };
        }

        public static User AsModel(this UserRequestCreateUpdate user)
        {
            return AsModel(user, Guid.NewGuid());
        }

        public static User AsModel(this UserRequestCreateUpdate user, Guid userId)
        {
            return new User
            {
                userId = userId,
                name = user.name,
                birthDate = new DateTime(user.birthDate.year, user.birthDate.month, user.birthDate.day),
                email = user.email
            };
        }
    }
}
