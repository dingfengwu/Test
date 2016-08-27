using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///系统菜单表
    /// <summary>
    [Serializable]
    [Table("SysMenus")]
    public partial class SysMenusInfo
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
        private string _menuKey = string.Empty;

        /// <summary>
        /// 菜单key值
        /// </summary>	
        public string MenuKey
        {
            get { return _menuKey; }
            set { _menuKey = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 菜单名称
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Guid _parentMenuId = Guid.Empty;

        /// <summary>
        /// 父级菜单Id,对应SysMenus的Id
        /// </summary>	
        public Guid ParentMenuId
        {
            get { return _parentMenuId; }
            set { _parentMenuId = value; }
        }
        private bool _enabled = false;

        /// <summary>
        /// 菜单是否启用，0：不启用，1：启用,不启用，则当删除CompanyMenus中相关的记录
        /// </summary>	
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
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