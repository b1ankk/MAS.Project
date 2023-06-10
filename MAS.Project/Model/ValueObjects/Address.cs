namespace MAS.Project.Model.ValueObjects;

public struct Address
{
    public required string Street { get; set; }
    public required string StreetNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }
}
