﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionBasedAuthorizationInDotNet5.Data;

[assembly: HostingStartup(typeof(PermissionBasedAuthorizationInDotNet5.Areas.Identity.IdentityHostingStartup))]
namespace PermissionBasedAuthorizationInDotNet5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}