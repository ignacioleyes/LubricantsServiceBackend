using System;

namespace LubricantsServiceBackend.Entities;
public class Employee
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime EntryDate { get; set; }
    public int? SaleId { get; set; }
    public int StateId { get; set; }

    // Navigation properties
    public Sale Sale { get; set; }
    public State State { get; set; }
}