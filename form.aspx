<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form.aspx.cs" Inherits="form" %>


<!DOCTYPE html>

<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link href="css/bootstrap-3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <title>报名</title>
</head>
<body style="background-color:#F1F1F1">
    <h1 class="text-center"><%=model.Title%></h1>
    <div class="container" style="margin: 50px">
        <div class="row">
            <form class="form-horizontal" method="POST">
                <div class="form-group">
                    <label class="col-sm-3 control-label">姓名</label>
                    <div class="col-sm-6">
                        <input type="text" id="gas_name" name="gas_name" class="form-control" placeholder="请输入姓名">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">手机号码</label>
                    <div class="col-sm-6">
                        <input type="text" id="gas_phone" name="gas_phone" class="form-control" placeholder="请输入手机号码">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">电子邮箱</label>
                    <div class="col-sm-6">
                        <input type="text" id="gas_email" name="gas_email" class="form-control" placeholder="请输入电子邮箱">
                    </div>
                </div>

                <%=html%>

                <div class="form-group">
                    <div class="col-sm-9 col-sm-offset-3">
                        <button type="submit" class="btn btn-primary">提 交</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
<script src="js/jquery.js"></script>
<script src="css/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
<script src="css/datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script src="js/jquery.json-2.3.min.js"></script>
<script src="js/SMValidator.min.js"></script>
<script>
    $('#datetimepicker').datetimepicker({
        minView: "month",
        format: 'yyyy-mm-dd',
        language: 'zh-CN',
        autoclose: true,
        todayHighlight: true
    });

    SMValidator.setSkin('bootstrap');
    SMValidator.setLang({
        number: '请输入数字',
        email: '请输入正确的邮箱格式'
    });
    new SMValidator('form', {
        required: '请输入内容',
        rules: {
            phone: [/^1[34578]\d{9}$/, '请输入正确的手机号码']
        },
        fields: {
            gas_name: 'required',
            gas_phone: 'required|phone',
            gas_email: 'required|email'
        },
        submit: function (valid, form) {
            if (valid) {
                var itemCount = <%=nodeList.Count%>;
                var data = new Object();
                var values = new Array();
                data["name"] = $("#gas_name").val()
                data["phone"] = $("#gas_phone").val();
                data["email"] = $("#gas_email").val();
                if (itemCount != 0) {
                    for (var i = 1; i <= itemCount; i++) {
                        var value = $("#item" + i).val();
                        if (value == null) {
                            value = "";
                            $("input[name='item" + i + "']:checked").each(function () {
                                value += $(this).val() + "/";
                            });
                        }
                        values[i - 1] = value;
                    }
                    data["values"] = values;
                } else {
                    data["values"] = null;
                }
                $.ajax({
                    type: 'post',
                    url: "form.aspx/InsertFormData",
                    contentType: "application/json; charset=utf-8",
                    data: $.toJSON(data),
                    dataType: "json",
                    success: function (result) {
                        alert("提交成功");
                    },
                    error: function (err) {
                        var obj = $.parseJSON(err.responseText);
                        alert(obj.Message);
                    }
                });
            }
        }
    });
</script>
