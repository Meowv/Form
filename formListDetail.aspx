<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formListDetail.aspx.cs" Inherits="formListDetail" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="css/hdx.min.css">
    <link rel="stylesheet" href="css/event-create.min.css">
    <title>报名详情</title>
</head>
<body>
    <div class="modal-body">
        <%if (nodeList.Count != 0)
            {%>
        <fieldset style="padding-left: 30px;">
            <%=html%>
        </fieldset>
        <%}%>
    </div>
</body>
</html>