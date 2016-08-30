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
    /// 附件
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.06.19 12:06</date>
    /// </author>
    /// </summary>
    [Description("附件")]
    [PrimaryKey("ID")]
    public class Base_Enclosure : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 附件ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("附件ID")]
        public string ID { get; set; }
        /// <summary>
        /// 外键ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("外键ID")]
        public string FK_ID { get; set; }
        /// <summary>
        /// 附件类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("附件类型")]
        public string Type { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("文件名称")]
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <returns></returns>
        [DisplayName("文件路径")]
        public string FilePath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        /// <returns></returns>
        [DisplayName("文件大小")]
        public string FileSize { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("文件类型")]
        public string FileType { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建日期")]
        public DateTime? CreateDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
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