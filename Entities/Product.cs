using System;
using System.Collections.Generic;

namespace LubricantsServiceBackend.Entities;
public class Product
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public int BrandId { get; set; }
    public int StateId { get; set; }
    public double PurchasePrice { get; set; }
    public int Iva { get; set; }
    public double? SalePrice { get; set; }
    public int? ProviderCode { get; set; }

    // Navigation properties
    public Brand Brand { get; set; }
    public ProductType ProductType { get; set; }
    public State State { get; set; }
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
}