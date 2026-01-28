using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Core.Domains.EntityProfiles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AMLRS.Infrastructure.Config
{
    public class EntityProfileConfig : IEntityTypeConfiguration<EntityProfile>
    {
        public void Configure(EntityTypeBuilder<EntityProfile> builder)
        {
            builder.ToTable(nameof(EntityProfile));
            builder.HasKey(x => x.EntityId);

            builder.Property(e => e.EntityType)
                       .HasConversion<string>();
            builder.HasOne(e => e.IndividualIdentity)
                .WithOne(i => i.EntityProfile)
                .HasForeignKey<IndividualIdentity>(i => i.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CompanyIndentity)
                .WithOne(c => c.EntityProfile)
                .HasForeignKey<CompanyIndentity>(c => c.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ResidentialAddress)
                .WithOne(i => i.EntityProfile)
                .HasForeignKey<ResidentialAddress>(i => i.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MailingAddress)
                .WithOne(c => c.EntityProfile)
                .HasForeignKey<MailingAddress>(c => c.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IdentificationResidency)
                .WithOne(i => i.EntityProfile)
                .HasForeignKey<IdentificationResidency>(i => i.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.EmploymentFinancialProfile)
                .WithOne(c => c.EntityProfile)
                .HasForeignKey<EmploymentFinancialProfile>(c => c.EntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.AccountPurposeExpectedActivity)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<AccountPurposeExpectedActivity>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.PEPDeclaration)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<PEPDeclaration>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.TaxSelfCertification)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<TaxSelfCertification>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.BeneficialOwnership)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<BeneficialOwnership>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ConsentAndAttestations)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<ConsentAndAttestations>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MetadataAudit)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<MetadataAudit>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.VersioningLifecycle)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<VersioningLifecycle>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ScreeningWatchlists)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<ScreeningWatchlists>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ContinuousMonitoringRiskRefresh)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<ContinuousMonitoringRiskRefresh>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ExpandedRiskProfiling)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<ExpandedRiskProfiling>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ExtendedIdentityVerification)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<ExtendedIdentityVerification>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.EnhancedBeneficialOwnershipMetadata)
               .WithOne(c => c.EntityProfile)
               .HasForeignKey<EnhancedBeneficialOwnershipMetadata>(c => c.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            /*
            //builder.OwnsOne(e => e.BeneficialOwnership).HasData();
            //builder.OwnsOne(e => e.ConsentAndAttestations).HasData();
            //builder.OwnsOne(e => e.ContinuousMonitoringRiskRefresh).HasData();
            //builder.OwnsOne(e => e.EnhancedBeneficialOwnershipMetadata).HasData();
            //builder.OwnsOne(e => e.ExpandedRiskProfiling).HasData();
            //builder.OwnsOne(e => e.ExtendedIdentityVerification).HasData();
            //builder.OwnsOne(e => e.MetadataAudit).HasData();
            //builder.OwnsOne(e => e.ScreeningWatchlists).HasData();
            //builder.OwnsOne(e => e.VersioningLifecycle).HasData();
            
            builder.OwnsOne(e => e.IndividualIdentity)
           .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0001",
                    FirstName = "John",
                    MiddleName = "Gems",
                    LastName = "Smith",
                    PreferredName = "John Smith",
                    Gender = "male",
                    Nationality = "US"
                }
                );

            builder.OwnsOne(e => e.CompanyIndentity)
           .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0002",
                    BusinessType = BusinessType.Corporation,
                    Industry = "Corporation",
                    OperatingCountries = "US",
                },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0003",
                     BusinessType = BusinessType.Foundation,
                     Industry = "Foundation",
                     OperatingCountries = "US",
                 },
                  new
                  {
                      EntityProfileEntityId = "IND-2024-0004",
                      BusinessType = BusinessType.Partnership,
                      Industry = "Partnership",
                      OperatingCountries = "US",
                  }
                );

            builder.OwnsOne(e => e.ResidentialAddress)
            .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0001", // 🔥 REQUIRED
                    AddressLine1 = "Pune",
                    City = "Pune",
                    State = "MH",
                    PostalCode = "411001",
                    Country = "India"
                },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0002", // 🔥 REQUIRED
                     AddressLine1 = "Pune",
                     City = "Pune",
                     State = "MH",
                     PostalCode = "411001",
                     Country = "India"
                 },
                  new
                  {
                      EntityProfileEntityId = "IND-2024-0003", // 🔥 REQUIRED
                      AddressLine1 = "Pune",
                      City = "Pune",
                      State = "MH",
                      PostalCode = "411001",
                      Country = "India"
                  },
                   new
                   {
                       EntityProfileEntityId = "IND-2024-0004", // 🔥 REQUIRED
                       AddressLine1 = "Pune",
                       City = "Pune",
                       State = "MH",
                       PostalCode = "411001",
                       Country = "India"
                   }
            );

            builder.OwnsOne(e => e.MailingAddress)
                .HasData(
                 new 
                 {
                     EntityProfileEntityId = "IND-2024-0001", // 🔥 REQUIRED
                     PhoneNumber = "5688664646",
                     SecondaryPhone = "",
                     EmailAddress = "AcmeCorpHoldings@",
                     SecondaryEmail = "",
                     AddressType = ContactPreference.Email,
                 },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0002", // 🔥 REQUIRED
                     PhoneNumber = "5688664646",
                     SecondaryPhone = "",
                     EmailAddress = "AcmeCorpHoldings@",
                     SecondaryEmail = "",
                     AddressType = ContactPreference.Email,
                 },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0003", // 🔥 REQUIRED
                     PhoneNumber = "5688664646",
                     SecondaryPhone = "",
                     EmailAddress = "AcmeCorpHoldings@",
                     SecondaryEmail = "",
                     AddressType = ContactPreference.Email,
                 },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0004", // 🔥 REQUIRED
                     PhoneNumber = "5688664646",
                     SecondaryPhone = "",
                     EmailAddress = "AcmeCorpHoldings@",
                     SecondaryEmail = "",
                     AddressType = ContactPreference.Email,
                 }
                );

            builder.OwnsOne(e => e.IdentificationResidency)
           .HasData(
                new
                   {
                    EntityProfileEntityId = "IND-2024-0001", // 🔥 REQUIRED
                    IdentificationType = IdentificationType.Passport,
                    IdentificationNumber = "65154494646",
                    IDIssuingCountry = "US",
                    CountryResidence = "US",
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0002", // 🔥 REQUIRED
                    IdentificationType = IdentificationType.Passport,
                    IdentificationNumber = "65154494646",
                    IDIssuingCountry = "US",
                    CountryResidence = "US",
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0003", // 🔥 REQUIRED
                    IdentificationType = IdentificationType.Passport,
                    IdentificationNumber = "65154494646",
                    IDIssuingCountry = "US",
                    CountryResidence = "US",
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0004", // 🔥 REQUIRED
                    IdentificationType = IdentificationType.Passport,
                    IdentificationNumber = "65154494646",
                    IDIssuingCountry = "US",
                    CountryResidence = "US",
                }
           );

            builder.OwnsOne(e => e.EmploymentFinancialProfile)
           .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0001",
                    EmploymentStatus = "Employed",
                    EmploymentType = "Salaried",
                    Occupation = "Sr manager",
                    EmployerName = "Tech Soln Ltd.",
                    EmployerIndustry = "Software"
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0002",
                    EmploymentStatus = "Employed",
                    EmploymentType = "Salaried",
                    Occupation = "Sr manager",
                    EmployerName = "Tech Soln Ltd.",
                    EmployerIndustry = "Software"
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0003",
                    EmploymentStatus = "Employed",
                    EmploymentType = "Salaried",
                    Occupation = "Sr manager",
                    EmployerName = "Tech Soln Ltd.",
                    EmployerIndustry = "Software"
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0004",
                    EmploymentStatus = "Employed",
                    EmploymentType = "Salaried",
                    Occupation = "Sr manager",
                    EmployerName = "Tech Soln Ltd.",
                    EmployerIndustry = "Software"
                }

                );

            builder.OwnsOne(e => e.PEPDeclaration)
          .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0001",
                    IscustomerfamilymemberorcloseassociateofaPEP = false,
                    IscustomerPoliticallyExposedPerson = false,
                    PEPCategory = "Category",
                    PEPName = "Name",
                },
                 new
                 {
                     EntityProfileEntityId = "IND-2024-0002",
                     IscustomerfamilymemberorcloseassociateofaPEP = false,
                     IscustomerPoliticallyExposedPerson = false,
                     PEPCategory = "Category",
                     PEPName = "Name",
                 },
                  new
                  {
                      EntityProfileEntityId = "IND-2024-0003",
                      IscustomerfamilymemberorcloseassociateofaPEP = false,
                      IscustomerPoliticallyExposedPerson = false,
                      PEPCategory = "Category",
                      PEPName = "Name",
                  },
                   new
                   {
                       EntityProfileEntityId = "IND-2024-0004",
                       IscustomerfamilymemberorcloseassociateofaPEP = false,
                       IscustomerPoliticallyExposedPerson = false,
                       PEPCategory = "Category",
                       PEPName = "Name",
                   }
                );

          builder.OwnsOne(e => e.AccountPurposeExpectedActivity)
            .HasData(
            new
            {
                EntityProfileEntityId = "IND-2024-0001", // 🔥 REQUIRED
                PrimaryPurposeofAccount = "Savings",
                IntendedProducts = "Deposit Account",
                ExpectedMonthlyDepositRange = "50k–100k",
                ExpectedMonthlyWithdrawalRange = "20k–50k",
                ExpectedMonthlyTransactionCount = "10–20",
                ExpectedAverageTransactionValue = "5k",
                PrimaryIncomingPaymentType = "Salary",
                PrimaryOutgoingPaymentType = "Utilities",
                ExpectedCountriesforIncomingTransfers = "India",
                ExpectedCountriesforOutgoingTransfers = "India",
                ExpectedUseofCash = "Low",
                ExpectedUseofCrypto_VirtualAssets = "No",
                Notes_Rationale = "Retail customer profile"
            },
            new
            {
                EntityProfileEntityId = "IND-2024-0002", // 🔥 REQUIRED
                PrimaryPurposeofAccount = "Savings",
                IntendedProducts = "Deposit Account",
                ExpectedMonthlyDepositRange = "50k–100k",
                ExpectedMonthlyWithdrawalRange = "20k–50k",
                ExpectedMonthlyTransactionCount = "10–20",
                ExpectedAverageTransactionValue = "5k",
                PrimaryIncomingPaymentType = "Salary",
                PrimaryOutgoingPaymentType = "Utilities",
                ExpectedCountriesforIncomingTransfers = "India",
                ExpectedCountriesforOutgoingTransfers = "India",
                ExpectedUseofCash = "Low",
                ExpectedUseofCrypto_VirtualAssets = "No",
                Notes_Rationale = "Retail customer profile"
            },
            new
            {
                EntityProfileEntityId = "IND-2024-0003", // 🔥 REQUIRED
                PrimaryPurposeofAccount = "Savings",
                IntendedProducts = "Deposit Account",
                ExpectedMonthlyDepositRange = "50k–100k",
                ExpectedMonthlyWithdrawalRange = "20k–50k",
                ExpectedMonthlyTransactionCount = "10–20",
                ExpectedAverageTransactionValue = "5k",
                PrimaryIncomingPaymentType = "Salary",
                PrimaryOutgoingPaymentType = "Utilities",
                ExpectedCountriesforIncomingTransfers = "India",
                ExpectedCountriesforOutgoingTransfers = "India",
                ExpectedUseofCash = "Low",
                ExpectedUseofCrypto_VirtualAssets = "No",
                Notes_Rationale = "Retail customer profile"
            },
            new
            {
                EntityProfileEntityId = "IND-2024-0004", // 🔥 REQUIRED
                PrimaryPurposeofAccount = "Savings",
                IntendedProducts = "Deposit Account",
                ExpectedMonthlyDepositRange = "50k–100k",
                ExpectedMonthlyWithdrawalRange = "20k–50k",
                ExpectedMonthlyTransactionCount = "10–20",
                ExpectedAverageTransactionValue = "5k",
                PrimaryIncomingPaymentType = "Salary",
                PrimaryOutgoingPaymentType = "Utilities",
                ExpectedCountriesforIncomingTransfers = "India",
                ExpectedCountriesforOutgoingTransfers = "India",
                ExpectedUseofCash = "Low",
                ExpectedUseofCrypto_VirtualAssets = "No",
                Notes_Rationale = "Retail customer profile"
            }
            );

            builder.OwnsOne(e => e.TaxSelfCertification)
         .HasData(
                new
                {
                    EntityProfileEntityId = "IND-2024-0001",
                    Customerconfirmsprovidedtaxinformationisaccurate = false,
                    TaxIdentificationNumber = "123-45-6789",
                    TINCountryofIssue = "US",
                    Customerdeclaresaccountisnotforathirdpartybeneficiary = false,
                    Customerdeclarestheyareactingontheirownbehalf = false
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0002",
                    Customerconfirmsprovidedtaxinformationisaccurate = false,
                    TaxIdentificationNumber = "123-45-6789",
                    TINCountryofIssue = "US",
                    Customerdeclaresaccountisnotforathirdpartybeneficiary = false,
                    Customerdeclarestheyareactingontheirownbehalf = false
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0003",
                    Customerconfirmsprovidedtaxinformationisaccurate = false,
                    TaxIdentificationNumber = "123-45-6789",
                    TINCountryofIssue = "US",
                    Customerdeclaresaccountisnotforathirdpartybeneficiary = false,
                    Customerdeclarestheyareactingontheirownbehalf = false
                },
                new
                {
                    EntityProfileEntityId = "IND-2024-0004",
                    Customerconfirmsprovidedtaxinformationisaccurate = false,
                    TaxIdentificationNumber = "123-45-6789",
                    TINCountryofIssue = "US",
                    Customerdeclaresaccountisnotforathirdpartybeneficiary = false,
                    Customerdeclarestheyareactingontheirownbehalf = false
                }
                );
            */

            builder.HasData(new List<EntityProfile>()
            {
                 new EntityProfile
                    {
                        EntityId = "IND-2024-0001",
                        EntityName = "Jonathan Michael Smith",
                        EntityType = EntityType.Individual,
                        Cases = null,
                        //StartDate = DateTime.Now,
                        //DueDate = DateTime.Now,
                        //UpdatedAt = DateTime.Now,
                        //CreatedAt = DateTime.Now
                    },
                 new EntityProfile
                    {
                        EntityId = "IND-2024-0002",
                        EntityName = "Acme Financial Services",
                        EntityType = EntityType.Company,
                        //Cases = null,
                        //AccountPurpose = "Personal savings",
                        //AnnualIncome = "150$",
                       
                        //StartDate = DateTime.Now,
                        //DueDate = DateTime.Now,
                        //UpdatedAt = DateTime.Now,
                        //CreatedAt = DateTime.Now
                    },
                 new EntityProfile
                    {
                        EntityId = "IND-2024-0003",
                        EntityName = "Acme Corp Holdings Ltd",
                        EntityType = EntityType.Company,
                        //Cases = null,
                        //AccountPurpose = "Personal savings",
                        //AnnualIncome = "150$",
                        
                        //StartDate = DateTime.Now,
                        //DueDate = DateTime.Now,
                        //UpdatedAt = DateTime.Now,
                        //CreatedAt = DateTime.Now
                    },
                 new EntityProfile
                    {
                        EntityId = "IND-2024-0004",
                        EntityName = "Acme Corp Holdings Ltd",
                        EntityType = EntityType.Company,
                        Cases = null,
                        //AccountPurpose = "Personal savings",
                        //AnnualIncome = "150$",                      
                        ////StartDate = DateTime.Now,
                        //DueDate = DateTime.Now,
                        //UpdatedAt = DateTime.Now,
                        //CreatedAt = DateTime.Now
                    }
            });
        }
    }
}
