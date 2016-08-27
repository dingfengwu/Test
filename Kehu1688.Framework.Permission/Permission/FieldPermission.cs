using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///字段权限管理
    /// <summary>
    [Serializable]
    [Table("FieldPermission")]
    public partial class FieldPermissionInfo
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
        /// 公司Id,对应SysCompany的Id
        /// </summary>	
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private Guid _moduleId = Guid.Empty;

        /// <summary>
        /// 模块Id,与CompanyModules的Id关联
        /// </summary>	
        public Guid ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }
        private Guid _tableId = Guid.Empty;

        /// <summary>
        /// 表Id,与CompanyTables的Id关联
        /// </summary>
        public Guid TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }
        private Guid _fieldId = Guid.Empty;

        /// <summary>
        /// 字段Id,与CompanyFields的Id关联
        /// </summary>	
        public Guid FieldId
        {
            get { return _fieldId; }
            set { _fieldId = value; }
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
        /// 关联标识,0:用户,1:角色,2:职位
        /// </summary>	
        public int RelationType
        {
            get { return _relationType; }
            set { _relationType = value; }
        }
        private int _properties = 0;

        /// <summary>
        /// 权限控制 1:可查询,2:可显示，4:可编辑,8:禁止查询,16:禁止显示,32:禁止编辑,多个值时求和.
        /// </summary>	
        public int Properties
        {
            get { return _properties; }
            set { _properties = value; }
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