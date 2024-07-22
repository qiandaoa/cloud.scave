namespace Admin2024.Instructions;

public class ReturnResult<T>
{
    public bool IsSuccess { get; protected set; }
    public T Data { get; protected set; }
    public string Message { get; protected set; }
    public ReturnResult(bool success,T data,string message)
    {
        IsSuccess = success;
        Data = data;
        Message = message;
    }
    public static ReturnResult<T> Success(string msg)
    {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        return new ReturnResult<T>(true, default, msg);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
    }
    public static ReturnResult<T> Success(T data,string msg)
    {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        return new ReturnResult<T>(true,data,msg);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
    }
    public static ReturnResult<T> Success(T data)
    {
        return new ReturnResult<T>(true,data,"执行成功");
    }

    public static ReturnResult<T> Error(string msg)
    {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        return new ReturnResult<T>(false,default,msg);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
    }
}