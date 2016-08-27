using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///模块授权
    /// <summary>
    [Serializable]
    [Table("ModulePermission")]
    public partial class ModulePermissionInfo
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
        /// 公司Id,与SysCompany的Id关联
        /// </summary>	
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private Guid _moduleId = Guid.Empty;

        /// <summary>
        /// 模块Id,对应CompanyModule的Id
        /// </summary>	
        public Guid ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
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
        private int _properties = 0;

        /// <summary>
        /// Properties
        /// </summary>	
        public int Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
        private Guid _createUserId = Guid.Empty;

        /// <summary>
        /// 创建用户Id，对应Users表的Id
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