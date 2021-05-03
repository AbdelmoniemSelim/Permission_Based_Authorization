﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionBasedAuthorizationInDotNet5.ViewModels
{
    public class RoleFormViewModel
    {
        [Required,StringLength(256)]
        public string Name  { get; set; }
    }
}
