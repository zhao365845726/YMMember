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

namespace LeaRun.Business
{
    /// <summary>
    /// ���Ա�
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.05.22 15:58</date>
    /// </author>
    /// </summary>
    public class TestOneBll : RepositoryFactory<TestOne>
    {
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="keyword">ģ���ѯ</param>
        /// <param name="CompanyId">��˾ID</param>
        /// <param name="DepartmentId">����ID</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public DataTable GetPageList(string keyword, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    u.Id ,					--����ID
                                                u.Name ,					--��������
                                                u.Remark					--���Ա�ע
                                      FROM      TestOne u
                                    ) T WHERE 1=1");
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.Append(@" AND (Name LIKE @keyword
                                    OR Remark LIKE @keyword ");
                parameter.Add(DbFactory.CreateDbParameter("@keyword", '%' + keyword + '%'));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
    }
}