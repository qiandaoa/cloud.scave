namespace Admin2024.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsActived { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public Guid CreateBy { get; set; }
    public Guid UpdateBy { get; set; }
    public string? Remark { get; set; }
}