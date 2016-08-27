using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///用户表
    /// <summary>
    [Serializable]
    [Table("Users")]
    public partial class UsersInfo
    {
        #region Model

        private Guid _id = Guid.Empty;

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _companyId = Guid.Empty;

        /// <summary>
        /// 公司Id，对应SysCompany的Id
        /// </summary>	
        [Key]
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private int _accessFailedCount = 0;

        /// <summary>
        /// 登陆失败次数
        /// </summary>	
        public int AccessFailedCount
        {
            get { return _accessFailedCount; }
            set { _accessFailedCount = value; }
        }
        private bool _lockoutEnabled = false;

        /// <summary>
        /// 是否启用登陆失败锁定,0:不启用，1:启用
        /// </summary>	
        public bool LockoutEnabled
        {
            get { return _lockoutEnabled; }
            set { _lockoutEnabled = value; }
        }

        /// <summary>
        /// 锁定时长
        /// </summary>	
        public datetimeoffset LockoutEnd
        {
            get { return _lockoutEnd; }
            set { _lockoutEnd = value; }
        }
        private string _email = string.Empty;

        /// <summary>
        /// 登陆邮件地址
        /// </summary>	
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _normalizedEmail = string.Empty;

        /// <summary>
        /// 序列化过的登陆邮件地址
        /// </summary>	
        public string NormalizedEmail
        {
            get { return _normalizedEmail; }
            set { _normalizedEmail = value; }
        }
        private bool? _emailConfirmed = false;

        /// <summary>
        /// 是否启用邮件地址验证,0:不启用,1:启用
        /// </summary>	
        public bool? EmailConfirmed
        {
            get { return _emailConfirmed; }
            set { _emailConfirmed = value; }
        }
        private string _phoneNumber = string.Empty;

        /// <summary>
        /// 登陆手机号码
        /// </summary>	
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        private bool? _phoneNumberConfirmed = false;

        /// <summary>
        /// 是否启用手机号码验证,0:不启用，1：启用
        /// </summary>	
        public bool? PhoneNumberConfirmed
        {
            get { return _phoneNumberConfirmed; }
            set { _phoneNumberConfirmed = value; }
        }
        private string _userName = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>	
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _normalizedUserName = string.Empty;

        /// <summary>
        /// 序列化过的用户名
        /// </summary>	
        public string NormalizedUserName
        {
            get { return _normalizedUserName; }
            set { _normalizedUserName = value; }
        }
        private string _passwordHash = string.Empty;

        /// <summary>
        /// 密码的hash码
        /// </summary>	
        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }
        private string _securityStamp = string.Empty;

        /// <summary>
        /// 安全戳
        /// </summary>	
        public string SecurityStamp
        {
            get { return _securityStamp; }
            set { _securityStamp = value; }
        }
        private bool _twoFactorEnabled = false;

        /// <summary>
        /// 是否启用二因素验证,0:不启用，1;:启用
        /// </summary>	
        public bool TwoFactorEnabled
        {
            get { return _twoFactorEnabled; }
            set { _twoFactorEnabled = value; }
        }
        private string _userSecret = string.Empty;

        /// <summary>
        /// 用户密钥
        /// </summary>	
        public string UserSecret
        {
            get { return _userSecret; }
            set { _userSecret = value; }
        }
        private string _userToken = string.Empty;

        /// <summary>
        /// token
        /// </summary>	
        public string UserToken
        {
            get { return _userToken; }
            set { _userToken = value; }
        }
        private bool _isSysUser = false;

        /// <summary>
        /// 是否系统用户
        /// </summary>	
        public bool IsSysUser
        {
            get { return _isSysUser; }
            set { _isSysUser = value; }
        }

        private byte[] _concurrencyStamp = null;

        /// <summary>
        /// 并发时间戳
        /// </summary>	
        public byte[] ConcurrencyStamp
        {
            get { return _concurrencyStamp; }
            set { _concurrencyStamp = value; }
        }
        private Guid _createUserId = Guid.Empty;

        /// <summary>
        /// 创建用户Id,对应Users的Id
        /// </summary>	
        [Key]
        public Guid CreateUserId
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }
        private DateTime _createTime = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private Guid? _updateUserId = Guid.Empty;

        /// <summary>
        /// 修改用户Id,对应Users的Id
        /// </summary>
        public Guid? UpdateUserId
        {
            get { return _updateUserId; }
            set { _updateUserId = value; }
        }
        private DateTime? _updateTime = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 修改时间
        /// </summary>	
        public DateTime? UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
        private string _remark = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion Model
    }
}