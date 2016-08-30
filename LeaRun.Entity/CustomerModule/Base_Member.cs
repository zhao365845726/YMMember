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
    /// Base_Member
    /// <author>
    ///		<name>MartyZane</name>
    ///		<date>2016.05.29 00:02</date>
    /// </author>
    /// </summary>
    [Description("Base_Member")]
    [PrimaryKey("ID")]
    public class Base_Member : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public string ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        [DisplayName("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        /// <returns></returns>
        [DisplayName("Age")]
        public int? Age { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        /// <returns></returns>
        [DisplayName("Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        /// <returns></returns>
        [DisplayName("Height")]
        public decimal? Height { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        /// <returns></returns>
        [DisplayName("Weight")]
        public decimal? Weight { get; set; }
        /// <summary>
        /// Face
        /// </summary>
        /// <returns></returns>
        [DisplayName("Face")]
        public string Face { get; set; }
        /// <summary>
        /// LeftEyeVision
        /// </summary>
        /// <returns></returns>
        [DisplayName("LeftEyeVision")]
        public Single? LeftEyeVision { get; set; }
        /// <summary>
        /// RightEysVision
        /// </summary>
        /// <returns></returns>
        [DisplayName("RightEysVision")]
        public Single? RightEysVision { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        /// <returns></returns>
        [DisplayName("Birthday")]
        public string Birthday { get; set; }
        /// <summary>
        /// Birthplace
        /// </summary>
        /// <returns></returns>
        [DisplayName("Birthplace")]
        public string Birthplace { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        /// <returns></returns>
        [DisplayName("Tel")]
        public string Tel { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        /// <returns></returns>
        [DisplayName("Password")]
        public string Password { get; set; }
        /// <summary>
        /// Zodiac
        /// </summary>
        /// <returns></returns>
        [DisplayName("Zodiac")]
        public string Zodiac { get; set; }
        /// <summary>
        /// IDCardNumber
        /// </summary>
        /// <returns></returns>
        [DisplayName("IDCardNumber")]
        public string IDCardNumber { get; set; }
        /// <summary>
        /// Photo
        /// </summary>
        /// <returns></returns>
        [DisplayName("Photo")]
        public string Photo { get; set; }
        /// <summary>
        /// Nation
        /// </summary>
        /// <returns></returns>
        [DisplayName("Nation")]
        public string Nation { get; set; }
        /// <summary>
        /// Nationality
        /// </summary>
        /// <returns></returns>
        [DisplayName("Nationality")]
        public string Nationality { get; set; }
        /// <summary>
        /// PoliticalLandscape
        /// </summary>
        /// <returns></returns>
        [DisplayName("PoliticalLandscape")]
        public string PoliticalLandscape { get; set; }
        /// <summary>
        /// AccountProperties
        /// </summary>
        /// <returns></returns>
        [DisplayName("AccountProperties")]
        public string AccountProperties { get; set; }
        /// <summary>
        /// Marriage
        /// </summary>
        /// <returns></returns>
        [DisplayName("Marriage")]
        public string Marriage { get; set; }
        /// <summary>
        /// BloodType
        /// </summary>
        /// <returns></returns>
        [DisplayName("BloodType")]
        public string BloodType { get; set; }
        /// <summary>
        /// Constellation
        /// </summary>
        /// <returns></returns>
        [DisplayName("Constellation")]
        public string Constellation { get; set; }
        /// <summary>
        /// HomeAddress
        /// </summary>
        /// <returns></returns>
        [DisplayName("HomeAddress")]
        public string HomeAddress { get; set; }
        /// <summary>
        /// LiveAddress
        /// </summary>
        /// <returns></returns>
        [DisplayName("LiveAddress")]
        public string LiveAddress { get; set; }
        /// <summary>
        /// Profession
        /// </summary>
        /// <returns></returns>
        [DisplayName("Profession")]
        public string Profession { get; set; }
        /// <summary>
        /// Job
        /// </summary>
        /// <returns></returns>
        [DisplayName("Job")]
        public string Job { get; set; }
        /// <summary>
        /// WorkingLife
        /// </summary>
        /// <returns></returns>
        [DisplayName("WorkingLife")]
        public string WorkingLife { get; set; }
        /// <summary>
        /// CurrentWorkUnit
        /// </summary>
        /// <returns></returns>
        [DisplayName("CurrentWorkUnit")]
        public string CurrentWorkUnit { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        /// <returns></returns>
        [DisplayName("QQ")]
        public string QQ { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// WeChat
        /// </summary>
        /// <returns></returns>
        [DisplayName("WeChat")]
        public string WeChat { get; set; }
        /// <summary>
        /// Vehicle
        /// </summary>
        /// <returns></returns>
        [DisplayName("Vehicle")]
        public string Vehicle { get; set; }
        /// <summary>
        /// Educational
        /// </summary>
        /// <returns></returns>
        [DisplayName("Educational")]
        public string Educational { get; set; }
        /// <summary>
        /// GraduateSchool
        /// </summary>
        /// <returns></returns>
        [DisplayName("GraduateSchool")]
        public string GraduateSchool { get; set; }
        /// <summary>
        /// IsGraduation
        /// </summary>
        /// <returns></returns>
        [DisplayName("IsGraduation")]
        public bool? IsGraduation { get; set; }
        /// <summary>
        /// Major
        /// </summary>
        /// <returns></returns>
        [DisplayName("Major")]
        public string Major { get; set; }
        /// <summary>
        /// ConsumptionConcept
        /// </summary>
        /// <returns></returns>
        [DisplayName("ConsumptionConcept")]
        public string ConsumptionConcept { get; set; }
        /// <summary>
        /// Hobby
        /// </summary>
        /// <returns></returns>
        [DisplayName("Hobby")]
        public string Hobby { get; set; }
        /// <summary>
        /// Character
        /// </summary>
        /// <returns></returns>
        [DisplayName("Character")]
        public string Character { get; set; }
        /// <summary>
        /// Skill
        /// </summary>
        /// <returns></returns>
        [DisplayName("Skill")]
        public string Skill { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        /// <returns></returns>
        [DisplayName("Source")]
        public string Source { get; set; }
        /// <summary>
        /// MonthlySalary
        /// </summary>
        /// <returns></returns>
        [DisplayName("MonthlySalary")]
        public decimal? MonthlySalary { get; set; }
        /// <summary>
        /// AnnualSalary
        /// </summary>
        /// <returns></returns>
        [DisplayName("AnnualSalary")]
        public decimal? AnnualSalary { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        /// <returns></returns>
        [DisplayName("FlagDelete")]
        public bool? FlagDelete { get; set; }
        /// <summary>
        /// Signature
        /// </summary>
        /// <returns></returns>
        [DisplayName("Signature")]
        public string Signature { get; set; }
        /// <summary>
        /// Motto
        /// </summary>
        /// <returns></returns>
        [DisplayName("Motto")]
        public string Motto { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        [DisplayName("Remark")]
        public string Remark { get; set; }
        /// <summary>
        /// AscriptionPerson
        /// </summary>
        /// <returns></returns>
        [DisplayName("AscriptionPerson")]
        public string AscriptionPerson { get; set; }
        /// <summary>
        /// AscriptionDepartment
        /// </summary>
        /// <returns></returns>
        [DisplayName("AscriptionDepartment")]
        public string AscriptionDepartment { get; set; }
        /// <summary>
        /// AscriptionCompany
        /// </summary>
        /// <returns></returns>
        [DisplayName("AscriptionCompany")]
        public string AscriptionCompany { get; set; }
        /// <summary>
        /// Disease
        /// </summary>
        /// <returns></returns>
        [DisplayName("Disease")]
        public string Disease { get; set; }
        /// <summary>
        /// SubHealth
        /// </summary>
        /// <returns></returns>
        [DisplayName("SubHealth")]
        public string SubHealth { get; set; }
        /// <summary>
        /// SafeTangGroup
        /// </summary>
        /// <returns></returns>
        [DisplayName("SafeTangGroup")]
        public string SafeTangGroup { get; set; }
        /// <summary>
        /// ChineseDiagnosis
        /// </summary>
        /// <returns></returns>
        [DisplayName("ChineseDiagnosis")]
        public string ChineseDiagnosis { get; set; }
        /// <summary>
        /// WESTDiagnosis
        /// </summary>
        /// <returns></returns>
        [DisplayName("WESTDiagnosis")]
        public string WESTDiagnosis { get; set; }
        /// <summary>
        /// MedicalRecord
        /// </summary>
        /// <returns></returns>
        [DisplayName("MedicalRecord")]
        public string MedicalRecord { get; set; }
        /// <summary>
        /// MembershipDate
        /// </summary>
        /// <returns></returns>
        [DisplayName("MembershipDate")]
        public string MembershipDate { get; set; }
        /// <summary>
        /// ExpireDate
        /// </summary>
        /// <returns></returns>
        [DisplayName("ExpireDate")]
        public string ExpireDate { get; set; }
        /// <summary>
        /// GroupNumber
        /// </summary>
        /// <returns></returns>
        [DisplayName("GroupNumber")]
        public string GroupNumber { get; set; }
        
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