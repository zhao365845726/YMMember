var topnetwork = "http://www.ymstudio.xyz";
//var topnetwork = "F:/YMStudioWorking/YM-Network-Technology/YMMember333/YMMember/LeaRun.WebApp";


//登录
function LoginOn() {
    localStorage.clear();
    var strTel = $("#InputTel").val();
    var strPwd = $("#InputPassword").val();
    localStorage.setItem("Tel", strTel);
    localStorage.setItem("Password", strPwd);
    //self.location.href = encodeURI("center.html?Tel=" + strTel + "&Pwd=" + strPwd);
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "LoginOn", "Tel": strTel, "Password": strPwd },
        dataType: "text",
        success: function (data) {
            console.log(data);
            if (data == 0) {
                alert("用户名或密码错误");
            } else {
                self.location.href = encodeURI("center.html?Tel=" + strTel + "&Pwd=" + strPwd);
            }
        }
    });
}

//返回多条调理记录
function returnConditionList() {
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "ConditionList", "MemberId": localStorage.getItem("memberId") },
        dataType: "text",
        success: function (value) {
            data = eval('(' + value + ')');
            for (var key in data.Table) {
                $("#lstCondition").append("<li id='" + data.Table[key].ID + "' class='list-group-item' onclick=JumpCondition(this.id)><span class='glyphicon glyphicon-chevron-right' style='float:right;'></span>" + data.Table[key].CreateTime + "&nbsp;&nbsp;调理记录</li>");
            }
        }
    });
}

//跳转到详细页面
function JumpCondition(id) {
    localStorage.setItem("ConditionID", id);
    location.href = "condition.html";
}

//返回单条调理记录
function returnCondition() {
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "Condition", "ConditionId": localStorage.getItem("ConditionID") },
        dataType: "text",
        success: function (value) {
            data = eval('(' + value + ')');
            SetData(data.Table[0]);
            var strtemp = data.Table[0].Enclosure;
            var imagestemp;
            if (strtemp.indexOf(";") != -1) {
                imagestemp = strtemp.split(";");
                for (var i = 0; i < imagestemp.length - 1; i++) {
                    if (i == 0) {
                        $("#Enclosure").html("<a href='" + imagestemp[i].replace("~", topnetwork) + "' target='_blank'><img src='" + imagestemp[i].replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
                    } else {
                        $("#Enclosure").append("<br/><a href='" + imagestemp[i].replace("~", topnetwork) + "' target='_blank'><img src='" + imagestemp[i].replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
                    }
                    
                }
                
            } else {
                $("#Enclosure").html("<a href='" + strtemp.replace("~", topnetwork) + "' target='_blank'><img src='" + strtemp.replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
            }
        }
    });
}

//返回诊断记录
function returnInspectionList() {
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "InspectionList", "MemberId": localStorage.getItem("memberId") },
        dataType: "text",
        success: function (value) {
            data = eval('(' + value + ')');
            for (var key in data.Table) {
                $("#lstInspection").append("<li id='" + data.Table[key].ID + "' class='list-group-item' onclick=JumpInspection(this.id)><span class='glyphicon glyphicon-chevron-right' style='float:right;' ></span>" + data.Table[key].CreateTime + "&nbsp;&nbsp;检查记录</li>");
            }
        }
    });
}

//跳转到诊断页面
function JumpInspection(id) {
    localStorage.setItem("SpectionID", id);
    location.href = "inspection.html";
}

//返回诊断记录
function returnInspection() {
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "Inspection", "SpectionID": localStorage.getItem("SpectionID") },
        dataType: "text",
        success: function (value) {
            data = eval('(' + value + ')');
            SetData(data.Table[0]);
            var strtemp = data.Table[0].Enclosure;
            var imagestemp;
            if (strtemp.indexOf(";") != -1) {
                imagestemp = strtemp.split(";");
                for (var i = 0; i < imagestemp.length - 1; i++) {
                    if (i == 0) {
                        $("#Enclosure").html("<a href='" + imagestemp[i].replace("~", topnetwork) + "' target='_blank'><img src='" + imagestemp[i].replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
                    } else {
                        $("#Enclosure").append("<br/><a href='" + imagestemp[i].replace("~", topnetwork) + "' target='_blank'><img src='" + imagestemp[i].replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
                    }

                }
            } else {
                $("#Enclosure").html("<a href='" + strtemp.replace("~", topnetwork) + "' target='_blank'><img src='" + strtemp.replace("~", topnetwork) + "' class='img-responsive' alt='Responsive image' /></a>");
            }
            
        }
    });
}

//返回结果集
function returnResult() {
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "Member", "Tel": localStorage.getItem("Tel"), "Password": localStorage.getItem("Password") },
        dataType: "text",
        success: function (str) {
            //console.log('--->' + str);
            msg = eval('(' + str + ')');
            if (msg.Table[0] == undefined) {
                alert("用户名或密码错误");
                location.href = "index.html";
            }
            localStorage.setItem("memberId", msg.Table[0].ID);
            $("#name").text(msg.Table[0].Name);
            if (msg.Table[0].Sex == '0') {
                $("#sex").text("女");
            } else {
                $("#sex").text("男");
            }
            $("#age").text(msg.Table[0].Age);
            $("#disease").text(msg.Table[0].Disease);
            $("#subhealth").text(msg.Table[0].SubHealth);
            if (msg.Table[0].GroupNumber.length == 2) {
                $("#groupnumber").text("盟主");
            } else if (msg.Table[0].GroupNumber.length == 4) {
                $("#groupnumber").text("校长");
            } else if (msg.Table[0].GroupNumber.length == 6) {
                $("#groupnumber").text("会长");
            } else if (msg.Table[0].GroupNumber.length == 8) {
                $("#groupnumber").text("班长");
            } else if (msg.Table[0].GroupNumber.length == 10) {
                $("#groupnumber").text("组长");
            }
            //localStorage.clear();
        }
    });
}

//重置密码
function resetPassword() {
    var newPwd = $("#NewPassword").val();
    localStorage.setItem("Password", newPwd);
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: { "action": "ResetPassword", "memberId": localStorage.getItem("memberId"), "Password": newPwd },
        dataType: "text",
        success: function (str) {
            if (str == "密码修改成功") {
                alert(str);
                location.href = "index.html";
            } else {
                alert(str);
                $("#OldPassword").val("");
                $("#NewPassword").val("");
                $("#AgainNewPassword").val("");
                localStorage.clear();
            }
        }
    });
}

/*
自动给控件赋值
*/
function SetData(data) {
    for (var key in data) {
        var id = $('#' + key);
        var value = $.trim(data[key]).replace("&nbsp;", "");
        id.text(value);
    }
}

/*************************** --公共验证使用的js Start-- *****************************/
//手机号码验证
function validatemobile(mobile) {
    if (mobile.length == 0) {
        alert('请输入手机号码！');
        return false;
    }
    if (mobile.length != 11) {
        alert('请输入有效的手机号码！');
        return false;
    }
    //可验证153（联通）,159（移动）等新区段的开通
    var myreg = /^(((13[0-9]{1})|15[0-9])+\d{8})$/;
    if (!myreg.test(mobile)) {
        alert('请输入有效的手机号码！');
        return false;
    }
}

//电子邮箱的验证
function validateemail(email) {
    //对电子邮件的验证
    var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    if (!myreg.test(email)) {
        alert('提示\n\n请输入有效的E_mail！');
        return false;
    }
}

//验证密码
function validatepassword(pwd) {
    var test = /^[a-zA-Z0-9]+$/;              //正则表达式
    if (test.exec(pwd))                            //exec(string) 为验证字符串是否符合正则表达式
    {
        alert("对不起,只能输入8-16含有特殊符号字母数字的密码");
        return false;
    }
}

//js获取URL中的参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}

function GetRequestString() {
    var urlinfo = window.location.href;//获取url
    alert(urlinfo);
    var userName = urlinfo.split("?")[1].split("=")[1];//拆分url得到”=”后面的参数
    return decodeURI(userName);
}
/*************************** --公共验证使用的js End-- *****************************/

/*************************** --公共操作的Cookies Start-- *****************************/
//写cookies
function setCookie(name, value) {
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}

//读取cookies
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");

    if (arr = document.cookie.match(reg))

        return unescape(arr[2]);
    else
        return null;
}

//删除cookies
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}
/*************************** --公共操作的Cookies Start-- *****************************/