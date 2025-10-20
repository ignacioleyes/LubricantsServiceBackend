using System;
namespace LubricantsServiceBackend.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ClientId { get; set; }
        public int StateId { get; set; }

        // Navigation properties
        public Client Client { get; set; }
        public State State { get; set; }
    }
}
