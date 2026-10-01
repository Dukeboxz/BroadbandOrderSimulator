using BroadbandSupplierSimulator.Models.GeographicAddress;

namespace BroadbandSupplierSimulator.Services;

public interface IGeographicAddressService
{
    List<GetGeographicAddressResponse> GetGeographicAddress();
}
