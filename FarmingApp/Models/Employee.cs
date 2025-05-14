using Microsoft.AspNetCore.Mvc;

namespace FarmingApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FarmLocation { get; set; }

        public ICollection<FarmingItems> Products { get; set; }
    }
}

