namespace DMART.Models
{
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel, IsoftDelete
    {
        public int Id { get; set; }
        public string? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedById { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
    }
}