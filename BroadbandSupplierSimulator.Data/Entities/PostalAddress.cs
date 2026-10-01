using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class PostalAddress
{
    public string? AddressId { get; set; }
    public string? MatchedId { get; set; }
    public bool? AddressMatch { get; set; }
    public string? Uprn { get; set; }
    public string? ParentUprn { get; set; }
    public string? AddressSource { get; set; }
    public string? ExchangeGroupCode { get; set; }
    public string? DistrictCode { get; set; }
    public string? Qualifier { get; set; }
    public string? StreetNr { get; set; }
    public string? StreetNrSuffix { get; set; }
    public string? StreetNrLast { get; set; }
    public string? StreetNrLastSuffix { get; set; }
    public string? StreetName { get; set; }
    public string? StreetType { get; set; }
    public string? StreetSuffix { get; set; }
    public string? Postcode { get; set; }
    public string? Locality { get; set; }
    public string? City { get; set; }
    public string? StateOrProvince { get; set; }
    public string? Country { get; set; }
    public GeographicLocationValue Location { get; set; } = new();
    public GeographicSubAddressValue SubAddress { get; set; } = new();
}
