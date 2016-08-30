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
    /// ���ʼ���¼��
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.07.03 19:38</date>
    /// </author>
    /// </summary>
    [Description("���ʼ���¼��")]
    [PrimaryKey("id")]
    public class Base_Physique : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DisplayName("")]
        public string id { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string name { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("�绰")]
        public string tel { get; set; }
        /// <summary>
        /// ���ʼ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ʼ����")]
        public string result { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? createtime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? updatetime { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.id = CommonHelper.GetGuid;
            this.createtime = DateTime.Now;
        }
        /// <summary>
        /// �༭����
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