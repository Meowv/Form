using System;

/// <summary>
/// Model 的摘要说明
/// </summary>
public class Model
{
    public Model()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string XML { get; set; }
    public DateTime CreateTime { get; set; }
    public int IsDelete { get; set; }
}