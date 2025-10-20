using LubricantsServiceBackend.Entities;
using System;

public class Client
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int StateId { get; set; }

    // Navigation property for the foreign key
    public State State { get; set; }
}