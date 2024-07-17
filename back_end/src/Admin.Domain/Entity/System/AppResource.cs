namespace Admin.Domain.Entity.System;
public class AppResource:BaseEntity
{
  // 资源列表名称
  public string ResourceName { get; set; } = null!;
  // 资源url
  public string Url { get; set; } = null!;

}