using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml;

public partial class _Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static int SavaForm(string formtitle, List<string> items, List<string> subItems)
    {
        string xmlDoc = "<Form>", type, sort, required, title, placeholder;

        if (items != null)
        {
            for (int i = 0; i < items.Count; i++)
            {
                type = items[i].Split('$')[0];//类型
                sort = items[i].Split('$')[1];//排序
                required = items[i].Split('$')[2];//必填？
                title = items[i].Split('$')[3];//title
                placeholder = items[i].Split('$')[4];//placeholder

                xmlDoc += "<item>";
                xmlDoc += "<type>" + type + "</type>";
                xmlDoc += "<sort>" + sort + "</sort>";
                xmlDoc += "<required>" + required + "</required>";
                xmlDoc += "<lable>" + title + "</lable>";
                xmlDoc += "<placeholder>" + placeholder + "</placeholder>";
                if (subItems[i] != null)
                {
                    xmlDoc += "<subItem>";

                    string[] subItemValue = subItems[i].Split('$');
                    for (int j = 0; j < subItemValue.Length - 1; j++)
                    {
                        xmlDoc += "<lable>" + subItemValue[j] + "</lable>";
                    }

                    xmlDoc += "</subItem>";
                }
                xmlDoc += "</item>";
            }
        }
        xmlDoc += "</Form>";
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(xmlDoc.ToString());
        return BLL.INSERT(formtitle, xml);
    }
}