namespace AMLRS.Core.Domains.Common.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; } = default!;
    }

}
