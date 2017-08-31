using System;
using System.Xml;

/// <summary>
/// Form 的摘要说明
/// </summary>
public class Form
{
    public Form()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int Id { get; set; }
    public int FormId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public XmlDocument Data { get; set; }
    public DateTime CommitTime { get; set; }
    public int IsDelete { get; set; }
}