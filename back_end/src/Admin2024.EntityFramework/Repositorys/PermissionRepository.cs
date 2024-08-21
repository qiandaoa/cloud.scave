namespace Admin2024.EntityFramework.Repositories;
public class PermissionRepository
{
  public Guid ResourceId {get;set;}
  public Guid OperationId {get;set;}
  public string ResourceName {get;set;}
  public string OperationName {get;set;}
  public string PermissionDes {get;set;}
  public string Remark {get;set;}
}