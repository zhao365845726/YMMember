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
    /// 客源表
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.05.22 20:59</date>
    /// </author>
    /// </summary>
    [Description("客源表")]
    [PrimaryKey("ID")]
    public class Base_Customer : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 客源ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("客源ID")]
        public string ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [DisplayName("姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        [DisplayName("年龄")]
        public int? Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [DisplayName("性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <returns></returns>
        [DisplayName("手机号")]
        public string Tel { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        /// <returns></returns>
        [DisplayName("生日")]
        public string Birthday { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <returns></returns>
        [DisplayName("邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        /// <returns></returns>
        [DisplayName("QQ号")]
        public string QQ { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [DisplayName("身份证号")]
        public string IDCardNumber { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        [DisplayName("删除标记")]
        public bool? FlagDelete { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("备注")]
        public string Remark { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = CommonHelper.GetGuid;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ID = KeyValue;
        }
        #endregion
    }
}