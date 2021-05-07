using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionBasedAuthorizationInDotNet5.ViewModels
{
    public class CheckBoxViewModel
    {
        public string RoleId { get; set; }
        public string DisplayValue { get; set; }
        public bool IsSelected { get; set; }
    }
}
