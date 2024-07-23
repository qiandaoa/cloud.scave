namespace Admin2024.Application.Contracts.UserApplication.Dto;

public class CreateOPDto
{
    public string poweName { get; set; } = null!;
    public string? Description { get; set; }
    public Guid  CreateUse {get;set;}
}

