using System;

namespace LubricantsServiceBackend.Entities;

public class PurchaseProduct
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int PurchaseId { get; set; }
    public int ProductId { get; set; }

    // Navigation properties
    public Purchase Purchase { get; set; }
    public Product Product { get; set; }
}