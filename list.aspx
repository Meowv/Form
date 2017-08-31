<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>活动列表</title>
    <link href="css/page.css" rel="stylesheet" />
</head>
<body>
    <%if (_list != null)
        {%>
    <table border="1" cellpadding="5" style="border-collapse: collapse;text-align:center;margin:auto;">
        <tr>
            <td>表单名称</td>
            <td>报名链接</td>
            <td>创建时间</td>
            <td>报名详情</td>
            <td>操作</td>
        </tr>
        <%foreach (var i in _list)
            {%>
        <tr>
            <td><%=i.Title%></td>
            <td><a target="_blank" href="form.aspx?Id=<%=i.Id%>">报名链接</a></td>
            <td><%=i.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")%></td>
            <td><a target="_blank" href="formlist.aspx?formId=<%=i.Id%>">报名详情</a></td>
            <td><a href="javascript:;" onclick="Delete(<%=i.Id%>)">删除</a></td>
        </tr>
        <%}%>
    </table>
    <%}%>
    <%if (pageCount > 1){%><div class="page"></div><%}%>
</body>
</html>
<script src="js/jquery.js"></script>
<script src="js/jquery.json-2.3.min.js"></script>
<script src="js/jquery.page.js"></script>
<script src="js/convertTime.js"></script>
<script>
    var index = 1;

    $(".page").createPage({
        pageCount:<%=pageCount%>,
        current:1,
        backFn: function (pageIndex) {
            index = pageIndex;
            InitAjax(pageIndex);
        }
    });

    function InitAjax(pageIndex)
    {
        var data = new Object();
        data["pageIndex"] = pageIndex;
        $.ajax({
            type: 'post',
            url: "list.aspx/GetPage",
            contentType: "application/json; charset=utf-8",
            data: $.toJSON(data),
            dataType: "json",
            success: function (result) {
                var html = "";
                for (var i = 0; i < result.d.length; i++) {
                    html += "<tr><td>" + result.d[i]["Title"] + "</td><td><a target=\"_blank\" href=\"form.aspx?Id=" + result.d[i]["Id"] + "\">报名链接</a></td><td>"+convertTime(result.d[i]["CreateTime"], "yyyy-MM-dd HH:mm:ss")+"</td><td><a target=\"_blank\" href=\"formlist.aspx?formId=" + result.d[i]["Id"] + "\">报名详情</a></td><td><a href=\"javascript:;\" onclick=\"Delete("+result.d[i]["Id"]+")\">删除</a></td></tr>";
                }
                $("table").html("<tr><td>表单名称</td><td>报名链接</td><td>创建时间</td><td>报名详情</td><td>操作</td></tr>" + html);
            },
            error: function (err) {
                var obj = $.parseJSON(err.responseText);
                console.log(obj.Message);
            }
        });
    }

    function Delete(Id)
    {
        if(confirm('确定要删除吗？')) 
        { 
            var data = new Object();
            data["Id"] = Id;
            data["table"] = "Teml";
            $.ajax({
                type: 'post',
                url: "list.aspx/Delete",
                contentType: "application/json; charset=utf-8",
                data: $.toJSON(data),
                dataType: "json",
                success: function (result) {
                    alert("删除成功！");
                    InitAjax(index);
                },
                error: function (err) {
                    var obj = $.parseJSON(err.responseText);
                    console.log(obj.Message);
                }
            });
            return true; 
        } 
        return false; 
    }
</script>
