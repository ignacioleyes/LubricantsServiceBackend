using System;
namespace LubricantsServiceBackend.Entities;
public class Brand
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}