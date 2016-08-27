using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///部门授权
    /// <summary>
    [Serializable]
    [Table("DepartmentPermission")]
    public partial class DepartmentPermissionInfo
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
        private Guid _departmentId = Guid.Empty;

        /// <summary>
        /// 部门Id,对应Departments的Id
        /// </summary>	
        public Guid DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        private Guid _relationId = Guid.Empty;

        /// <summary>
        /// 相关Id,对应Roles,Users,Positions中的Id
        /// </summary>	
        public Guid RelationId
        {
            get { return _relationId; }
            set { _relationId = value; }
        }
        private int _relationType = 0;

        /// <summary>
        /// 相关标识,0:用户,1:角色,2:职位
        /// </summary>	
        public int RelationType
        {
            get { return _relationType; }
            set { _relationType = value; }
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