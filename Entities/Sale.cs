using System;

namespace LubricantsServiceBackend.Entities;
public class Sale
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public DateTime SaleDate { get; set; }
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int PayTypeId { get; set; }
    public int Amount { get; set; }

    // Navigation properties
    public Product Product { get; set; }
    public Client Client { get; set; }
    public PayType PayType { get; set; }
}