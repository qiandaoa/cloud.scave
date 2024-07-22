namespace Admin2024.EntityFramework.Helps;
public class BaseParameters
{
  private int _pageIndex; // 页面索引值
  private int _pageSize; // 页面大小值
  public string? keywords{get;set;} // 搜索关键字
  public string? FileByFlag {get;set;} // 过滤词
  private static int RegulIndex(int index)
  {
    int minIndex = 1; // 页面索引最小值
    return index <= 0 ? minIndex : index;
  }
  private static int RegulSize(int size)
  {
    int minSize = 10;
    int maxSize = 50;// 页大小最大值
    return size <= 0 ? minSize : (size > maxSize ? maxSize : size);
  }
  public int PageIndex
  {
    get
    {
      return RegulIndex(_pageIndex);
    }
    set
    {
      _pageIndex = RegulIndex(value);
    }
  }
  public int PageSize
  {
    get
    {
      return RegulSize(_pageSize);
    }
    set
    {
      _pageSize = RegulSize(value);
    }
  }

}