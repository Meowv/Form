using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// BLL 的摘要说明
/// </summary>
public class BLL
{
    public BLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static int INSERT(string Title,XmlDocument xml)
    {
        return DAL.INSERT(Title, xml);
    }

    public static List<Model> GetXML(int pageSize, int pageIndex)
    {
        return DAL.GetXML(pageSize, pageIndex);
    }

    public static int GetPageCount(string table)
    {
        return DAL.GetPageCount(table);
    }

    public static int GetPageCount(string table, int FormId)
    {
        return DAL.GetPageCount(table, FormId);
    }

    public static Model GetXmlById(int Id)
    {
        return DAL.GetXmlById(Id);
    }

    public static Form GetDataXmlById(int Id, int FormId)
    {
        return DAL.GetDataXmlById(Id, FormId);
    }

    public static int InsertForm(Form form)
    {
        return DAL.InsertForm(form);
    }

    public static List<Form> GetFormListByFormId(int FormId, int pageSize, int pageIndex)
    {
        return DAL.GetFormListByFormId(FormId, pageSize, pageIndex);
    }

    public static int Delete(string table, int Id)
    {
        return DAL.Delete(table, Id);
    }
}