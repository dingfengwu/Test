using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///角色表
    /// <summary>
    [Serializable]
    [Table("Roles")]
    public partial class RolesInfo
    {
        #region Model

        private Guid _id = Guid.Empty;

        /// <summary>
        /// 主键Id
        /// </summary>	
        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _companyId = Guid.Empty;

        /// <summary>
        /// 公司Id,对应SysCompany的Id
        /// </summary>	
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 角色名称
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _normalizedName = string.Empty;

        /// <summary>
        /// 序列化过的角色名
        /// </summary>	
        public string NormalizedName
        {
            get { return _normalizedName; }
            set { _normalizedName = value; }
        }
        private bool _enabled = false;

        /// <summary>
        /// 是否启用,0:不启用，1：启用
        /// </summary>	
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        private bool _isSysRole = false;

        /// <summary>
        /// 是否系统角色,0:不是,1:是
        /// </summary>	
        public bool IsSysRole
        {
            get { return _isSysRole; }
            set { _isSysRole = value; }
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