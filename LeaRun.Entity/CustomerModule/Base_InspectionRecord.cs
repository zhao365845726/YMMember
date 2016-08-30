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
    /// ����¼
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.06.16 23:11</date>
    /// </author>
    /// </summary>
    [Description("����¼")]
    [PrimaryKey("ID")]
    public class Base_InspectionRecord : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ����¼
        /// </summary>
        /// <returns></returns>
        [DisplayName("����¼")]
        public string ID { get; set; }
        /// <summary>
        /// Ѫѹ
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ѫѹ")]
        public string BloodPressure { get; set; }
        /// <summary>
        /// Ѫ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ѫ��")]
        public string BloodSugar { get; set; }
        /// <summary>
        /// Ѫ֬
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ѫ֬")]
        public string BloodFat { get; set; }
        /// <summary>
        /// ���̴�
        /// </summary>
        /// <returns></returns>
        [DisplayName("���̴�")]
        public string Cholesterol { get; set; }
        /// <summary>
        /// Ѫ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ѫ����")]
        public string RoutineBloodTest { get; set; }
        /// <summary>
        /// �򳣹�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�򳣹�")]
        public string UrineRoutine { get; set; }
        /// <summary>
        /// Ѫ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ѫ��")]
        public string BloodType { get; set; }
        /// <summary>
        /// �ι���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ι���")]
        public string LiverFunction { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string RenalFunction { get; set; }
        /// <summary>
        /// ����B��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����B��")]
        public string AbdomenUltrasonography { get; set; }
        /// <summary>
        /// �ĵ�ͼ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ĵ�ͼ")]
        public string Electrocardiogram { get; set; }
        /// <summary>
        /// ΢��Ԫ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("΢��Ԫ��")]
        public string TraceElement { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Enclosure { get; set; }
        /// <summary>
        /// ��ҽ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("ChineseDiagnosis")]
        public string ChineseDiagnosis { get; set; }
        /// <summary>
        /// ��ҽ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("WESTDiagnosis")]
        public string WESTDiagnosis { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [DisplayName("MedicalRecord")]
        public string MedicalRecord { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ConditionRecommand")]
        public string ConditionRecommand { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Other { get; set; }
        /// <summary>
        /// ��ԱId
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ԱId")]
        public string MemberId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public int? Sort { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// ������Id
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Id")]
        public string CreatePersonId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string CreatePerson { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ������Id
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Id")]
        public string UpdatePersonId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string UpdatePerson { get; set; }
        /// <summary>
        /// ɾ����Ǻܱ�Ǹ,����Ȩ�޲���
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɾ�����")]
        public bool? DeleteMark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = CommonHelper.GetGuid;
            this.CreateTime = DateTime.Now;
        }
        /// <summary>
        /// �༭����
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