using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermissionBasedAuthorizationInDotNet5.Contants;

namespace PermissionBasedAuthorizationInDotNet5.Contants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            foreach (var module in Enum.GetValues(typeof(Modules)))
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }
    }
}
