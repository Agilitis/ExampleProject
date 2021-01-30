using ExampleProject.Domain.Entities;
using ExampleProject.Domain.ValueObjects;
using ExampleProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleProject.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = CarColor.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });


                await context.SaveChangesAsync();
            }

            if (!context.Cars.Any())
            {

                var carAccessory1 = new Accessory
                {
                    Name = "Airconditioner",
                    MarketPrice = 80000,
                    RentPrice = 200
                };

                var carAccessory2 = new Accessory
                {
                    Name = "GPS",
                    MarketPrice = 60000,
                    RentPrice = 100
                };

                var carAccessory3 = new Accessory
                {
                    Name = "Rear Camera",
                    MarketPrice = 40000,
                    RentPrice = 50
                };

                var cars = new List<Car>
                {
                    new Car
                    {
                        CarColor = CarColor.Blue,
                        Accessories = new List<Accessory>{
                            carAccessory1,
                            carAccessory2
                    },
                        Type = Domain.Enums.CarType.Mazda,
                        MarketPrice = 3500000,
                        DailyRentPrice = 7000
                    },
                    new Car
                    {
                        CarColor = CarColor.Red,
                        Accessories = new List<Accessory>{
                            carAccessory1
                    },
                        Type = Domain.Enums.CarType.Audi,
                        MarketPrice = 2500000,
                        DailyRentPrice = 6000
                    },
                    new Car
                    {
                        CarColor = CarColor.Grey,
                        Accessories = new List<Accessory>{
                            carAccessory1,
                            carAccessory3
                    },
                        Type = Domain.Enums.CarType.Audi,
                        MarketPrice = 6000000,
                        DailyRentPrice = 10000,
                    }
                };

                context.Cars.AddRange(cars);

                await context.SaveChangesAsync();
            }
        }
    }
}
