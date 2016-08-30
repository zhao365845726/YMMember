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
    /// 检查记录
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.06.16 23:11</date>
    /// </author>
    /// </summary>
    [Description("检查记录")]
    [PrimaryKey("ID")]
    public class Base_InspectionRecord : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 检查记录
        /// </summary>
        /// <returns></returns>
        [DisplayName("检查记录")]
        public string ID { get; set; }
        /// <summary>
        /// 血压
        /// </summary>
        /// <returns></returns>
        [DisplayName("血压")]
        public string BloodPressure { get; set; }
        /// <summary>
        /// 血糖
        /// </summary>
        /// <returns></returns>
        [DisplayName("血糖")]
        public string BloodSugar { get; set; }
        /// <summary>
        /// 血脂
        /// </summary>
        /// <returns></returns>
        [DisplayName("血脂")]
        public string BloodFat { get; set; }
        /// <summary>
        /// 胆固醇
        /// </summary>
        /// <returns></returns>
        [DisplayName("胆固醇")]
        public string Cholesterol { get; set; }
        /// <summary>
        /// 血常规
        /// </summary>
        /// <returns></returns>
        [DisplayName("血常规")]
        public string RoutineBloodTest { get; set; }
        /// <summary>
        /// 尿常规
        /// </summary>
        /// <returns></returns>
        [DisplayName("尿常规")]
        public string UrineRoutine { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        /// <returns></returns>
        [DisplayName("血型")]
        public string BloodType { get; set; }
        /// <summary>
        /// 肝功能
        /// </summary>
        /// <returns></returns>
        [DisplayName("肝功能")]
        public string LiverFunction { get; set; }
        /// <summary>
        /// 肾功能
        /// </summary>
        /// <returns></returns>
        [DisplayName("肾功能")]
        public string RenalFunction { get; set; }
        /// <summary>
        /// 腹部B超
        /// </summary>
        /// <returns></returns>
        [DisplayName("腹部B超")]
        public string AbdomenUltrasonography { get; set; }
        /// <summary>
        /// 心电图
        /// </summary>
        /// <returns></returns>
        [DisplayName("心电图")]
        public string Electrocardiogram { get; set; }
        /// <summary>
        /// 微量元素
        /// </summary>
        /// <returns></returns>
        [DisplayName("微量元素")]
        public string TraceElement { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        [DisplayName("附件")]
        public string Enclosure { get; set; }
        /// <summary>
        /// 中医诊断
        /// </summary>
        /// <returns></returns>
        [DisplayName("ChineseDiagnosis")]
        public string ChineseDiagnosis { get; set; }
        /// <summary>
        /// 西医诊断
        /// </summary>
        /// <returns></returns>
        [DisplayName("WESTDiagnosis")]
        public string WESTDiagnosis { get; set; }
        /// <summary>
        /// 病历情况
        /// </summary>
        /// <returns></returns>
        [DisplayName("MedicalRecord")]
        public string MedicalRecord { get; set; }
        /// <summary>
        /// 调理建议
        /// </summary>
        /// <returns></returns>
        [DisplayName("ConditionRecommand")]
        public string ConditionRecommand { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        /// <returns></returns>
        [DisplayName("其他")]
        public string Other { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        /// <returns></returns>
        [DisplayName("会员Id")]
        public string MemberId { get; set; }
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
        /// 创建人Id
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人Id")]
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
        /// 更新人Id
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新人Id")]
        public string UpdatePersonId { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新人")]
        public string UpdatePerson { get; set; }
        /// <summary>
        /// 删除标记很抱歉,您的权限不足
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