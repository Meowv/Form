$("#btnSave").click(function () {
    var data = new Object();
    var formtitle = $("#form_title").val();
    var items = new Array();
    var subItems = new Array();
    var itemLength = $("#event_template_form_items > div").length;
    var subItemValue, subItemLength;
    console.log(itemLength);
    if (itemLength != 0) {
        for (var i = 0; i < itemLength; i++) {
            var type = $("#items" + i + "_Type").val() + "$";
            var sort = $("#items" + i + "_Sort").val() + "$";
            var required = $("#items" + i + "_Required").val() + "$";
            var title = $("#items" + i + "_Title").val() + "$";
            var placeholder = $("#items" + i + "_Description").val();
            items[i] = type + sort + required + title + placeholder;
            data["items"] = items;
            subItemLength = $("#efis_" + i + " > div").length;
            console.log(subItemLength);
            subItemValue = "";
            for (var j = 0; j < subItemLength; j++) {
                subItemValue += $("#efis_" + i + ">div>#Subitems" + j).val() + "$";
            }
            console.log(subItemValue);
            subItems[i] = subItemValue;
            data["subItems"] = subItems;
        }
    } else {
        data["items"] = null;
        data["subItems"] = null;
    }

    if (formtitle != "" && formtitle != null) {
        data["formtitle"] = formtitle;
        $.ajax({
            type: 'post',
            url: "index.aspx/SavaForm",
            contentType: "application/json; charset=utf-8",
            data: $.toJSON(data),
            dataType: "json",
            success: function (result) {
                alert("保存成功");
                window.location = "list.aspx";
            },
            error: function (err) {
                var obj = $.parseJSON(err.responseText);
                alert(obj.Message);
            }
        });
    } else {
        alert("表单名称不可为空");
    }
});

var formCommonItems = [{
    "Key": "I_-1",
    "Sort": -1,
    "Type": "input",
    "Category": "FIELD_COMPANY",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "公司",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单行文本框",
    "Name": "company"
}, {
    "Key": "I_-1",
    "Sort": -1,
    "Type": "input",
    "Category": "FIELD_DEPARTMENT",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "部门",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单行文本框"
}, {
    "Key": "I_-1",
    "Sort": -1,
    "Type": "input",
    "Category": "FIELD_OFFICE",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "职位",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单行文本框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "checkbox",
    "Category": "FIELD_HOBBY",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "兴趣爱好",
    "Subitems": ["文艺", "音乐", "运动", "数码", "购物", "读书", "旅游", "时尚", "其他"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "多选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "FIELD_BLOOD",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "血型",
    "Subitems": ["A型", "B型", "O型", "AB型"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "FIELD_MARRIAGE",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "婚姻状况",
    "Subitems": ["未婚", "已婚", "保密"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_-1",
    "Sort": -1,
    "Type": "radio",
    "Category": "FIELD_GENDER",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "性别",
    "Subitems": ["男", "女"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "FIELD_AGE_RANGE",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "年龄",
    "Subitems": ["15以下", "16~20岁", "21~25岁", "26~30岁", "31~40岁", "40岁以上"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "FIELD_EDUCATION",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "学历",
    "Subitems": ["小学", "中学", "大专", "本科", "研究生以上"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "select",
    "Category": "FIELD_RESIDENCE",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "住址",
    "Subitems": ["北京", "上海", "广东", "江苏", "其他"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "下拉选择框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "FIELD_WAGE",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "月收入",
    "Subitems": ["少于3000", "3000~5000", "5000~10000", "10000~20000", "20000以上"],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_-1",
    "Sort": -1,
    "Type": "textarea",
    "Category": "FIELD_DESCRIPTION",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "其他",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "多行文本框"
}];
var formEmptyItems = [{
    "Key": "I_0",
    "Sort": 0,
    "Type": "input",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单行文本框",
    "Name": "inputtext"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "number",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "数字输入框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "date",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "日期选择框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "email",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "邮箱输入框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "textarea",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "多行文本框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "radio",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "单选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "checkbox",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "多选按钮框"
}, {
    "Key": "I_0",
    "Sort": 0,
    "Type": "select",
    "Category": "CUSTOM",
    "IsDefault": false,
    "Required": false,
    "Multiple": false,
    "Title": "",
    "Subitems": [],
    "Description": null,
    "IsHide": false,
    "Value": null,
    "TypeTitle": "下拉选择框"
}];
var formItemsJson = new Array();
var formEditableVar = true;
var $formItemTemp = $("#event_template_form_items");
var formItemOrder = [],
    formItemsJsonTemp = []

function renderEventFormItemValues(i, tmpItem) {
    itemsHtml = ''
    if (tmpItem.Subitems != null && tmpItem.Subitems.length > 0) {
        for (var j = 0; j < tmpItem.Subitems.length; j++) {
            itemsHtml += '<div><input type="text" class="form-control required" id="Subitems' + j + '" name="Subitems' + j + '" value="' + (tmpItem.Subitems[j] == null ? "" : tmpItem.Subitems[j].replace("\"", "\\\"").replace("\n", " ")) + '" onchange = "javascript:onChangeFormItemValue(3, this, ' + i + ', ' + j + ');"/>';
            itemsHtml += '<span name="event_form_item_ctrl" class="icon-close" onclick="javascript:removeEventFormItemValue(' + i + ',' + j + ');"></span></div>';
        }
    }
    itemsHtml += '<button class="btn create-event-label" onclick="javascript:addEventFormItemValue(' + i + ');return false;"><span name="event_form_item_ctrl" class="icon-event-label-add"></span></button>';
    return itemsHtml;
}

function renderEventFormTemplate() {
    var itemsHtml = "";
    if (formItemsJson != null && formItemsJson.length > 0) {
        for (i = 0; i < formItemsJson.length; i++) {
            var tmpItem = formItemsJson[i];
            var title = tmpItem.Title == "" ? tmpItem.TypeTitle : tmpItem.Title
            itemsHtml += '<div class="form-group" id="efi_' + i + '">';

            itemsHtml += '<input type="hidden" id="items' + i + '_Type" name="items' + i + '_Type" value="' + (tmpItem.Type) + '" />';
            itemsHtml += '<input type="hidden" id="items' + i + '_Sort" name="items' + i + '_Sort" value="' + i + '" />';

            itemsHtml += '<label><input type="checkbox" id="items' + i + '_Required" name="items' + i + '_Required" value="false" ' + (tmpItem.Required ? 'checked="checked"' : '') + ' onchange="javascript:onChangeFormItemValue(0, this, ' + i + ', 0);"/>必填</label>';

            itemsHtml += '<input type="text" class="form-control required" title="' + title + '" placeholder="' + title + '" id="items' + i + '_Title" name="items' + i + '_Title" value="' + (tmpItem.Title == null ? "" : tmpItem.Title.replace("\"", "\\\"").replace("\n", " ")) + '" onchange="javascript:onChangeFormItemValue(1, this, ' + i + ', 0);"/>';

            itemsHtml += '<input type="text" id="items' + i + '_Description" name="items' + i + '_Description" class="form-control" value="' + (tmpItem.Description == null ? "" : tmpItem.Description.replace("\"", "\\\"").replace("\n", " ")) + '" onchange="javascript:onChangeFormItemValue(2, this, ' + i + ', 0);" placeholder="提示信息写在这里！"/>';
            itemsHtml += '<span name="event_form_item_ctrl" class="icon-trash" title="删除栏位" onclick="javascript:removeEventFormItem(' + i + ');return false;"></span>';

            if (tmpItem.Type == "radio" || tmpItem.Type == "checkbox" || tmpItem.Type == "select") {
                itemsHtml += '<div>选项列表<div class="event-create-sign-select" id="efis_' + i + '">';
                itemsHtml += renderEventFormItemValues(i, tmpItem);
                itemsHtml += '</div></div><div style="clear:both;"></div>';
            }

            itemsHtml += '</div>';
        }
    }

    $("#event_template_form_items").empty();
    $("#event_template_form_items").append(itemsHtml);

    if (!formEditableVar) {
        var formItemctrls = $("a[name='event_form_item_ctrl']");
        if (formItemctrls != null) {
            formItemctrls.attr("onclick", function () {
                return false;
            });
            formItemctrls.addClass("disabled");
        }
        var formItemInputs = $("#event_template_form_items input");
        if (formItemInputs != null) {
            formItemInputs.addClass("disabled");
            formItemInputs.attr("disabled", true);
        }
    }
}

function onChangeFormItemValue(type, itemObj, index, subIndex) {
    if (formItemsJson != null && formItemsJson.length > index && index >= 0) {
        var eleItem = $(itemObj);
        if (type == 0) {
            //formItemsJson[index].Required = eleItem.prop("checked");
            if (eleItem.prop('checked')) {
                formItemsJson[index].Required = eleItem.val("true");
            } else {
                formItemsJson[index].Required = eleItem.val("false");

            }
        }
        else if (type == 1) formItemsJson[index].Title = eleItem.val();
        else if (type == 2) formItemsJson[index].Description = eleItem.val();
        else if (type == 3) {
            if (formItemsJson[index].Subitems != null && formItemsJson[index].Subitems.length > subIndex && subIndex >= 0) {
                formItemsJson[index].Subitems[subIndex] = eleItem.val();
            }
        }
    }
}


function removeEventFormItem(index) {
    if (formItemsJson != null && formItemsJson.length > index && index >= 0) {
        formItemsJson.splice(index, 1);
        renderEventFormTemplate();
    }
    $(this).parent().tooltip('destroy')
    formItemsJsonTemp = formItemsJson.slice()
    $formItemTemp.sortable('refresh')

}

// 移除选项列表
function removeEventFormItemValue(index, subIndex) {
    if (formItemsJson != null && formItemsJson.length > index && index >= 0 && subIndex >= 0) {
        var tmpItem = formItemsJson[index];
        if (tmpItem.Subitems != null && tmpItem.Subitems.length > subIndex) {
            formItemsJson[index].Subitems.splice(subIndex, 1);
            var efis = $('#efis_' + index);
            if (efis != null) {
                efis.empty();
                efis.append(renderEventFormItemValues(index, formItemsJson[index]));
            }
        }
    }
}



// 添加选项列表
function addEventFormItemValue(index) {
    if (formItemsJson != null && formItemsJson.length > index && index >= 0) {
        if (formItemsJson[index].Subitems == null) formItemsJson[index].Subitems = new Array();
        formItemsJson[index].Subitems.push("");
        var efis = $('#efis_' + index);
        if (efis != null) {
            efis.empty();
            efis.append(renderEventFormItemValues(index, formItemsJson[index]));
        }
    }
}

function addEventFormEmptyItem(index) {
    if (formEmptyItems != null && formEmptyItems.length > index && index >= 0) {
        var emptyItem = formEmptyItems[index];
        if (emptyItem != null) {
            formItemsJson.push(createTemplateFormItem(emptyItem));
            renderEventFormTemplate();
        }
        formItemsJsonTemp = formItemsJson.slice()
        $formItemTemp.sortable('refresh')
    }
}


function addEventFormCommonItem(index) {
    if (formCommonItems != null && formCommonItems.length > index && index >= 0) {
        var commonItem = formCommonItems[index];
        if (commonItem != null) {
            formItemsJson.push(createTemplateFormItem(commonItem));
            renderEventFormTemplate();
        }
    }
    formItemsJsonTemp = formItemsJson.slice()
    $formItemTemp.sortable('refresh')
}



function createTemplateFormItem(item) {
    if (item == null) return null;
    var sortTmp = parseInt($("#template_form_sort_max").val());
    sortTmp++;
    var result = {
        Id: "I_" + sortTmp,
        Sort: sortTmp,
        Type: item.Type,
        Category: "CUSTOM",
        IsDefault: item.IsDefault,
        Required: false,
        Multiple: item.Multiple,
        Title: item.Title,
        Description: item.Description,
        IsHide: item.IsHide,
        TypeTitle: item.TypeTitle,
        Subitems: new Array()
    };
    if (item.Subitems != null && item.Subitems.length > 0) {
        for (var i = 0; i < item.Subitems.length; i++) result.Subitems.push(item.Subitems[i]);
    }
    $("#template_form_sort_max").val(sortTmp);
    return result;
}

function reviewEventFormView() {
    var htmlTmp = resolveEventFormView(formItemsJson, 0, false);
    if (htmlTmp == null || htmlTmp == "") htmlTmp = '<p style="font-size:14px;padding:0px 30px;color:gray;">未添加其他栏位</p>';
    $("#event_template_form_fields").empty();
    $("#event_template_form_fields").append(htmlTmp);
    $('#dlg-review-event-form').modal({
        show: true,
        backdrop: 'static'
    });
}


function sortFormItem() {
    formItemOrder = []
    $formItemTemp.find('.form-group').each(function () {
        formItemOrder.push(this.id.slice(4))
    });

    formItemsJsonTemp = formItemsJson.slice()
    formItemsJson = formItemOrder.map(function (v) {
        return v = formItemsJsonTemp[v]
    });
    renderEventFormTemplate();
    $formItemTemp.sortable('refresh');
}

$(function () {
    renderEventFormTemplate();
    $formItemTemp.on('sortupdate', sortFormItem);
});