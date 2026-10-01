# Broadband Supplier Simulator

An API that allows the acurate simulation of replies to the TM Forum broadband ordering process. Is based on on the BTW interpretation of the TMP Forum OpenAPI specifications for Product Ordering, Appointment Management, Geographic Address and Product and Network Availability.

## Getting started

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```powershell
dotnet build BroadbandSupplierSimulator.slnx
dotnet run --project BroadbandSupplierSimulator --launch-profile http
```

The API listens on `http://localhost:5135` (or `https://localhost:7215` with the `https` profile). In the Development environment the OpenAPI document is served at `/openapi/v1.json`.

### Docker

Build with the repository root as the context:

```powershell
docker build -f BroadbandSupplierSimulator/Dockerfile -t broadband-supplier-simulator .
```

The container listens on ports 8080 (HTTP) and 8081 (HTTPS).

## Endpoints

| Controller | Method and route |
|---|---|
| ProductOrder | `POST /hubco/tmf/productOrderingManagement/v4/productOrder` |
| | `POST /hubco/tmf/productOrderingManagement/v4/productOrder/notification` |
| | `PATCH /hubco/tmf/productOrderingManagement/v4/productOrder/{id}` |
| | `POST /hubco/tmf/productOrderingManagement/v4/cancelProductOrder` |
| | `POST /hubco/tmf/productOrderingManagement/v4/cancelProductOrder/notification` |
| ProductInventory | `GET /tmf/productInventory/v4/product` |
| AppointmentManagement | `POST /common/appointmentManagement/v4/searchTimeSlot` |
| | `POST /common/appointmentManagement/v4/appointment` |
| GeographicAddress | `GET /common/geographicAddressManagement/v1/geographicAddress` |
| | `POST /common/geographicAddressManagement/v1/geographicAddress` |
| ProductAndNetworkAvailability | `POST /hubco/tmf/productOfferingQualification/v4/productOfferingQualification` |
| | `GET /v1/line-availability/line` |

Requests missing a required header (such as `APIGW-Tracking-Header`) or required body fields get a `400` response. Valid requests get the success status from the spec with an empty body.


