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
    /// ����
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.06.19 12:06</date>
    /// </author>
    /// </summary>
    [Description("����")]
    [PrimaryKey("ID")]
    public class Base_Enclosure : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ID")]
        public string ID { get; set; }
        /// <summary>
        /// ���ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ID")]
        public string FK_ID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string Type { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public string FileName { get; set; }
        /// <summary>
        /// �ļ�·��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�·��")]
        public string FilePath { get; set; }
        /// <summary>
        /// �ļ���С
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ���С")]
        public string FileSize { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public string FileType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public DateTime? CreateDate { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ID = KeyValue;
        }
        #endregion
    }
}