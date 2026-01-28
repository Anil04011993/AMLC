namespace AMLRS.Core.Domains.EntityProfiles.Enums
{
    public enum EntityType
    {
        Individual = 1,
        Company = 2
    }
    public enum Tier
    {
        Tier_1 = 1,
        Tier_2 = 2,
        Tier_3 = 3
    }

    public enum Stage
    {
        Screening,
        Due_Diligence,
        Ongoing_Monitoring,
        Investigation
    }
    
    public enum OverallRisk
    {
        Low,
        Medium,
        High
    }

}
