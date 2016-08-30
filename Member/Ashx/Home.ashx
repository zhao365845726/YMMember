<%@ WebHandler Language="C#" Class="Home" %>

using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using YMDLL.Class;
using YMDLL.Common;

public class Home : IHttpHandler {

    public YM_SQLServer _sqlserver = new YM_SQLServer();

    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
        string action = context.Request.Params["action"];
        string strTel = "", strPassword = "", strID = "", strNewPassword = "",
                strResult = "", strMemberId = "", strConditionId = "", strSpectionID = "" ,
                strName = "",strAge = "",strBirthday = "", strProfession = "",strHomeAddress = "";
        string m_SQL = "", m_Where = " Where 1=1 ";
        bool isExec = false;
        try
        {
            switch (action)
            {
                case "ConditionList":
                    strMemberId = context.Request.Params["MemberId"];
                    m_SQL = "select ID,PrescriptionType,PrescriptionContent,CulinarianType,ConditioningResult,CreateTime from Base_ConditioningRecords where MemberId = '" + strMemberId + "' order by CreateTime ASC";
                    strResult = ReadSpecificalData(m_SQL);
                    context.Response.Write(strResult);
                    break;
                case "Condition":
                    strConditionId = context.Request.Params["ConditionId"];
                    m_SQL = "select PrescriptionType,PrescriptionContent,CulinarianType,ConditioningResult,Enclosure from Base_ConditioningRecords where ID = '" + strConditionId + "' order by CreateTime DESC";
                    strResult = ReadSpecificalData(m_SQL);
                    context.Response.Write(strResult);
                    break;
                case "InspectionList":
                    strMemberId = context.Request.Params["MemberId"];
                    m_SQL = "select ID,BloodPressure,BloodSugar,BloodFat,RoutineBloodTest,UrineRoutine,BloodType,LiverFunction,RenalFunction,AbdomenUltrasonography,Electrocardiogram,TraceElement,Enclosure,CreateTime from Base_InspectionRecord where MemberId = '" + strMemberId + "' order by CreateTime ASC";
                    strResult = ReadSpecificalData(m_SQL);
                    context.Response.Write(strResult);
                    break;
                case "Inspection":
                    strSpectionID = context.Request.Params["SpectionID"];
                    m_SQL = "select ID,BloodPressure,BloodSugar,BloodFat,RoutineBloodTest,UrineRoutine,BloodType,LiverFunction,RenalFunction,AbdomenUltrasonography,Electrocardiogram,TraceElement,Enclosure,CreateTime from Base_InspectionRecord where ID = '" + strSpectionID + "' order by CreateTime DESC";
                    strResult = ReadSpecificalData(m_SQL);
                    context.Response.Write(strResult);
                    break;
                case "LoginOn":
                    strTel = context.Request.Params["Tel"];
                    strPassword = context.Request.Params["Password"];
                    _sqlserver.dbInitialization(ReadAppSetting("SourceServer"),ReadAppSetting("SourceDB"));
                    if (strTel != "" && strPassword != "")
                    {
                        m_Where += "and Tel = '" + strTel + "' and Password = '" + strPassword + "'";
                    }
                    m_SQL = "SELECT Tel,Password FROM Base_Member ";

                    //strResult = ReadSpecificalData(m_SQL + m_Where);
                    isExec = _sqlserver.dbExec(m_SQL + m_Where);
                    if (isExec)
                    {
                        strResult = "1";
                    }
                    else
                    {
                        strResult = "0";
                    }
                    //strResult += "\n" + m_SQL + m_Where + "\n" + _sqlserver.iRows.ToString() ;
                    context.Response.Write(strResult);
                    break;
                case "Member":
                    strTel = context.Request.Params["Tel"];
                    strPassword = context.Request.Params["Password"];
                    if (strTel != "" && strPassword != "")
                    {
                        m_Where += "and Tel = '" + strTel + "' and Password = '" + strPassword + "'";
                    }
                    strResult = ReadSpecificalData("Base_Member", "ID,Name,Age,Sex,Disease,SubHealth,GroupNumber", m_Where);
                    context.Response.Write(strResult);
                    break;
                case "ResetPassword":
                    strID = context.Request.Params["memberId"];
                    strNewPassword = context.Request.Params["Password"];
                    _sqlserver.dbInitialization(ReadAppSetting("SourceServer"),ReadAppSetting("SourceDB"));
                    m_SQL = "UPDATE Base_Member SET Password = '" + strNewPassword + "' ";
                    m_Where = "WHERE ID = '" + strID + "'";
                    isExec = _sqlserver.dbExec(m_SQL + m_Where);
                    if (isExec)
                    {
                        strResult = "密码修改成功";
                    }
                    else
                    {
                        strResult = "密码修改失败";
                    }
                    context.Response.Write(strResult);
                    break;
                case "PrefectInfo":
                    strID = context.Request.Params["memberId"];
                    strName = context.Request.Params["Name"];
                    strAge = context.Request.Params["Age"];
                    strBirthday = context.Request.Params["Birthday"];
                    strProfession = context.Request.Params["Profession"];
                    strHomeAddress = context.Request.Params["HomeAddress"];
                    _sqlserver.dbInitialization(ReadAppSetting("SourceServer"),ReadAppSetting("SourceDB"));
                    m_SQL = "UPDATE Base_Member SET Name = '" + strName + "',Age = '" + strAge + "',Birthday='" + strBirthday
                            + "',Profession = '" + strProfession + "',HomeAddress = '" + strHomeAddress + "' ";
                    m_Where = "WHERE ID = '" + strID + "'";
                    isExec = _sqlserver.dbExec(m_SQL + m_Where);
                    if (isExec)
                    {
                        strResult = "修改成功";
                    }
                    else
                    {
                        strResult = "修改失败";
                    }
                    context.Response.Write(strResult);
                    break;
            }
        }
        catch (Exception ex)
        {
            context.Response.Write(ex.Message);
        }
    }

    public string ReadAppSetting(string Value)
    {
        string m_Result = ConfigurationManager.AppSettings[Value];
        return m_Result;
    }

    /// <summary>
    /// 读取指定条件查询出来的数据
    /// </summary>
    /// <param name="SQL"></param>
    /// <param name="Where"></param>
    /// <returns></returns>
    public string ReadSpecificalData(string Table, string Cols,string Where)
    {
        _sqlserver.dbInitialization(ReadAppSetting("SourceServer"), ReadAppSetting("SourceDB"));
        string m_SQL = "Select " + Cols + " From " + Table + Where;
        DataSet ds = _sqlserver.dbReadData(m_SQL);
        return JsonHelper.ToJson(ds);
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="SQL"></param>
    /// <param name="Where"></param>
    /// <returns></returns>
    public string ReadSpecificalData(string SQL)
    {
        _sqlserver.dbInitialization(ReadAppSetting("SourceServer"), ReadAppSetting("SourceDB"));
        DataSet ds = _sqlserver.dbReadData(SQL);
        return JsonHelper.ToJson(ds);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}