<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formList.aspx.cs" Inherits="formList" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>报名详情</title>
    <link href="css/page.css" rel="stylesheet" />
</head>
<body>
    <table border="1" cellpadding="5" style="border-collapse: collapse;text-align:center;margin:auto;">
        <tr>
            <td>表单名称</td>
            <td>提交时间</td>
            <td>姓名</td>
            <td>手机号码</td>
            <td>电子邮箱</td>
            <td>查看更多</td>
            <td>操作</td>
        </tr>
        <%if (forms != null)
            { %>
        <%foreach (var form in forms)
            {%>
        <tr>
            <td><%=form.Title%></td>
            <td><%=form.CommitTime.ToString("yyyy-MM-dd HH:mm:ss")%></td>
            <td><%=form.Name%></td>
            <td><%=form.Phone%></td>
            <td><%=form.Email%></td>
            <td><a href="javascript:;" onclick="GetMore('<%=form.Title%>',<%=form.Id%>,<%=form.FormId%>)">查看更多</a></td>
            <td><a href="javascript:;" onclick="Delete(<%=form.Id%>)">删除</a></td>
        </tr>
        <%}%>
        <%}%>
    </table>
    <%if (pageCount > 1){%><div class="page"></div><%}%>
</body>
</html>
<script src="js/jquery.js"></script>
<script src="js/jquery.json-2.3.min.js"></script>
<script src="js/jquery.page.js"></script>
<script src="js/convertTime.js"></script>
<script src="js/layer/layer.js"></script>
<script>
    function GetMore(title,Id,FormId) {
        layer.open({
            type: 2,
            title: title,
            shadeClose: true,
            shade: false,
            maxmin: true,
            area: ['800px', '600px'],
            content: '/formListDetail.aspx?Id=' + Id + '&FormId=' + FormId + ''
        });
    }

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
                url: "formList.aspx/GetPage",
                contentType: "application/json; charset=utf-8",
                data: $.toJSON(data),
                dataType: "json",
                success: function (result) {
                    var html = "";
                    for (var i = 0; i < result.d.length; i++) {
                        html += "<tr><td>" + result.d[i]["Title"] + "</td><td>"+convertTime(result.d[i]["CommitTime"], "yyyy-MM-dd HH:mm:ss")+"</td><td>"+result.d[i]["Name"]+"</td><td>"+result.d[i]["Phone"]+"</td><td>"+result.d[i]["Email"]+"</td><td><a href=\"javascript:;\" onclick=\"GetMore('"+result.d[i]["Title"]+"','"+result.d[i]["Id"]+"','"+result.d[i]["FormId"]+"')\">查看更多</a></td><td><a href=\"javascript:;\" onclick=\"Delete("+result.d[i]["Id"]+")\">删除</a></td></tr>";
                    }
                    $("table").html("<tr><td>表单名称</td><td>提交时间</td><td>姓名</td><td>手机号码</td><td>电子邮箱</td><td>查看更多</td><td>操作</td></tr>" + html);
                },
                error: function (err) {
                    var obj = $.parseJSON(err.responseText);
                    console.log(obj.Message);
                }
            });
        }

        function Delete(Id) {
            if (confirm('确定要删除吗？')) {
                var data = new Object();
                data["Id"] = Id;
                data["table"] = "Form";
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
