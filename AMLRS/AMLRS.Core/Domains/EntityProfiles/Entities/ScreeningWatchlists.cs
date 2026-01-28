using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ScreeningWatchlists
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public bool? Sanctions_list_matched {  get; set; }
        public string? Sanctions_match_lists {  get; set; }
        public int? Sanctions_match_score {  get; set; }
        public DateTime? Sanctions_last_screened_at {  get; set; }
        public string? Adverse_media_flag_detail {  get; set; }
    }
}
