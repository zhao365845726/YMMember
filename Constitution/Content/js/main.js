var m_Result = "";
var a = Array();

$(function () {
    //首页提交按钮
    $("#btnSubmit").click(function () {
        var m_UserName = $("#txtusername").val();
        var m_Tel = $("#txttel").val();
        if (m_UserName == "" || m_UserName == undefined) {
            alert("姓名不能为空");
            return;
        }
        if (m_Tel == "" || m_Tel == undefined) {
            alert("电话不能为空");
            return;
        }
        localStorage.clear();
        localStorage.setItem("UserName", m_UserName);
        localStorage.setItem("Tel", m_Tel);
        submitData();
    });
});

//返回多条调理记录
function writeRecord() {
    var m_UserName = localStorage.getItem("UserName");
    var m_Tel = localStorage.getItem("Tel");
    var m_Result = localStorage.getItem("Result");
    if(m_UserName == "" || m_UserName == undefined || 
        m_Tel == "" || m_Tel == undefined || 
        m_Result == "" || m_Result == undefined) {
        alert("数据为空");
        location.href = "index.html";
    }
    $.ajax({
        type: "POST",
        url: "../../Ashx/Home.ashx",
        data: {
            "action": "WriteRecord",
            "UserName": m_UserName,
            "Tel": m_Tel,
            "Result": m_Result
        },
        dataType: "text",
        success: function (value) {
            alert(value);
            if (value == "体质数据写入成功") {
                localStorage.clear();
            }
        }
    });
}

//提交数据
function submitData() {
    var Obj = $(":input[type=radio]:checked");
    var a1 = 0; a2 = 0; a3 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0;
    $.each(Obj, function (i, item) {
        if (item.name.substring(13, 14) == '1' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a1 = a1 + 1;
        }

        if (item.name.substring(13, 14) == '2' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a2 = a2 + 1;
        }

        if (item.name.substring(13, 14) == '3' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a3 = a3 + 1;
        }

        if (item.name.substring(13, 14) == '4' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a4 = a4 + 1;
        }

        if (item.name.substring(13, 14) == '5' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a5 = a5 + 1;
        }

        if (item.name.substring(13, 14) == '6' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a6 = a6 + 1;
        }

        if (item.name.substring(13, 14) == '7' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a7 = a7 + 1;
        }

        if (item.name.substring(13, 14) == '8' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a8 = a8 + 1;
        }

        if (item.name.substring(13, 14) == '9' && parseInt(item.value) >= 1) {
            if (isNaN(a[i])) {
                a[i] = 0;
            }
            a9 = a9 + 1;
        }
        
    });

    if (a1 >= 2) {
        m_Result += $("#const1").text() + "体质;";
    }

    if (a2 >= 2) {
        m_Result += $("#const2").text() + "体质;";
    }

    if (a3 >= 2) {
        m_Result += $("#const3").text() + "体质;";
    }

    if (a4 >= 2) {
        m_Result += $("#const4").text() + "体质;";
    }

    if (a5 >= 2) {
        m_Result += $("#const5").text() + "体质;";
    }

    if (a6 >= 2) {
        m_Result += $("#const6").text() + "体质;";
    }

    if (a7 >= 2) {
        m_Result += $("#const7").text() + "体质;";
    }

    if (a8 >= 2) {
        m_Result += $("#const8").text() + "体质;";
    }

    if (a9 >= 2) {
        m_Result += $("#const9").text() + "体质;";
    }

    localStorage.setItem("Result", "您是：" + m_Result);

    location.href = "result.html";
}


function writelog(value,index) {
    console.log('a' + index + '---->' + value)
}