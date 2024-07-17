namespace Admin.Domain.Entity.System;
public class AppOperation:BaseEntity
{
  // 操作名称，比如有读取（查找、过滤）、新增、修改、导入、导出、放大、最大化但等等
  public string OperationName { get; set; } = null!;
  // 操作描述
  public string? Descript { get; set;} = null!;

}