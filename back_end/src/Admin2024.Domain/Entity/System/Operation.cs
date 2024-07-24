namespace Admin2024.Domain.System;

public class Operation : BaseEntity
{
    public string OperationName { get; set; } = null!;

    public string? Description { get; set; }
}