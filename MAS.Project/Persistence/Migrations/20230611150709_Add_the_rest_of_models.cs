using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Project.Migrations
{
    /// <inheritdoc />
    public partial class Add_the_rest_of_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardPrice = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDuration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxDuration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    RecommendationsBeforeService = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalWorkerServiceType",
                columns: table => new
                {
                    AuthorizedMedicalWorkersId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizedServiceTypesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalWorkerServiceType", x => new { x.AuthorizedMedicalWorkersId, x.AuthorizedServiceTypesId });
                    table.ForeignKey(
                        name: "FK_MedicalWorkerServiceType_MedicalWorker_AuthorizedMedicalWorkersId",
                        column: x => x.AuthorizedMedicalWorkersId,
                        principalTable: "MedicalWorker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalWorkerServiceType_ServiceType_AuthorizedServiceTypesId",
                        column: x => x.AuthorizedServiceTypesId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    CronForTimeSlotGeneration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalWorkerService",
                columns: table => new
                {
                    ConductedServicesId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalWorkersConductingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalWorkerService", x => new { x.ConductedServicesId, x.MedicalWorkersConductingId });
                    table.ForeignKey(
                        name: "FK_MedicalWorkerService_MedicalWorker_MedicalWorkersConductingId",
                        column: x => x.MedicalWorkersConductingId,
                        principalTable: "MedicalWorker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalWorkerService_Service_ConductedServicesId",
                        column: x => x.ConductedServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTimeSlot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    PatientsNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    PatientBookedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTimeSlot_Patient_PatientBookedById",
                        column: x => x.PatientBookedById,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTimeSlot_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientIssuedForId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceResult_Patient_PatientIssuedForId",
                        column: x => x.PatientIssuedForId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceResult_ServiceTimeSlot_Id",
                        column: x => x.Id,
                        principalTable: "ServiceTimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "date", nullable: false),
                    ServiceResultId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorIssuedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_DoctorIssuedById",
                        column: x => x.DoctorIssuedById,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_ServiceResult_ServiceResultId",
                        column: x => x.ServiceResultId,
                        principalTable: "ServiceResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReferral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expires = table.Column<DateTime>(type: "date", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorIssuedById = table.Column<long>(type: "bigint", nullable: false),
                    ServiceResultId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReferral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReferral_Doctor_DoctorIssuedById",
                        column: x => x.DoctorIssuedById,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReferral_ServiceResult_ServiceResultId",
                        column: x => x.ServiceResultId,
                        principalTable: "ServiceResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReferral_ServiceTimeSlot_Id",
                        column: x => x.Id,
                        principalTable: "ServiceTimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReferral_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SickLeave",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorIssuedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SickLeave_Doctor_DoctorIssuedById",
                        column: x => x.DoctorIssuedById,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SickLeave_ServiceResult_Id",
                        column: x => x.Id,
                        principalTable: "ServiceResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationOnPrescription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    FractionRefunded = table.Column<decimal>(type: "decimal(8,5)", precision: 8, scale: 5, nullable: false),
                    PrescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    MedicationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationOnPrescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationOnPrescription_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicationOnPrescription_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWorkerService_MedicalWorkersConductingId",
                table: "MedicalWorkerService",
                column: "MedicalWorkersConductingId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWorkerServiceType_AuthorizedServiceTypesId",
                table: "MedicalWorkerServiceType",
                column: "AuthorizedServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOnPrescription_MedicationId",
                table: "MedicationOnPrescription",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOnPrescription_PrescriptionId",
                table: "MedicationOnPrescription",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorIssuedById",
                table: "Prescription",
                column: "DoctorIssuedById");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ServiceResultId",
                table: "Prescription",
                column: "ServiceResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReferral_DoctorIssuedById",
                table: "ServiceReferral",
                column: "DoctorIssuedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReferral_ServiceResultId",
                table: "ServiceReferral",
                column: "ServiceResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReferral_ServiceTypeId",
                table: "ServiceReferral",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceResult_PatientIssuedForId",
                table: "ServiceResult",
                column: "PatientIssuedForId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlot_PatientBookedById",
                table: "ServiceTimeSlot",
                column: "PatientBookedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlot_ServiceId",
                table: "ServiceTimeSlot",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SickLeave_DoctorIssuedById",
                table: "SickLeave",
                column: "DoctorIssuedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalWorkerService");

            migrationBuilder.DropTable(
                name: "MedicalWorkerServiceType");

            migrationBuilder.DropTable(
                name: "MedicationOnPrescription");

            migrationBuilder.DropTable(
                name: "ServiceReferral");

            migrationBuilder.DropTable(
                name: "SickLeave");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "ServiceResult");

            migrationBuilder.DropTable(
                name: "ServiceTimeSlot");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ServiceType");
        }
    }
}
