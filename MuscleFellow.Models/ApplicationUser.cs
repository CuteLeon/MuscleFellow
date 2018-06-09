﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MuscleFellow.Models
{
    class ApplicationUser:IdentityUser<string>
    {

        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString("D");
        }
        public ApplicationUser(string userName)
        {
            UserName = userName;
        }
    }
}
