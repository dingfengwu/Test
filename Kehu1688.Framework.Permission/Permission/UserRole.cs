using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///用户角色表
    /// <summary>
    [Serializable]
    [Table("UserRole")]
    public partial class UserRoleInfo
    {
        #region Model

        private Guid _roleId = Guid.Empty;

        /// <summary>
        /// 联合主键
        /// </summary>	
        [Key]
        public Guid RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        private Guid _userId = Guid.Empty;

        /// <summary>
        /// 联合主键
        /// </summary>	
        [Key]
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
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

        #endregion Model
    }
}