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
    /// 体质检测记录表
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.07.03 19:38</date>
    /// </author>
    /// </summary>
    [Description("体质检测记录表")]
    [PrimaryKey("id")]
    public class Base_Physique : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DisplayName("")]
        public string id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [DisplayName("姓名")]
        public string name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [DisplayName("电话")]
        public string tel { get; set; }
        /// <summary>
        /// 体质监测结果
        /// </summary>
        /// <returns></returns>
        [DisplayName("体质监测结果")]
        public string result { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public DateTime? createtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新时间")]
        public DateTime? updatetime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.id = CommonHelper.GetGuid;
            this.createtime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.id = KeyValue;
            this.updatetime = DateTime.Now;
        }
        #endregion
    }
}