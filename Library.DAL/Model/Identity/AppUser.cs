﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.DAL.Model.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public bool isDeleted { get; set; }
    }
}
