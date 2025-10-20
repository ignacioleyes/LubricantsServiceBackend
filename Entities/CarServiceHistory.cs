using System;
using System.ComponentModel.DataAnnotations;

namespace LubricantsServiceBackend.Entities
{
    public class CarServiceHistory
    {
        [Key]
        public int ServiceId { get; set; }
        public int CarId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceType { get; set; }
        public string? Notes { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation properties
        public CarInformation CarInformation { get; set; }
        public Employee Employee { get; set; }
    }
}