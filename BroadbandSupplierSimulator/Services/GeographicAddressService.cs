using System.Text.Json;
using BroadbandSupplierSimulator.Models.GeographicAddress;

namespace BroadbandSupplierSimulator.Services;

public class GeographicAddressService : IGeographicAddressService
{
    private const string AddressType = "BtGeographicAddress";
    private const string SubAddressType = "BtGeographicSubAddress";
    private const int AddressCount = 5;
    private const int FirstStreetNumber = 10;
    private const long FirstIdNumber = 20172;
    private const long FirstUprn = 9051081968;

    public List<GetGeographicAddressResponse> GetGeographicAddress()
    {
        var addresses = new List<GetGeographicAddressResponse>();

        for (var i = 0; i < AddressCount; i++)
        {
            var isLast = i == AddressCount - 1;

            addresses.Add(new GetGeographicAddressResponse
            {
                Id = $"A{FirstIdNumber + i:D11}",
                AddressVerificationNeeded = false,
                AddressMatch = false,
                Uprn = (FirstUprn + i).ToString(),
                AddressSource = "Openreach",
                ExchangeGroupCode = "DEN",
                DistrictCode = "NS",
                Qualifier = isLast ? "Silver" : "Gold",
                StreetNr = (FirstStreetNumber + i).ToString(),
                StreetName = "Correction Wynd",
                Postcode = "AB10 1HP",
                City = "Aberdeen",
                Country = "United Kingdom",
                Type = AddressType,
                GeographicLocationRefOrValue = BuildLocation(),
                GeographicSubAddress =
                [
                    new GetGeographicAddressResponseGeographicSubAddress { Type = SubAddressType }
                ]
            });
        }

        return addresses;
    }

    private static JsonElement BuildLocation()
    {
        return JsonSerializer.SerializeToElement(new
        {
            geometry = new[] { new { x = "57.1473068", y = "-2.0988506" } }
        });
    }
}
