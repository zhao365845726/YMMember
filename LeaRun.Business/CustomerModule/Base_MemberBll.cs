//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2016
// Software Developers @ Learun 2016
//=====================================================================================
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Business
{
    /// <summary>
    /// Base_Member
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.05.29 00:02</date>
    /// </author>
    /// </summary>
    public class Base_MemberBll : RepositoryFactory<Base_Member>
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="keyword">模块查询</param>
        /// <param name="CompanyId">公司ID</param>
        /// <param name="DepartmentId">部门ID</param>
        /// <param name="jqgridparam">分页条件</param>
        /// Dictionary<string, string> dic_Request, 
        /// <returns></returns>
        public DataTable GetPageList(string keyword, string userId, Dictionary<string, string> dic_Request, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT u.ID
                                          ,u.Name
                                          ,u.Age
                                          ,u.Sex
                                          ,u.Height
                                          ,u.Weight
                                          ,u.Face
                                          ,u.LeftEyeVision
                                          ,u.RightEysVision
                                          ,u.Birthday
                                          ,u.Birthplace
                                          ,u.Tel
                                          ,u.Password
                                          ,u.Zodiac
                                          ,u.IDCardNumber
                                          ,u.Photo
                                          ,u.Nation
                                          ,u.Nationality
                                          ,u.PoliticalLandscape
                                          ,u.AccountProperties
                                          ,u.Marriage
                                          ,u.BloodType
                                          ,u.Constellation
                                          ,u.HomeAddress
                                          ,u.LiveAddress
                                          ,u.Profession
                                          ,u.Job
                                          ,u.WorkingLife
                                          ,u.CurrentWorkUnit
                                          ,u.QQ
                                          ,u.Email
                                          ,u.WeChat
                                          ,u.Vehicle
                                          ,u.Educational
                                          ,u.GraduateSchool
                                          ,u.IsGraduation
                                          ,u.Major
                                          ,u.ConsumptionConcept
                                          ,u.Hobby
                                          ,u.Character
                                          ,u.Skill
                                          ,u.Source
                                          ,u.MonthlySalary
                                          ,u.AnnualSalary
                                          ,u.FlagDelete
                                          ,u.Signature
                                          ,u.Motto
                                          ,u.Remark
                                          ,u.AscriptionPerson
                                          ,u.AscriptionDepartment
                                          ,u.AscriptionCompany
                                          ,u.Disease
                                          ,u.SubHealth
                                          ,u.SafeTangGroup
                                          ,u.ChineseDiagnosis
                                          ,u.WESTDiagnosis
                                          ,u.MedicalRecord
                                          ,u.MembershipDate
                                          ,u.ExpireDate
                                          ,u.GroupNumber
                                      FROM Base_Member u
                                    ) T WHERE 1=1");
            if (dic_Request.Count > 0)
            {
                if (!string.IsNullOrEmpty(dic_Request["Name"]))
                {
                    strSql.Append(@" AND (Name LIKE @name)");
                    parameter.Add(DbFactory.CreateDbParameter("@name", '%' + dic_Request["Name"].ToString() + '%'));
                }
                if (!string.IsNullOrEmpty(dic_Request["Sex"]))
                {
                    strSql.Append(@" AND (Sex = @sex)");
                    parameter.Add(DbFactory.CreateDbParameter("@sex", dic_Request["Sex"]));
                }
                if (!string.IsNullOrEmpty(dic_Request["Age"]))
                {
                    strSql.Append(@" AND (Age = @age)");
                    parameter.Add(DbFactory.CreateDbParameter("@age", dic_Request["Age"]));
                }
                if (!string.IsNullOrEmpty(dic_Request["Tel"]))
                {
                    strSql.Append(@" AND (Tel LIKE @tel)");
                    parameter.Add(DbFactory.CreateDbParameter("@tel", '%' + dic_Request["Tel"] + '%'));
                }
                if (!string.IsNullOrEmpty(dic_Request["Profession"]))
                {
                    strSql.Append(@" AND (Profession LIKE @profession)");
                    parameter.Add(DbFactory.CreateDbParameter("@profession", '%' + dic_Request["Profession"] + '%'));
                }
                if (!string.IsNullOrEmpty(dic_Request["Disease"]))
                {
                    strSql.Append(@" AND (Disease LIKE @disease)");
                    parameter.Add(DbFactory.CreateDbParameter("@disease", '%' + dic_Request["Disease"] + '%'));
                }
            }
            
            
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    strSql.Append(@" AND AscriptionPerson = @AscriptionPerson");
            //    parameter.Add(DbFactory.CreateDbParameter("@AscriptionPerson", userId));
            //}
            
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.Append(@" AND (Name LIKE @keyword
                                    OR Sex LIKE @keyword
                                    OR Age LIKE @keyword
                                    OR Disease LIKE @keyword
                                    OR SubHealth LIKE @keyword
                                    OR SafeTangGroup LIKE @keyword
                                    OR GroupNumber LIKE @keyword
                                    )");
                parameter.Add(DbFactory.CreateDbParameter("@keyword", '%' + keyword + '%'));
            }
            //if (!ManageProvider.Provider.Current().IsSystem)
            //{
            //    strSql.Append(" AND ( UserId IN ( SELECT ResourceId FROM Base_DataScopePermission WHERE");
            //    strSql.Append(" ObjectId IN ('" + ManageProvider.Provider.Current().ObjectId.Replace(",", "','") + "') ");
            //    strSql.Append(" ) )");
            //}
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
    }
}