<%@ WebHandler Language="C#" Class="Home" %>

using System;
using System.Web;
using System.Data;
using System.Configuration;
using YMDLL.Class;
using YMDLL.Common;

public class Home : IHttpHandler {

    public YM_SQLServer _sqlserver = new YM_SQLServer();

    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
        string action = context.Request.Params["action"];
        string strTel = "", strUserName = "", strResult = "",strTemp = "",strCreateTime = "",strUpdateTime = "",strId = "";
        string m_SQL = "", m_Where = " Where 1=1 ";
        bool isExec = false;
        try
        {
            switch (action)
            {
                case "WriteRecord":
                    strId = Guid.NewGuid().ToString();
                    strUserName = context.Request.Params["UserName"];
                    strTel = context.Request.Params["Tel"];
                    strResult = context.Request.Params["Result"];
                    strCreateTime = DateTime.Now.ToString();
                    strUpdateTime = DateTime.Now.ToString();
                    _sqlserver.dbInitialization(ReadAppSetting("SourceServer"),ReadAppSetting("SourceDB"));
                    m_SQL = "INSERT INTO Base_Physique(id,name,tel,result,createtime,updatetime) VALUES('" + 
                            strId + "','" + strUserName + "','" + strTel + "','" + strResult + "','" + 
                            strCreateTime + "','" + strUpdateTime + "')";
                    isExec = _sqlserver.dbExec(m_SQL);
                    if (isExec)
                    {
                        strTemp = "体质数据写入成功";
                    }
                    else
                    {
                        strTemp = "体质数据写入失败";
                    }
                    context.Response.Write(strTemp);
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