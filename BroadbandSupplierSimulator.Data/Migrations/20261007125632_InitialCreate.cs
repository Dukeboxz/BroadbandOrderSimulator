using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BroadbandSupplierSimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RequestedCompletionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReceivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_AccountId = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_BaseType = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    ItemId = table.Column<string>(type: "text", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    SubStatus = table.Column<string>(type: "text", nullable: true),
                    InternalId = table.Column<string>(type: "text", nullable: true),
                    AmendmentStatus = table.Column<string>(type: "text", nullable: true),
                    CancellationStatus = table.Column<string>(type: "text", nullable: true),
                    RequestedCompletionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ExpectedCompletionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CompletionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Appointment_AppointmentFinish = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Appointment_AppointmentId = table.Column<string>(type: "text", nullable: true),
                    Appointment_AppointmentStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Appointment_AppointmentStatus = table.Column<string>(type: "text", nullable: true),
                    Appointment_BaseType = table.Column<string>(type: "text", nullable: true),
                    Appointment_BesAppointmentId = table.Column<string>(type: "text", nullable: true),
                    Appointment_Description = table.Column<string>(type: "text", nullable: true),
                    Appointment_Type = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_AccountId = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_BaseType = table.Column<string>(type: "text", nullable: true),
                    BillingAccount_Type = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_BaseType = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_Name = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_OfferingId = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_ProductFamily = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_Type = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_BaseType = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_ItemId = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_QualificationId = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_QualificationName = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_ReferredType = table.Column<string>(type: "text", nullable: true),
                    ProductOfferingQualificationItem_Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrderItems_ProductOrderItems_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "ProductOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrderItems_ProductOrders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "ProductOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelationshipId = table.Column<string>(type: "text", nullable: true),
                    RelationshipType = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemRelationships_ProductOrderItems_ProductOrderItemId",
                        column: x => x.ProductOrderItemId,
                        principalTable: "ProductOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductOrderItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    Kind = table.Column<string>(type: "text", nullable: false),
                    NoteId = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "character varying(3999)", maxLength: 3999, nullable: false),
                    NoteType = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotes_ProductOrderItems_ProductOrderItemId",
                        column: x => x.ProductOrderItemId,
                        principalTable: "ProductOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderNotes_ProductOrders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "ProductOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderQualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    QualificationId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ReferredType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderQualifications_ProductOrderItems_ProductOrderItemId",
                        column: x => x.ProductOrderItemId,
                        principalTable: "ProductOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCharacteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ValueType = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    PreviousValue = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderContactMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderRelatedPartyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediumType = table.Column<string>(type: "text", nullable: true),
                    ContactType = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    FaxNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Address_AddressId = table.Column<string>(type: "text", nullable: true),
                    Address_AddressMatch = table.Column<bool>(type: "boolean", nullable: true),
                    Address_AddressSource = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_DistrictCode = table.Column<string>(type: "text", nullable: true),
                    Address_ExchangeGroupCode = table.Column<string>(type: "text", nullable: true),
                    Address_Locality = table.Column<string>(type: "text", nullable: true),
                    Address_MatchedId = table.Column<string>(type: "text", nullable: true),
                    Address_ParentUprn = table.Column<string>(type: "text", nullable: true),
                    Address_Postcode = table.Column<string>(type: "text", nullable: true),
                    Address_Qualifier = table.Column<string>(type: "text", nullable: true),
                    Address_StateOrProvince = table.Column<string>(type: "text", nullable: true),
                    Address_StreetName = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNr = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrLast = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrLastSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetType = table.Column<string>(type: "text", nullable: true),
                    Address_Uprn = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Accuracy = table.Column<string>(type: "text", nullable: true),
                    Address_Location_GeometryType = table.Column<string>(type: "text", nullable: true),
                    Address_Location_LocationId = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Location_SpatialRef = table.Column<string>(type: "text", nullable: true),
                    Address_Location_X = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Y = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Z = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_BuildingName = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_LevelNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_LevelType = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_Name = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_PrivateStreetName = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_PrivateStreetNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubAddressId = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubUnitNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubUnitType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContactMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaceId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Address_AddressId = table.Column<string>(type: "text", nullable: true),
                    Address_AddressMatch = table.Column<bool>(type: "boolean", nullable: true),
                    Address_AddressSource = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_DistrictCode = table.Column<string>(type: "text", nullable: true),
                    Address_ExchangeGroupCode = table.Column<string>(type: "text", nullable: true),
                    Address_Locality = table.Column<string>(type: "text", nullable: true),
                    Address_MatchedId = table.Column<string>(type: "text", nullable: true),
                    Address_ParentUprn = table.Column<string>(type: "text", nullable: true),
                    Address_Postcode = table.Column<string>(type: "text", nullable: true),
                    Address_Qualifier = table.Column<string>(type: "text", nullable: true),
                    Address_StateOrProvince = table.Column<string>(type: "text", nullable: true),
                    Address_StreetName = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNr = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrLast = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrLastSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetNrSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetSuffix = table.Column<string>(type: "text", nullable: true),
                    Address_StreetType = table.Column<string>(type: "text", nullable: true),
                    Address_Uprn = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Accuracy = table.Column<string>(type: "text", nullable: true),
                    Address_Location_GeometryType = table.Column<string>(type: "text", nullable: true),
                    Address_Location_LocationId = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Location_SpatialRef = table.Column<string>(type: "text", nullable: true),
                    Address_Location_X = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Y = table.Column<string>(type: "text", nullable: true),
                    Address_Location_Z = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_BuildingName = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_LevelNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_LevelType = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_Name = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_PrivateStreetName = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_PrivateStreetNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubAddressId = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubUnitNumber = table.Column<string>(type: "text", nullable: true),
                    Address_SubAddress_SubUnitType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductRelationshipId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProductSerialNumber = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    TerminationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    PreviousId = table.Column<string>(type: "text", nullable: true),
                    CustomerFacingServiceId_PreviousValue = table.Column<string>(type: "text", nullable: true),
                    CustomerFacingServiceId_Value = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_BaseType = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_Name = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_OfferingId = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_ProductFamily = table.Column<string>(type: "text", nullable: true),
                    ProductOffering_Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_ProductOrderItems_ProductOrderItemId",
                        column: x => x.ProductOrderItemId,
                        principalTable: "ProductOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRelatedParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    PartyId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ReferredType = table.Column<string>(type: "text", nullable: false),
                    FamilyName = table.Column<string>(type: "text", nullable: true),
                    GivenName = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRelatedParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRelatedParties_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRelatedParties_ProductOrders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "ProductOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelationshipType = table.Column<string>(type: "text", nullable: false),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRelationships_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharacteristics_OrderProductId",
                table: "OrderCharacteristics",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContactMedia_OrderRelatedPartyId",
                table: "OrderContactMedia",
                column: "OrderRelatedPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemRelationships_ProductOrderItemId",
                table: "OrderItemRelationships",
                column: "ProductOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_ProductOrderId",
                table: "OrderNotes",
                column: "ProductOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_ProductOrderItemId",
                table: "OrderNotes",
                column: "ProductOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlaces_OrderProductId",
                table: "OrderPlaces",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductOrderItemId",
                table: "OrderProducts",
                column: "ProductOrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductRelationshipId",
                table: "OrderProducts",
                column: "ProductRelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderQualifications_ProductOrderItemId",
                table: "OrderQualifications",
                column: "ProductOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRelatedParties_OrderProductId",
                table: "OrderRelatedParties",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRelatedParties_ProductOrderId",
                table: "OrderRelatedParties",
                column: "ProductOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderItems_ParentItemId",
                table: "ProductOrderItems",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderItems_ProductOrderId_ItemId",
                table: "ProductOrderItems",
                columns: new[] { "ProductOrderId", "ItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ExternalId",
                table: "ProductOrders",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRelationships_OrderProductId",
                table: "ProductRelationships",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCharacteristics_OrderProducts_OrderProductId",
                table: "OrderCharacteristics",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContactMedia_OrderRelatedParties_OrderRelatedPartyId",
                table: "OrderContactMedia",
                column: "OrderRelatedPartyId",
                principalTable: "OrderRelatedParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlaces_OrderProducts_OrderProductId",
                table: "OrderPlaces",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductRelationships_ProductRelationshipId",
                table: "OrderProducts",
                column: "ProductRelationshipId",
                principalTable: "ProductRelationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRelationships_OrderProducts_OrderProductId",
                table: "ProductRelationships");

            migrationBuilder.DropTable(
                name: "OrderCharacteristics");

            migrationBuilder.DropTable(
                name: "OrderContactMedia");

            migrationBuilder.DropTable(
                name: "OrderItemRelationships");

            migrationBuilder.DropTable(
                name: "OrderNotes");

            migrationBuilder.DropTable(
                name: "OrderPlaces");

            migrationBuilder.DropTable(
                name: "OrderQualifications");

            migrationBuilder.DropTable(
                name: "OrderRelatedParties");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductOrderItems");

            migrationBuilder.DropTable(
                name: "ProductRelationships");

            migrationBuilder.DropTable(
                name: "ProductOrders");
        }
    }
}
