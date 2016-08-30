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
    /// 调理记录
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.06.16 23:13</date>
    /// </author>
    /// </summary>
    [Description("调理记录")]
    [PrimaryKey("ID")]
    public class Base_ConditioningRecords : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 调理ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("调理ID")]
        public string ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("会员ID")]
        public string MemberId { get; set; }
        /// <summary>
        /// 处方类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("处方类型")]
        public string PrescriptionType { get; set; }
        /// <summary>
        /// 处方内容
        /// </summary>
        /// <returns></returns>
        [DisplayName("处方内容")]
        public string PrescriptionContent { get; set; }
        /// <summary>
        /// 调理师类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("调理师类型")]
        public string CulinarianType { get; set; }
        /// <summary>
        /// 调理结果
        /// </summary>
        /// <returns></returns>
        [DisplayName("调理结果")]
        public string ConditioningResult { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        [DisplayName("附件")]
        public string Enclosure { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        [DisplayName("排序")]
        public int? Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人ID")]
        public string CreatePersonId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人")]
        public string CreatePerson { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新人ID")]
        public string UpdatePersonId { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新人")]
        public string UpdatePerson { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        [DisplayName("删除标记")]
        public bool? DeleteMark { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = CommonHelper.GetGuid;
            this.CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ID = KeyValue;
            this.UpdateTime = DateTime.Now;
        }
        #endregion
    }
}