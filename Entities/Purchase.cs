using System;
using System.Collections.Generic;

namespace LubricantsServiceBackend.Entities;
public class Purchase
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
}