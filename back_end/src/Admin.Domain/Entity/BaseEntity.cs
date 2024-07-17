namespace Admin.Domain.Entity;
public abstract class BaseEntity
{
  public Guid Id { get; set; } // 主键
  public string? BaseCode { get; set; } // 编号
  public bool IsActived { get; set; } // 是否启用/激活
  public bool IsDeleted { get; set; } // 是否删除（软删除）
  public DateTime CreatedAt { get; set; } // 创建时间
  public Guid CreatedBy { get; set; } // 创建人Id
  public DateTime UpdatedAt { get; set; } // 最后更新时间
  public Guid UpdatedBy { get; set; } // 更新人Id
  public int DisplayOrder { get; set; } // 显示顺序，数字越大越靠前
  public string? Remarks { get; set; } // 备注
}
