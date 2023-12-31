﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMoneyManager.Domain.Constants;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Infrastructure.Identity;

namespace MyMoneyManager.Infrastructure.Data;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser
        {
            UserName = "administrator@localhost",
            Email = "administrator@localhost"
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.EgressCategories.Any())
        {
            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Restaurantes",
                Description = "Comidas en restaurantes",
                Active = true,
            });

            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Supermercados",
                Description = "Compras en supermercados",
                Active = true,
            });

            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Transporte",
                Description = "Gastos de transporte",
                Active = true,
            });

            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Transferencias",
                Description = "Transferencias a otras cuentas",
                Active = true,
            });

            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Servicios",
                Description = "Pagos de servicios",
                Active = true,
            });

            _context.EgressCategories.Add(new EgressCategory
            {
                Name = "Otros",
                Description = "Otros gastos",
                Active = true,
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.IncomeCategories.Any())
        {
            _context.IncomeCategories.Add(new IncomeCategory
            {
                Name = "Salario",
                Description = "Ingresos por salario",
                Active = true,
            });

            _context.IncomeCategories.Add(new IncomeCategory
            {
                Name = "Transferencias",
                Description = "Transferencias de otras cuentas",
                Active = true,
            });

            _context.IncomeCategories.Add(new IncomeCategory
            {
                Name = "Otros",
                Description = "Otros ingresos",
                Active = true,
            });

            await _context.SaveChangesAsync();
        }
    }
}
