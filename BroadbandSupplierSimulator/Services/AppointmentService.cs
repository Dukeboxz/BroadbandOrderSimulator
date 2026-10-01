using System.Globalization;
using BroadbandSupplierSimulator.Models.AppointmentManagement;
using BroadbandSupplierSimulator.Simulation;

namespace BroadbandSupplierSimulator.Services;

public class AppointmentService(ISimulationHelper simulationHelper) : IAppointmentService
{
    private const string EntityType = "BTProductAppointmentSpecification";
    private const string EntityBaseType = "RelatedEntity";
    private const string EntityRole = "OrderInformation";
    private const string EthernetDateFormat = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";
    private const string BroadbandDateFormat = "yyyy-MM-dd'T'HH:mm:ss'Z'";
    private const int SlotCount = 5;
    private const int MinDaysUntilAvailable = 1;
    private const int MaxDaysUntilAvailable = 8;
    private const int EthernetSlotHours = 2;
    private const int BroadbandMorningStartHour = 8;
    private const int BroadbandAfternoonStartHour = 13;
    private const int BroadbandAfternoonEndHour = 18;

    private static readonly AppointmentProfile Ethernet = new(
        IsEthernet: true,
        ProductSpecificationId: "Etherway Superfast GEA",
        Characteristics:
        [
            ("DirectoryNumber", "2277264355"),
            ("AccessTechnology", "Generic Ethernet Access")
        ],
        SearchId: "1234567812",
        AppointmentId: "1234567812",
        CreationDate: "2022-02-01T14:40:43.071Z",
        ValidStart: "2022-03-17T09:00:00.000Z",
        ValidEnd: "2022-03-17T11:00:00.000Z");

    private static readonly AppointmentProfile Broadband = new(
        IsEthernet: false,
        ProductSpecificationId: "BB1",
        Characteristics:
        [
            ("AccessTechnology", "FTTC"),
            ("DirectoryNumber", "02890830541")
        ],
        SearchId: "21147d79-577b-488a-af57-f80ea5dfb876",
        AppointmentId: "005B5ADFR",
        CreationDate: "2022-02-21T11:35:00Z",
        ValidStart: "2022-02-23T08:00:00Z",
        ValidEnd: "2022-02-23T13:00:00Z");

    public PostSearchAppointmentResponse GetSearchTimeSlotResponse(string trackingHeader, string productFamily, PostSearchAppointmentRequest request)
    {
        var profile = ProfileFor(productFamily);
        var requestedStart = request.RequestedTimeSlot[0].ValidFor.StartDateTime;
        var requested = DateTimeOffset.Parse(requestedStart, CultureInfo.InvariantCulture).UtcDateTime;
        var slotsStart = AppointmentAvailable() ? requested : requested.AddDays(Random.Shared.Next(MinDaysUntilAvailable, MaxDaysUntilAvailable + 1));
        var slots = BuildAvailableSlots(profile, slotsStart);

        return new PostSearchAppointmentResponse
        {
            Id = profile.SearchId,
            Status = "done",
            SearchDate = DateTime.UtcNow.ToString(profile.IsEthernet ? EthernetDateFormat : BroadbandDateFormat, CultureInfo.InvariantCulture),
            RelatedEntity =
            [
                new PostSearchAppointmentResponseRelatedEntity
                {
                    AppointmentType = "Standard",
                    SiteVisitReason = "Standard",
                    Product = new PostSearchAppointmentResponseRelatedEntityProduct
                    {
                        ProductSpecification = new PostSearchAppointmentResponseRelatedEntityProductProductSpecification
                        {
                            Id = profile.ProductSpecificationId
                        },
                        Characteristic = profile.Characteristics
                            .Select(c => new PostSearchAppointmentResponseRelatedEntityProductCharacteristic { Name = c.Name, Value = c.Value })
                            .ToList()
                    },
                    Id = Guid.NewGuid().ToString(),
                    Role = EntityRole,
                    ReferredType = EntityType,
                    Type = EntityType,
                    BaseType = EntityBaseType
                }
            ],
            RequestedTimeSlot =
            [
                new PostSearchAppointmentResponseRequestedTimeSlot
                {
                    ValidFor = new PostSearchAppointmentResponseRequestedTimeSlotValidFor { StartDateTime = requestedStart }
                }
            ],
            AvailableTimeSlot = slots
                .Select(s => new PostSearchAppointmentResponseAvailableTimeSlot
                {
                    Slot = s.Slot,
                    ValidFor = new PostSearchAppointmentResponseAvailableTimeSlotValidFor
                    {
                        StartDateTime = s.Start,
                        EndDateTime = s.End
                    }
                })
                .ToList()
        };
    }

    public PostAppointmentResponse GetCreateAppointmentResponse(string trackingHeader, string productFamily)
    {
        var profile = ProfileFor(productFamily);

        return new PostAppointmentResponse
        {
            Id = profile.AppointmentId,
            Status = "initialized",
            CreationDate = profile.CreationDate,
            RelatedEntity =
            [
                new PostAppointmentResponseRelatedEntity
                {
                    AppointmentType = "Standard",
                    SiteVisitReason = "Standard",
                    Product = new PostAppointmentResponseRelatedEntityProduct
                    {
                        ProductSpecification = new PostAppointmentResponseRelatedEntityProductProductSpecification
                        {
                            Id = profile.ProductSpecificationId
                        },
                        Characteristic = profile.Characteristics
                            .Select(c => new PostAppointmentResponseRelatedEntityProductCharacteristic { Name = c.Name, Value = c.Value })
                            .ToList()
                    },
                    Id = Guid.NewGuid().ToString(),
                    Role = EntityRole,
                    ReferredType = EntityType,
                    Type = EntityType,
                    BaseType = EntityBaseType
                }
            ],
            ValidFor = new PostAppointmentResponseValidFor
            {
                StartDateTime = profile.ValidStart,
                EndDateTime = profile.ValidEnd
            }
        };
    }

    private bool AppointmentAvailable()
    {
        return simulationHelper.GetSettings("SearchTimeSlot").AppointmentAvailable;
    }

    private static DateTime SkipSunday(DateTime value)
    {
        return value.DayOfWeek == DayOfWeek.Sunday ? value.AddDays(1) : value;
    }

    private static AppointmentProfile ProfileFor(string productFamily)
    {
        return string.Equals(productFamily, "Ethernet", StringComparison.OrdinalIgnoreCase) ? Ethernet : Broadband;
    }

    private static List<(string Slot, string Start, string End)> BuildAvailableSlots(AppointmentProfile profile, DateTime requestedStart)
    {
        return profile.IsEthernet ? BuildEthernetSlots(requestedStart) : BuildBroadbandSlots(requestedStart);
    }

    private static List<(string Slot, string Start, string End)> BuildEthernetSlots(DateTime requestedStart)
    {
                var slots = new List<(string, string, string)>();

        for (var i = 0; i < SlotCount; i++)
        {
            var start = SkipSunday(requestedStart.AddHours(EthernetSlotHours * i));
            var end = start.AddHours(EthernetSlotHours);
            slots.Add((start.ToString("HHmm", CultureInfo.InvariantCulture), start.ToString(EthernetDateFormat, CultureInfo.InvariantCulture), end.ToString(EthernetDateFormat, CultureInfo.InvariantCulture)));
        }

        return slots;
    }

    private static List<(string Slot, string Start, string End)> BuildBroadbandSlots(DateTime requestedStart)
    {
                var slots = new List<(string, string, string)>();
        var day = requestedStart.Date;
        var morning = requestedStart.Hour < BroadbandAfternoonStartHour;

        for (var i = 0; i < SlotCount; i++)
        {
            while (day.DayOfWeek == DayOfWeek.Sunday)
            {
                day = day.AddDays(1);
                morning = true;
            }

            var start = day.AddHours(morning ? BroadbandMorningStartHour : BroadbandAfternoonStartHour);
            var end = day.AddHours(morning ? BroadbandAfternoonStartHour : BroadbandAfternoonEndHour);
            slots.Add((morning ? "AM" : "PM", start.ToString(BroadbandDateFormat, CultureInfo.InvariantCulture), end.ToString(BroadbandDateFormat, CultureInfo.InvariantCulture)));

            if (morning)
            {
                morning = false;
            }
            else
            {
                morning = true;
                day = day.AddDays(1);
            }
        }

        return slots;
    }

    private sealed record AppointmentProfile(
        bool IsEthernet,
        string ProductSpecificationId,
        (string Name, string Value)[] Characteristics,
        string SearchId,
        string AppointmentId,
        string CreationDate,
        string ValidStart,
        string ValidEnd);
}
