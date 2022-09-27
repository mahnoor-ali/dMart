public interface IAuditedModel
{
    public string? CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedById { get; set; }
}