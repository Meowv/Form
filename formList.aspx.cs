using System;
using System.Collections.Generic;
using System.Web.Services;

public partial class formList : System.Web.UI.Page
{
    public static List<Form> forms = new List<global::Form>();

    public static int pageCount, FormId;
    const int pageSize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        FormId = Convert.ToInt32(Request.QueryString["FormId"]);

        forms = BLL.GetFormListByFormId(FormId, pageSize, 1);

        pageCount = (BLL.GetPageCount("Form", FormId) + pageSize - 1) / pageSize;
    }

    [WebMethod]
    public static List<Form> GetPage(int pageIndex)
    {
        return BLL.GetFormListByFormId(FormId, pageSize, pageIndex);
    }
}