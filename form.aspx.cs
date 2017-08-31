using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml;

public partial class form : System.Web.UI.Page
{

    public string html = "";
    public static int id;
    public static Model model = new Model();
    public static XmlNodeList nodeList;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["Id"]);
        model = BLL.GetXmlById(id);

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(model.XML);
        nodeList = xml.SelectNodes("/Form/item");

        if (nodeList.Count != 0)
        {
            int index = 1;

            foreach (XmlNode node in nodeList)
            {
                string type = node.FirstChild.InnerText;
                //string sort = node.ChildNodes[1].InnerText;
                string required = node.ChildNodes[2].InnerText;
                string lable = node.ChildNodes[3].InnerText;
                string placeholder = node.ChildNodes[4].InnerText;

                if (type == "input")
                {
                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[0], lable, placeholder, "item" + index, "data-rule=required()");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[0], lable, placeholder, "item" + index, "");
                    }
                }
                else if (type == "number")
                {
                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[1], lable, placeholder, "item" + index, "data-rule=required()|number");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[1], lable, placeholder, "item" + index, "data-rule=number");
                    }
                }
                else if (type == "date")
                {

                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[2], lable, placeholder, "item" + index, "data-rule=required()");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[1], lable, placeholder, "item" + index, "");
                    }
                }
                else if (type == "email")
                {
                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[3], lable, placeholder, "item" + index, "data-rule=required()|email");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[1], lable, placeholder, "item" + index, "data-rule=email");
                    }
                }
                else if (type == "textarea")
                {
                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[4], lable, placeholder, "item" + index, "data-rule=required()");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[1], lable, placeholder, "item" + index, "");
                    }
                }
                else if (type == "radio")
                {
                    string subItem = "<label style=\"padding-top: 5px;\"><input {2} type=\"radio\" name=\"{1}\" value=\"{0}\">&nbsp;{0}</label>&nbsp;&nbsp;&nbsp;", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index, required);
                    html += string.Format(htmlTemplate[5], lable, placeholder, _subHtml);
                }
                else if (type == "checkbox")
                {
                    string subItem = "<label style=\"padding-top: 5px;\"><input {2} type=\"checkbox\" name=\"{1}\" value=\"{0}\">&nbsp;{0}</label>&nbsp;&nbsp;&nbsp;", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index, required);
                    html += string.Format(htmlTemplate[6], lable, placeholder, _subHtml);
                }
                else if (type == "select")
                {
                    string subItem = "<option value=\"{0}\">{0}</option>", _subHtml = "";
                    _subHtml = GetSubItem(node, subItem, _subHtml, index, null);
                    if (required == "true")
                    {
                        html += string.Format(htmlTemplate[7], lable, placeholder, _subHtml, "item" + index, "data-rule=required()");
                    }
                    else
                    {
                        html += string.Format(htmlTemplate[7], lable, placeholder, _subHtml, "item" + index, "");
                    }
                }

                index++;
            }
        }
    }

    private static string GetSubItem(XmlNode node, string subItem, string _subHtml, int index, string required)
    {
        XmlNode subItemNode = node.SelectSingleNode("subItem");
        XmlNodeList subItemNodeList = subItemNode.ChildNodes;

        if (subItemNodeList != null)
        {
            foreach (XmlNode subNode in subItemNodeList)
            {
                if (required == "true")
                {
                    _subHtml += string.Format(subItem, subNode.InnerText, "item" + index, "data-rule=\"required()\"");
                }
                else
                {
                    _subHtml += string.Format(subItem, subNode.InnerText, "item" + index, "");
                }
            }
        }

        return _subHtml;
    }

    [WebMethod]
    public static int InsertFormData(string name, string phone, string email, List<string> values)
    {
        Form form = new global::Form();
        form.FormId = id;
        form.Name = name;
        form.Phone = phone;
        form.Email = email;
        form.CommitTime = DateTime.Now;
        form.IsDelete = 0;

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(model.XML);

        if (values != null)
        {
            nodeList = xml.SelectNodes("/Form/item");
            if (nodeList.Count != 0)
            {
                int i = 0;

                foreach (XmlNode node in nodeList)
                {
                    XmlElement value = xml.CreateElement("value");
                    string itemValue = values[i];
                    string type = node.FirstChild.InnerText;

                    if (values[i].Contains("/") || type == "select")
                    {
                        string[] items = values[i].Split('/');
                        int itemsLength = items.Length == 1 ? items.Length : (items.Length - 1);
                        for (int j = 0; j < itemsLength; j++)
                        {
                            itemValue = items[j];
                            XmlNode subItemNode = node.SelectSingleNode("subItem");
                            XmlNodeList subItemNodeList = subItemNode.ChildNodes;
                            if (subItemNodeList != null)
                            {
                                foreach (XmlNode subNode in subItemNodeList)
                                {
                                    XmlElement xe = (XmlElement)subNode;
                                    if (subNode.InnerText == itemValue)
                                    {
                                        xe.SetAttribute("checked", "checked");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        value.InnerText = itemValue;
                        node.AppendChild(value);
                    }

                    i++;
                }
            }
        }

        form.Data = xml;
        return BLL.InsertForm(form);
    }

    public string[] htmlTemplate =
    {
        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><input {3} type=\"text\" class=\"form-control\" placeholder=\"{1}\" name=\"{2}\" id=\"{2}\"></div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><input {3} type=\"text\" class=\"form-control\" placeholder=\"{1}\" name=\"{2}\" id=\"{2}\"></div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><input {3} type=\"text\" class=\"form-control\" placeholder=\"{1}\" name=\"{2}\" id=\"datetimepicker\"></div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><input {3} type=\"text\" class=\"form-control\" placeholder=\"{1}\" name=\"{2}\" id=\"{2}\"></div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><textarea {3} class=\"form-control\" placeholder=\"{1}\" name=\"{2}\" id=\"{2}\"></textarea></div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\">{2}</div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\">{2}</div></div>",

        "<div class=\"form-group\"><label class=\"col-sm-3 control-label\">{0}</label><div class=\"col-sm-6\"><select {4} class=\"form-control\" id=\"{3}\"><option value=\"\">请选择</option>{2}</select></div></div>"
    };
}