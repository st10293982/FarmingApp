using System;
using System.ComponentModel.DataAnnotations;

namespace FarmingApp.Models
{
    public class FarmingItems
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public DateTime ProductionDate { get; set; }

        public int EmployeeFarmerId { get; set; }
        public Employee Employee { get; set; }
    }
}

