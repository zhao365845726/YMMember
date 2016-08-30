//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2016
// Software Developers @ Learun 2016
//=====================================================================================

using LeaRun.DataAccess.Attributes;
using LeaRun.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaRun.Entity
{
    /// <summary>
    /// 测试表
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.05.22 15:58</date>
    /// </author>
    /// </summary>
    [Description("测试表")]
    [PrimaryKey("Id")]
    public class TestOne : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("主键ID")]
        public string Id { get; set; }
        /// <summary>
        /// 测试名字
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试名字")]
        public string Name { get; set; }
        /// <summary>
        /// 测试备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试备注")]
        public string Remark { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.Id = KeyValue;
                                            }
        #endregion
    }
}