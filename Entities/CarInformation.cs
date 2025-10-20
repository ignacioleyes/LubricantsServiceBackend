using System.ComponentModel.DataAnnotations;
namespace LubricantsServiceBackend.Entities;

public class CarInformation
{
    [Key]
    public int CarId { get; set; }
    public int? ClientId { get; set; }
    public string LicensePlate { get; set; }
    public string? AirFilter { get; set; }
    public string? OilFilter { get; set; }
    public string? FuelFilter { get; set; }
    public string? ACFilter { get; set; }
    public string? EngineOilType { get; set; }

    // Navigation property
    public Client Client { get; set; }
}
