using FarmingApp.Models;

namespace FarmingApp.Data
{
    public class DbInitializer
    {


        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return; // DB has been seeded
            }

            var farmers = new Employee[]
            {
                new Employee { FullName = "Nick Njapa", FarmLocation = "KwaZulu-Natal" },
                new Employee { FullName = "Tim Nickle", FarmLocation = "Eastern Cape" }
            };
            context.Employees.AddRange(farmers);
            context.SaveChanges();

            var products = new FarmingItems[]
            {
                new FarmingItems { ProductName = "Tomatoes", ProductCategory = "Vegetables", ProductionDate = DateTime.Now.AddDays(-10), EmployeeFarmerId = 1 },
                new FarmingItems { ProductName = "Maize", ProductCategory = "Grains", ProductionDate = DateTime.Now.AddDays(-20), EmployeeFarmerId = 2 }
            };
            context.FarmingItems.AddRange(products);
            context.SaveChanges();
        }

    }
}
