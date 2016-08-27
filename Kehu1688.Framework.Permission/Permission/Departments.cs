using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///部门表
    /// <summary>
    [Serializable]
    [Table("Departments")]
    public partial class DepartmentsInfo
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
        /// 公司Id
        /// </summary>	
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 部门名称
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Guid _parentId = Guid.Empty;

        /// <summary>
        /// 父级部门
        /// </summary>	
        public Guid ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        private int _departmentType = 0;

        /// <summary>
        /// 部门类型,0:公司;1:部门;2:小组
        /// </summary>	
        public int DepartmentType
        {
            get { return _departmentType; }
            set { _departmentType = value; }
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