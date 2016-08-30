using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Entity.EntityModel;
using LeaRun.Repository;
using LeaRun.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CustomerModule.Controllers
{
    /// <summary>
    /// Base_Member控制器
    /// </summary>
    public class MemberController : PublicController<Base_Member>
    {
        Base_MemberBll base_memberbll = new Base_MemberBll();

        /// <summary>
        /// 【会员管理】返回用户列表JSON
        /// </summary>
        /// <param name="keywords">查询关键字</param>
        /// <param name="jqgridparam">表格参数</param>
        /// <returns></returns>
        public ActionResult GridPageListJson(string keywords,JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                string userId = ManageProvider.Provider.Current().UserId;
                Dictionary<string, string> m_Request = new Dictionary<string, string>();

                string m_Name = Request.Params["name"].ToString();
                string m_Sex = Request.Params["sex"].ToString();
                if (m_Sex == "男")
                {
                    m_Sex = "1";
                }
                else if(m_Sex == "女")
                {
                    m_Sex = "0";
                }
                string m_Age = Request.Params["age"].ToString();
                string m_Tel = Request.Params["tel"].ToString();
                string m_Profession = Request.Params["profession"].ToString();
                string m_Disease = Request.Params["disease"].ToString();

                m_Request.Add("Name", m_Name);
                m_Request.Add("Sex", m_Sex);
                m_Request.Add("Age", m_Age);
                m_Request.Add("Tel", m_Tel);
                m_Request.Add("Profession", m_Profession);
                m_Request.Add("Disease", m_Disease);

                DataTable ListData = base_memberbll.GetPageList(keywords, userId,m_Request, ref jqgridparam);
                var JsonData = new
                {
                    total = jqgridparam.total,
                    page = jqgridparam.page,
                    records = jqgridparam.records,
                    costtime = CommonHelper.TimerEnd(watch),
                    rows = ListData,
                };
                return Content(JsonData.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        #region 文件上传、删除
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="Filedata"></param>
        /// <returns></returns>
        public ActionResult Upload(HttpPostedFileBase Filedata)
        {
            try
            {
                FileProperty fileproperty = new FileProperty();
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/Document/Email/{日期}/{guid}.{后缀名}
                //例如：/Resource/Document/Email/20130913/43CA215D947F8C1F1DDFCED383C4D706.jpg
                string fileGuid = CommonHelper.GetGuid;
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");

                string virtualPath = string.Format("~/Resource/Document/Member/{0}/{1}{2}", uploadDate, fileGuid, FileEextension);
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹，保存文件
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    Filedata.SaveAs(fullFileName);
                    fileproperty.Id = fileGuid;
                    fileproperty.Name = Filedata.FileName;
                    fileproperty.Eextension = FileEextension;
                    fileproperty.CreateDate = DateTime.Now;
                    fileproperty.Path = virtualPath;
                    fileproperty.Size = SizeHelper.CountSize(filesize);
                }
                return Content(fileproperty.ToJson());
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="Path">路径</param>
        /// <returns></returns>
        public ActionResult DeleteFile(string Path)
        {
            try
            {
                string FilePath = this.Server.MapPath(Path);
                if (System.IO.File.Exists(FilePath))
                    System.IO.File.Delete(FilePath);
                return Content(new JsonMessage { Success = true, Code = "1", Message = "删除成功" }.ToString());
            }
            catch (Exception ex)
            {
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "操作失败：" + ex.Message }.ToString());
            }
        }
        #endregion
    }
}