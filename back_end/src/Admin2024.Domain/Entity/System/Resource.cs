namespace Admin2024.Domain.System;

public class Resource : BaseEntity
{
    public string ResourceName { get; set; } = null!;
    public string? Description { get; set; }
}