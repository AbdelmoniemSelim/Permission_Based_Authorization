using Microsoft.AspNetCore.Identity;
using PermissionBasedAuthorizationInDotNet5.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PermissionBasedAuthorizationInDotNet5.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "basicuser@admin.com",
                Email = "basicuser@admin.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssw0rd321");
                await userManager.AddToRoleAsync(defaultUser, Roles.Bassic.ToString());
            }
        }
        public static async Task SeedSuperAdminUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "superadmin@admin.com",
                Email = "superadmin@admin.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssw0rd321");
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.Bassic.ToString(), Roles.Admin.ToString(), Roles.SuperAdmin.ToString() });
            }

            await roleManager.SeedClaimForSuperUser();
        }
        private static async Task SeedClaimForSuperUser(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            await roleManager.AddPermissioClaims(adminRole, Type.Products.ToString());
        }
        private static async Task AddPermissioClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsList(module);

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == Type.Permission.ToString() && a.Value == permission))

                    await roleManager.AddClaimAsync(role, new Claim(Type.Permission.ToString(), permission));
            }
        }

    }
}
