using System;
using System.Collections.Generic;
using System.Web.Services;

public partial class list : System.Web.UI.Page
{
    public static List<Model> _list;
    public int pageCount;
    const int pageSize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        pageCount = (BLL.GetPageCount("Teml") + pageSize - 1) / pageSize;

        _list = BLL.GetXML(pageSize, 1);
    }

    [WebMethod]
    public static List<Model> GetPage(int pageIndex)
    {
        return BLL.GetXML(pageSize, pageIndex);
    }

    [WebMethod]
    public static int Delete(string table, int Id)
    {
        return BLL.Delete(table, Id);
    }
}