using System;
using System.Xml;

public partial class formListDetail : System.Web.UI.Page
{
    public string html = "";
    public static XmlNodeList nodeList;

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["Id"]);
        int formId = Convert.ToInt32(Request.QueryString["formId"]);

        Form model = new Form();
        model = BLL.GetDataXmlById(Id, formId);

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(model.Data.InnerXml);

        nodeList = xml.SelectNodes("/Form/item");
        if (nodeList.Count != 0)
        {
            int index = 1;

            foreach (XmlNode node in nodeList)
            {
                string type = node.FirstChild.InnerText;
                string required = node.ChildNodes[2].InnerText == "true" ? "<font style=\"color:red;\">&nbsp;*</font>" : "";
                string lable = node.ChildNodes[3].InnerText;
                string placeholder = node.ChildNodes[4].InnerText;

                if (type == "input")
                {
                    html += string.Format(htmlTemplate[0], lable + required, placeholder, "item" + index, node.LastChild.InnerText);
                }
                else if (type == "number")
                {
                    html += string.Format(htmlTemplate[1], lable + required, placeholder, "item" + index, node.LastChild.InnerText);
                }
                else if (type == "date")
                {
                    html += string.Format(htmlTemplate[2], lable + required, placeholder, "item" + index, node.LastChild.InnerText);
                }
                else if (type == "email")
                {
                    html += string.Format(htmlTemplate[3], lable + required, placeholder, "item" + index, node.LastChild.InnerText);
                }
                else if (type == "textarea")
                {
                    html += string.Format(htmlTemplate[4], lable + required, placeholder, "item" + index, node.LastChild.InnerText);
                }
                else if (type == "radio")
                {
                    string subItem = "<div class=\"input-mini\" style=\"float: left; margin: 0px 10px 0px 0px;\"><label class=\"radio\"><input disabled=\"disabled\" {2} type=\"radio\" value=\"{0}\" name=\"{1}\">&nbsp;{0}</label></div>", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index);
                    html += string.Format(htmlTemplate[5], lable + required, placeholder, _subHtml);
                }
                else if (type == "checkbox")
                {
                    string subItem = "<div class=\"input-mini\" style=\"float: left; margin: 0px 10px 0px 0px;\"><label class=\"checkbox\"><input disabled=\"disabled\" {2} type=\"checkbox\" value=\"{0}\" name=\"{1}\">&nbsp;{0}</label></div>", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index);
                    html += string.Format(htmlTemplate[6], lable + required, placeholder, _subHtml);
                }
                else if (type == "select")
                {
                    string subItem = "<option value=\"{0}\" {2} disabled=\"disabled\">{0}</option>", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index);
                    html += string.Format(htmlTemplate[7], lable + required, placeholder, _subHtml, "item" + index);
                }

                index++;
            }
        }
    }

    private static string GetSubItem(XmlNode node, string subItem, string _subHtml, int index)
    {
        XmlNode subItemNode = node.SelectSingleNode("subItem");
        XmlNodeList subItemNodeList = subItemNode.ChildNodes;

        if (subItemNodeList != null)
        {
            foreach (XmlNode subNode in subItemNodeList)
            {
                string check = subNode.OuterXml.Contains("checked=\"checked\"") == true ? "checked=\"checked\"" : "";
                if (subNode.OuterXml.Contains("checked=\"checked\"") == true)
                {
                    check = "checked=\"checked\"";
                    if (subItem.Contains("<option"))
                    {
                        check = "selected=\"selected\"";
                    }
                }
                else
                {
                    check = "";
                }

                _subHtml += string.Format(subItem, subNode.InnerText, "item" + index, check);
            }
        }

        return _subHtml;
    }

    public string[] htmlTemplate =
    {
        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><input disabled=\"disabled\" type = \"text\" class=\"input-xlarge\" placeholder=\"{1}\" title=\"{1}\" name=\"{2}\" id=\"{2}\" value=\"{3}\"></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><input disabled=\"disabled\" type = \"text\" class=\"input-xlarge\" placeholder=\"{1}\" title=\"{1}\" name=\"{2}\" id=\"{2}\" value=\"{3}\"></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><input disabled=\"disabled\" type = \"text\" class=\"input-xlarge\" placeholder=\"{1}\" title=\"{1}\" name=\"{2}\" id=\"{2}\" value=\"{3}\"></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><input disabled=\"disabled\" type = \"text\" class=\"input-xlarge\" placeholder=\"{1}\" title=\"{1}\" name=\"{2}\" id=\"{2}\" value=\"{3}\"></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><textarea disabled=\"disabled\" rows = \"5\" class=\"input-xxlarge\" placeholder=\"{1}\" title=\"{1}\" name=\"{2}\" id=\"{2}\" style=\"margin: 0px; width: 663px; height: 75px;\">{3}</textarea></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><div style=\"margin-top: 5px;\"><div class=\"ctl_prompt\">{1}</div>{2}<div style=\"clear: both\"></div></div></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><div style=\"margin-top: 5px;\"><div class=\"ctl_prompt\">{1}</div>{2}<div style=\"clear: both\"></div></div></div></div>",

        "<div class=\"control-group\" style=\"margin-bottom: 8px;\"><label class=\"control-label\" style=\"font-weight: bold;\">{0}</label><div class=\"controls\"><select class=\"input-xxlarge \" title=\"{1}\" id=\"{3}\">{2}</select><span class=\"ctl_prompt\">&nbsp;&nbsp;{1}</span></div></div>"
    };
}