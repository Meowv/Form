<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Index" %>
<!DOCTYPE html>
<html>
<head>
    <title>发布活动</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="css/hdx.min.css">
    <link rel="stylesheet" href="css/event-create.min.css">
</head>
<body runat="server">
    <div class="event-create">
        <%--<div class="event-create-body">--%>
            <%--<div class="event-create-body event-create-add-item">
                <div class="event-create-label event-create-label-long">
                    设置报名表单
                </div>
                <div class="text-muted"><span class="icon-add-primary"></span>如果您需要收集报名者的必要信息，可<strong class="text-info">添加</strong>此项设置</div>
            </div>--%>
            <div class="event-create-body">
                <div class="event-create-label event-create-label-long">
                    设置报名表单
                </div>
                <div id="edit_template_items" class="event-create-sign-form" style="min-height: 518px;">
                    <form id="event_template_form" style="margin-bottom: 5px;">
                        <fieldset>
                            <h3>表单名称<strong>（必填）</strong></h3>
                            <div class="event-create-sign-required">
                                <div class="form-group">
                                    <strong>表单名称</strong>
                                    <input style="width: 50%;" type="text" class="form-control" placeholder="请输入表单名称" id="form_title">
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <h3>联系方式</h3>
                            <div id="event_template_form_contact" class="event-create-sign-required">
                                <div class="form-group">
                                    <label>
                                        <input type="checkbox" checked="checked" disabled="disabled">必填</label><span>姓名</span><input type="text" class="form-control" placeholder="请输入姓名" value="请输入姓名" name="gas-name" id="gas-name" disabled="disabled">
                                </div>
                                <div class="form-group">
                                    <label>
                                        <input type="checkbox" checked="checked" disabled="disabled">必填</label><span>手机号码</span><input type="text" class="form-control" placeholder="请输入手机号码" value="请输入手机号码" name="gas-phone" id="gas-phone" disabled="disabled">
                                </div>
                                <div class="form-group">
                                    <label>
                                        <input type="checkbox" checked="checked" disabled="disabled">必填</label><span>电子邮箱</span><input type="text" class="form-control" placeholder="请输入电子邮箱" value="请输入电子邮箱" name="gas-email" id="gas-email" disabled="disabled">
                                </div>
                            </div>
                            <h3>其他</h3>
                            <div id="event_template_form_items"></div>
                            <div style="clear: both;"></div>
                            <div class="form-actions" style="padding-left: 20px; margin-top: 20px;">
                                <button id="btnSave" class="btn btn-primary" onclick="return false;" style="margin-right: 15px;">
                                    <i class="icon-hdd icon-white"></i>保&nbsp;存</button>


                                <button class="btn" onclick="javascript:reviewEventFormView();;return false;"><i class="icon-play"></i>预&nbsp;览</button>
                            </div>
                        </fieldset>
                    </form>
                </div>
                <div class="aside" id="edit_template_tools" style="max-width: 205px;">
                    <h3>常用栏位</h3>
                    <div class="event-create-sign-form-usual clearfix">
                        <ul>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(0);;return false;"><span class="icon-btn-company"></span><span>公司</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(1);;return false;"><span class="icon-btn-department"></span><span>部门</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(2);;return false;"><span class="icon-btn-office"></span><span>职位</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(3);;return false;"><span class="icon-btn-insterest"></span><span>兴趣爱好</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(4);;return false;"><span class="icon-btn-blood"></span><span>血型</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(5);;return false;"><span class="icon-btn-marry"></span><span>婚姻状况</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(6);;return false;"><span class="icon-btn-sex"></span><span>性别</span></button></li>
                        </ul>
                        <ul>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(7);;return false;"><span class="icon-btn-age"></span><span>年龄</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(8);;return false;"><span class="icon-btn-educational"></span><span>学历</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(9);;return false;"><span class="icon-btn-address"></span><span>住址</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(10);;return false;"><span class="icon-btn-income"></span><span>月收入</span></button></li>
                            <li>
                                <button type="button" class="btn" onclick="javascript:addEventFormCommonItem(11);;return false;"><span class="icon-btn-other"></span><span>其他</span></button></li>
                        </ul>
                    </div>
                    <div class="event-create-sign-form-custom">
                        <h3>自定义栏位</h3>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(0);;return false;"><span class="icon-btn-single-line "></span><span>单行文本框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(1);;return false;"><span class="icon-btn-number-input "></span><span>数字输入框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(2);;return false;"><span class="icon-btn-calendar "></span><span>日期选择框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(3);;return false;"><span class="icon-btn-mouse "></span><span>邮箱输入框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(4);;return false;"><span class="icon-btn-multi-line "></span><span>多行文本框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(5);;return false;"><span class="icon-btn-option "></span><span>单选按钮框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(6);;return false;"><span class="icon-btn-check "></span><span>多选按钮框</span><span class="icon-btn-add"></span></button>
                        <button type="button" class="btn" onclick="javascript:addEventFormEmptyItem(7);;return false;"><span class="icon-btn-select "></span><span>下拉选择框</span><span class="icon-btn-add"></span></button>
                    </div>
                </div>
                <div class="clear text-center">
                   <%-- <button class="btn" id="event-create-item-toggle"><span class="icon-top-arrow"></span>收起表单</button>--%>
                </div>
            </div>
            <div id="dlg-review-event-form" class="modal">
                <div class="modal-dialog" style="width: 800px">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button class="close" data-dismiss="modal">×</button>
                            <h3 class="modal-title">预览活动表单</h3>
                        </div>
                        <div class="modal-body" style="max-height: 430px; min-height: 420px; margin-bottom: 5px; overflow-x: hidden">
                            <form id="save-form">
                                <div class="page-header" style="margin: 0px 10px;">
                                    <span class="label label-warning header_label">联系方式</span>
                                    <div class="page-header-line"></div>
                                </div>
                                <div style="padding-left: 30px;">
                                    <div class="control-group" style="margin: 5px 0px;">
                                        <label class="control-label" style="font-weight: bold;">姓名</label>
                                        <div class="controls" style="color: gray;">
                                            <input type="text" class="required disabled input-xlarge" value="请输入姓名" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="control-group" style="margin: 5px 0px;">
                                        <label class="control-label" style="font-weight: bold;">手机号码</label>
                                        <div class="controls" style="color: gray;">
                                            <input type="text" class="required disabled input-xlarge" value="请输入手机号码" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="control-group" style="margin: 5px 0px;">
                                        <label class="control-label" style="font-weight: bold;">电子邮箱</label>
                                        <div class="controls" style="color: gray;">
                                            <input type="text" class="required disabled input-xlarge" value="请输入电子邮箱" disabled="disabled" />
                                        </div>
                                    </div>
                                </div>
                                <div class="page-header" style="margin: 0px 10px;">
                                    <span class="label label-warning header_label">其他</span>
                                    <div class="page-header-line"></div>
                                </div>
                                <fieldset id="event_template_form_fields" style="padding-left: 30px;"></fieldset>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <a href="#" class="btn btn-create-default" data-dismiss="modal"><i class="icon-off"></i>关闭</a>
                        </div>
                    </div>
                </div>
            </div>
        <%--</div>--%>
    </div>
    <div class="modal fade" id="pop_message_dlg" style="margin-top: 250px; overflow-y: auto; z-index: 10000">
        <div class="modal-dialog" style="width: 550px;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="pop_msg_head"><span class="icon-danger" id="pop_message_icon"></span><span id="pop_message_content"></span></h4>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery.js"></script>
<script src="js/jquery.json-2.3.min.js"></script>
<script src="js/accupass.form.js"></script>
<script src="js/libs.min.js"></script>
<script src="js/create-event.min.js"></script>
<script src="js/form.js"></script>
</html>