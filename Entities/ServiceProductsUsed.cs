namespace LubricantsServiceBackend.Entities;
public class ServiceProductsUsed
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int ProductId { get; set; }
    public int? Quantity { get; set; } // Puede ser nulo según la tabla

    // Propiedades de navegación
    public CarServiceHistory CarServiceHistory { get; set; }
    public Product Product { get; set; }
}