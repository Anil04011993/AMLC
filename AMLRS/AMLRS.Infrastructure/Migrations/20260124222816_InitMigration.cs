using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMLRS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditLogId);
                });

            migrationBuilder.CreateTable(
                name: "EntityProfile",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfIncorporation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeCycleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskRating = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityProfile", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComposable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAnalyses",
                columns: table => new
                {
                    AnalysisId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MakerUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Narrative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvidenceMetadata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAnalyses", x => x.AnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AccountPurposeExpectedActivities",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimaryPurposeofAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntendedProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedMonthlyDepositRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedMonthlyWithdrawalRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedMonthlyTransactionCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedAverageTransactionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryIncomingPaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryOutgoingPaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedCountriesforIncomingTransfers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedCountriesforOutgoingTransfers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedUseofCash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedUseofCrypto_VirtualAssets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes_Rationale = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPurposeExpectedActivities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_AccountPurposeExpectedActivities_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficialOwnerships",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerEntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlType = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficialOwnerships", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_BeneficialOwnerships_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOverDue = table.Column<bool>(type: "bit", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewerUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLeadUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlaDays = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Case_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIndentities",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncorporationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperatingCountries = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIndentities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_CompanyIndentities_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsentAndAttestations",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreeningConsent = table.Column<bool>(type: "bit", nullable: true),
                    ConsentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAccuracyAttestation = table.Column<bool>(type: "bit", nullable: true),
                    ActingOnOwnBehalf = table.Column<bool>(type: "bit", nullable: true),
                    ThirdPartyBeneficiary = table.Column<bool>(type: "bit", nullable: true),
                    AttestationMethod = table.Column<int>(type: "int", nullable: true),
                    AttestedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsentAndAttestations", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ConsentAndAttestations_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContinuousMonitoringRiskRefreshes",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Last_risk_refresh_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Last_screening_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinuousMonitoringRiskRefreshes", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ContinuousMonitoringRiskRefreshes_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentFinancialProfiles",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncomeRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyNetIncomeRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedNetWorthRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceofFunds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceofWealth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedSourceofIncomingFunds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashIntensiveBusinessExposure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighRiskIndustryExposure = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentFinancialProfiles", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_EmploymentFinancialProfiles_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnhancedBeneficialOwnershipMetadatas",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeneficialOwnershipComplexity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnhancedBeneficialOwnershipMetadatas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_EnhancedBeneficialOwnershipMetadatas_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpandedRiskProfilings",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Geographic_risk_score = table.Column<int>(type: "int", nullable: true),
                    Overall_external_risk_score = table.Column<int>(type: "int", nullable: true),
                    Risk_profile_last_trigger = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandedRiskProfilings", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ExpandedRiskProfilings_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtendedIdentityVerifications",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Identity_verification_provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identity_verification_result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biometric_match_score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedIdentityVerifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ExtendedIdentityVerifications_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationResidencies",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDIssuingCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDIssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofAddressDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofAddressIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryResidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidencyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsatCurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreeningConsent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationResidencies", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_IdentificationResidencies_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualIdentities",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguagePreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualIdentities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_IndividualIdentities_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MailingAddresses",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPreference = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingAddresses", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_MailingAddresses_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetadataAudits",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_reviewed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Last_refreshed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data_source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confidence_score = table.Column<int>(type: "int", nullable: true),
                    Is_snapshot_locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataAudits", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_MetadataAudits_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEPDeclarations",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IscustomerPoliticallyExposedPerson = table.Column<bool>(type: "bit", nullable: false),
                    IscustomerfamilymemberorcloseassociateofaPEP = table.Column<bool>(type: "bit", nullable: false),
                    PEPCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PEPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Jurisdiction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshiptoCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRoleStarted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRoleEnded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEPDeclarations", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PEPDeclarations_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialAddresses",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialAddresses", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ResidentialAddresses_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningWatchlists",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sanctions_list_matched = table.Column<bool>(type: "bit", nullable: true),
                    Sanctions_match_lists = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sanctions_match_score = table.Column<int>(type: "int", nullable: true),
                    Sanctions_last_screened_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adverse_media_flag_detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningWatchlists", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ScreeningWatchlists_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxSelfCertifications",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Customerconfirmsprovidedtaxinformationisaccurate = table.Column<bool>(type: "bit", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TINCountryofIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonforNoTIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customerdeclarestheyareactingontheirownbehalf = table.Column<bool>(type: "bit", nullable: false),
                    Customerdeclaresaccountisnotforathirdpartybeneficiary = table.Column<bool>(type: "bit", nullable: false),
                    SignatureOrAttestationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttestationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSelfCertifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TaxSelfCertifications_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VersioningLifecycles",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Validity_start_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Validity_end_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEntityDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Source_system = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source_record_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersioningLifecycles", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_VersioningLifecycles_EntityProfile_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityProfile",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Access_Control_ABAC",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserAttributesMap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeSetVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContextRoles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_Control_ABAC", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Access_Control_ABAC_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit_Metadata",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedInSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastRoleChangeAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessContextHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Metadata", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Audit_Metadata_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auth_and_Securities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordLastChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MfaEnabled = table.Column<bool>(type: "bit", nullable: false),
                    MfaMethod = table.Column<int>(type: "int", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    AccountLocked = table.Column<bool>(type: "bit", nullable: false),
                    PasswordResetRequired = table.Column<bool>(type: "bit", nullable: false),
                    LastPasswordResetAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionExpiryAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthProvider = table.Column<int>(type: "int", nullable: false),
                    AuthProviderUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IpWhitelist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceTrustScore = table.Column<int>(type: "int", nullable: true),
                    LockReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_and_Securities", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Auth_and_Securities_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compliance_Trainings",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmlTrainingCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AmlTrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleCertification = table.Column<int>(type: "int", nullable: false),
                    LastCertificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BackgroundCheckPassed = table.Column<bool>(type: "bit", nullable: false),
                    SanctionsCheckPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compliance_Trainings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Compliance_Trainings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decommission_Lifecycles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LinkedEntityId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decommission_Lifecycles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Decommission_Lifecycles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Governance_Compliance_Metadata",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComplianceRoleExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComplianceFlags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastAccessReviewAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessReviewDueAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governance_Compliance_Metadata", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Governance_Compliance_Metadata_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Integration_External_Identities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExternalIdentityProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalGroups = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FederationId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integration_External_Identities", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Integration_External_Identities_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localization_UX",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UiThemePreference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization_UX", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Localization_UX_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification_and_preferences",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotificationChannels = table.Column<int>(type: "int", nullable: false),
                    NotificationFrequency = table.Column<int>(type: "int", nullable: false),
                    LanguagePreference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification_and_preferences", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Notification_and_preferences_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications_Alerts",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastNotificationSentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotificationOptOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications_Alerts", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Notifications_Alerts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operational_Behavior_Signals",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastPasswordLoginLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPasswordLoginDevice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighRiskUserFlag = table.Column<bool>(type: "bit", nullable: false),
                    RiskScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operational_Behavior_Signals", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Operational_Behavior_Signals_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Optional_UX_Enhancements",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDashboard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Optional_UX_Enhancements", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Optional_UX_Enhancements_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_and_permissions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    Teams = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkQueueAccess = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_and_permissions", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Role_and_permissions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleAssignments",
                columns: table => new
                {
                    UserRoleAssignmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleAssignments", x => x.UserRoleAssignmentId);
                    table.ForeignKey(
                        name: "FK_UserRoleAssignments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleAssignments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseSlaTrackers",
                columns: table => new
                {
                    SlaTrackerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBreached = table.Column<bool>(type: "bit", nullable: false),
                    BreachedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSlaTrackers", x => x.SlaTrackerId);
                    table.ForeignKey(
                        name: "FK_CaseSlaTrackers_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatusHistories",
                columns: table => new
                {
                    HistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OldStatus = table.Column<int>(type: "int", nullable: false),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatusHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_CaseStatusHistories_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientOutreaches",
                columns: table => new
                {
                    OutreachId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOutreaches", x => x.OutreachId);
                    table.ForeignKey(
                        name: "FK_ClientOutreaches_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    IsLatest = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidationRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KycScreeningRuns",
                columns: table => new
                {
                    KycScreeningRunId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreenedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalHits = table.Column<int>(type: "int", nullable: false),
                    PendingHits = table.Column<int>(type: "int", nullable: false),
                    InitiatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitiatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KycScreeningRuns", x => x.KycScreeningRunId);
                    table.ForeignKey(
                        name: "FK_KycScreeningRuns_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STRSARReports",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DraftNarrative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalNarrative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedToRegulator = table.Column<bool>(type: "bit", nullable: false),
                    SubmissionTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STRSARReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_STRSARReports_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workstream",
                columns: table => new
                {
                    WorkstreamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workstream", x => x.WorkstreamId);
                    table.ForeignKey(
                        name: "FK_Workstream_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientOutreachResponses",
                columns: table => new
                {
                    ResponseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OutreachId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSatisfactory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOutreachResponses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_ClientOutreachResponses_ClientOutreaches_OutreachId",
                        column: x => x.OutreachId,
                        principalTable: "ClientOutreaches",
                        principalColumn: "OutreachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentValidationResults",
                columns: table => new
                {
                    ResultId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLivenessDetected = table.Column<bool>(type: "bit", nullable: false),
                    IsDeepfakeDetected = table.Column<bool>(type: "bit", nullable: false),
                    ConfidenceScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidationResult = table.Column<int>(type: "int", nullable: false),
                    ValidatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentValidationResults", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_DocumentValidationResults_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KycHits",
                columns: table => new
                {
                    KycHitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KycScreeningRunId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HitType = table.Column<int>(type: "int", nullable: false),
                    MatchedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchStrength = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KycHits", x => x.KycHitId);
                    table.ForeignKey(
                        name: "FK_KycHits_KycScreeningRuns_KycScreeningRunId",
                        column: x => x.KycScreeningRunId,
                        principalTable: "KycScreeningRuns",
                        principalColumn: "KycScreeningRunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAlerts",
                columns: table => new
                {
                    AlertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeneratedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertType = table.Column<int>(type: "int", nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnalysisId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAlerts", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_TransactionAlerts_TransactionAnalyses_AnalysisId",
                        column: x => x.AnalysisId,
                        principalTable: "TransactionAnalyses",
                        principalColumn: "AnalysisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAlerts_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KycHitReviews",
                columns: table => new
                {
                    KycHitReviewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KycHitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewRole = table.Column<int>(type: "int", nullable: false),
                    Decision = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KycHitReviews", x => x.KycHitReviewId);
                    table.ForeignKey(
                        name: "FK_KycHitReviews_KycHits_KycHitId",
                        column: x => x.KycHitId,
                        principalTable: "KycHits",
                        principalColumn: "KycHitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EntityProfile",
                columns: new[] { "EntityId", "CountryOfIncorporation", "CreatedAt", "EntityName", "EntityType", "LegalName", "LifeCycleStatus", "PrimaryIdentifier", "RiskRating", "UpdatedAt", "VerificationStatus" },
                values: new object[,]
                {
                    { "IND-2024-0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan Michael Smith", "Individual", null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "IND-2024-0002", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Financial Services", "Company", null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "IND-2024-0003", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Corp Holdings Ltd", "Company", null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "IND-2024-0004", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Corp Holdings Ltd", "Company", null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Case",
                columns: new[] { "CaseId", "CaseNumber", "CreatedAt", "DueDate", "EntityId", "IsLocked", "IsOverDue", "Owner", "RejectionReason", "ReviewerUserId", "RiskLevel", "ServiceType", "SlaDays", "Stage", "Status", "TeamLeadUserId", "Tier", "UpdatedAt" },
                values: new object[,]
                {
                    { "C-2024-0901", "C-2024-0901", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "IND-2024-0001", false, false, "UserSarahChen", "NoReason", null, "Medium", "KYCCase", 0, "Screening", "InProgress", null, "Tier_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "C-2024-0902", "KYC-2024-0901", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "IND-2024-0001", false, false, "UserMichaelTorres", "NoReason", null, "Medium", "KYCCase", 0, "Screening", "InProgress", null, "Tier_2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "C-2024-9802", "KYC-2024-0910", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "IND-2024-0002", false, false, "UserMichaelTorres", "NoReason", null, "Medium", "KYCCase", 0, "Screening", "InProgress", null, "Tier_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "C-2024-9811", "KYC-2024-0912", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "IND-2024-0003", false, false, "UserMichaelTorres", "NoReason", null, "Medium", "KYCCase", 0, "Screening", "InProgress", null, "Tier_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "C-2024-9812", "KYC-2024-0920", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "IND-2024-0004", false, false, "UserMichaelTorres", "NoReason", null, "Medium", "TransactionMonitoring", 0, "Screening", "Assigned", null, "Tier_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Workstream",
                columns: new[] { "WorkstreamId", "CaseId", "Maker", "Owner", "Status", "Type" },
                values: new object[,]
                {
                    { "WS-001", "C-2024-0901", "Michael Torres", "Sarah Chen", "New", "KYCCase" },
                    { "WS-002", "C-2024-0901", "Michael Torres", "Sarah Chen", "InProgress", "TransactionMonitoring" },
                    { "WS-003", "C-2024-0901", "Michael Torres", "Sarah Chen", "Rejected", "ClientOutreach" },
                    { "WS-004", "C-2024-0902", "Michael Torres", "Sarah Chen", "New", "KYCCase" },
                    { "WS-005", "C-2024-0902", "Michael Torres", "Sarah Chen", "InProgress", "TransactionMonitoring" },
                    { "WS-006", "C-2024-0902", "Michael Torres", "Sarah Chen", "Rejected", "ClientOutreach" },
                    { "WS-007", "C-2024-9802", null, null, "New", "KYCCase" },
                    { "WS-008", "C-2024-9802", null, null, "InProgress", "TransactionMonitoring" },
                    { "WS-009", "C-2024-9802", null, null, "Rejected", "ClientOutreach" },
                    { "WS-010", "C-2024-9811", null, null, "New", "KYCCase" },
                    { "WS-011", "C-2024-9811", null, null, "InProgress", "TransactionMonitoring" },
                    { "WS-012", "C-2024-9811", null, null, "Rejected", "ClientOutreach" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_EntityId",
                table: "Case",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseSlaTrackers_CaseId",
                table: "CaseSlaTrackers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatusHistories_CaseId",
                table: "CaseStatusHistories",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOutreaches_CaseId",
                table: "ClientOutreaches",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOutreachResponses_OutreachId",
                table: "ClientOutreachResponses",
                column: "OutreachId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CaseId",
                table: "Documents",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentValidationResults_DocumentId",
                table: "DocumentValidationResults",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KycHitReviews_KycHitId",
                table: "KycHitReviews",
                column: "KycHitId");

            migrationBuilder.CreateIndex(
                name: "IX_KycHits_KycScreeningRunId",
                table: "KycHits",
                column: "KycScreeningRunId");

            migrationBuilder.CreateIndex(
                name: "IX_KycScreeningRuns_CaseId",
                table: "KycScreeningRuns",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_STRSARReports_CaseId",
                table: "STRSARReports",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAlerts_AnalysisId",
                table: "TransactionAlerts",
                column: "AnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAlerts_TransactionId",
                table: "TransactionAlerts",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CaseId",
                table: "Transactions",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAssignments_RoleId",
                table: "UserRoleAssignments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAssignments_UserId",
                table: "UserRoleAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workstream_CaseId",
                table: "Workstream",
                column: "CaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_Control_ABAC");

            migrationBuilder.DropTable(
                name: "AccountPurposeExpectedActivities");

            migrationBuilder.DropTable(
                name: "Audit_Metadata");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Auth_and_Securities");

            migrationBuilder.DropTable(
                name: "BeneficialOwnerships");

            migrationBuilder.DropTable(
                name: "CaseSlaTrackers");

            migrationBuilder.DropTable(
                name: "CaseStatusHistories");

            migrationBuilder.DropTable(
                name: "ClientOutreachResponses");

            migrationBuilder.DropTable(
                name: "CompanyIndentities");

            migrationBuilder.DropTable(
                name: "Compliance_Trainings");

            migrationBuilder.DropTable(
                name: "ConsentAndAttestations");

            migrationBuilder.DropTable(
                name: "ContinuousMonitoringRiskRefreshes");

            migrationBuilder.DropTable(
                name: "Decommission_Lifecycles");

            migrationBuilder.DropTable(
                name: "DocumentValidationResults");

            migrationBuilder.DropTable(
                name: "EmploymentFinancialProfiles");

            migrationBuilder.DropTable(
                name: "EnhancedBeneficialOwnershipMetadatas");

            migrationBuilder.DropTable(
                name: "ExpandedRiskProfilings");

            migrationBuilder.DropTable(
                name: "ExtendedIdentityVerifications");

            migrationBuilder.DropTable(
                name: "Governance_Compliance_Metadata");

            migrationBuilder.DropTable(
                name: "IdentificationResidencies");

            migrationBuilder.DropTable(
                name: "IndividualIdentities");

            migrationBuilder.DropTable(
                name: "Integration_External_Identities");

            migrationBuilder.DropTable(
                name: "KycHitReviews");

            migrationBuilder.DropTable(
                name: "Localization_UX");

            migrationBuilder.DropTable(
                name: "MailingAddresses");

            migrationBuilder.DropTable(
                name: "MetadataAudits");

            migrationBuilder.DropTable(
                name: "Notification_and_preferences");

            migrationBuilder.DropTable(
                name: "Notifications_Alerts");

            migrationBuilder.DropTable(
                name: "Operational_Behavior_Signals");

            migrationBuilder.DropTable(
                name: "Optional_UX_Enhancements");

            migrationBuilder.DropTable(
                name: "PEPDeclarations");

            migrationBuilder.DropTable(
                name: "ResidentialAddresses");

            migrationBuilder.DropTable(
                name: "Role_and_permissions");

            migrationBuilder.DropTable(
                name: "ScreeningWatchlists");

            migrationBuilder.DropTable(
                name: "STRSARReports");

            migrationBuilder.DropTable(
                name: "TaxSelfCertifications");

            migrationBuilder.DropTable(
                name: "TransactionAlerts");

            migrationBuilder.DropTable(
                name: "UserRoleAssignments");

            migrationBuilder.DropTable(
                name: "VersioningLifecycles");

            migrationBuilder.DropTable(
                name: "Workstream");

            migrationBuilder.DropTable(
                name: "ClientOutreaches");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "KycHits");

            migrationBuilder.DropTable(
                name: "TransactionAnalyses");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "KycScreeningRuns");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "EntityProfile");
        }
    }
}
