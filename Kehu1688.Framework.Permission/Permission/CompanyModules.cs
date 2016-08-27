using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///公司模块管理表
    /// <summary>
    [Serializable]
    [Table("CompanyModules")]
    public partial class CompanyModulesInfo
    {
        #region Model

        private Guid _companyId = Guid.Empty;

        /// <summary>
        /// 联合主键,公司Id,对应SysCompany的Id
        /// </summary>	
        [Key]
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private Guid _id = Guid.Empty;

        /// <summary>
        /// 联合主键,模块Id,对应SysModules的Id
        /// </summary>	
        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _moduleKey = string.Empty;

        /// <summary>
        /// 模块key
        /// </summary>	
        public string ModuleKey
        {
            get { return _moduleKey; }
            set { _moduleKey = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 模块名
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Guid _menuId = Guid.Empty;

        /// <summary>
        /// 菜单Id,与SysMenus的Id关联
        /// </summary>	
        public Guid MenuId
        {
            get { return _menuId; }
            set { _menuId = value; }
        }
        private bool _enabled = false;

        /// <summary>
        /// 是否启用此模块，0:不启用，1：启用,如果不启用，则应当删除CompanyModules对应的记录
        /// </summary>	
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        private bool _authorize = false;

        /// <summary>
        /// 是否进行权限验证，0:不验证，1：验证
        /// </summary>	
        public bool Authorize
        {
            get { return _authorize; }
            set { _authorize = value; }
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