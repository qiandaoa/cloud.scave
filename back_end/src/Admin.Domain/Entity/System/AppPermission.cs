namespace Admin.Domain.Entity.System;
public class AppPermission:BaseEntity
{
  // 资源Id
  public Guid AppResourceId { get; set; }
  // 操作Id
  public Guid AppOperationId { get; set; }
  public AppPermission()
  {

  }
  public AppPermission(Guid appResourceId,Guid appOperationId)
  {
    AppResourceId = appResourceId;
    AppOperationId = appOperationId;
  }
  /*
   举例说明
    AppResource：
      1 -> student_menu
      2 -> school_menu

    AppOperation
      11 -> get
      12 -> create
      13 -> update
      14 -> delete
      15 -> print打印
      16 -> import导入
      17 -> export导出

    AppPermission
      a 1 - 11 : 具备对学生菜单进行读取的权限
      b 1 - 12 : 具备对学生菜单进行创建的权限
      c 1 - 13 : 具备对学生菜单进行打印的权限

    AppRole
      21 -> 秘书
      22 -> 主管

    AppRolePermission
      21 a : 秘书具有对学生菜单进行读取的权限
      21 b : 秘书具有对学生菜单进行创建的权限
  */
}