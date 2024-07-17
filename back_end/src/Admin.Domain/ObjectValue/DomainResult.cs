namespace Admin.Domain.ObjectValue;
public class DomainResult<T>
{
  public bool IsSuccess { get; protected set; } // 设置保护set，以防外界改变它
  public T Data { get; protected set; }
  public string ErrorMessage { get; protected set; }
  public DomainResult(bool isSuccess, T data, string errorMessage)
  {
    IsSuccess = isSuccess;
    Data = data;
    ErrorMessage = errorMessage;
  }
  public static DomainResult<T> Success(T data)
  {
    return new DomainResult<T>(true, data,"成功啦~");
  }
  public static DomainResult<T> Error(string errorMessage)
  {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        return new DomainResult<T>(false, default,errorMessage);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
    }
  
}