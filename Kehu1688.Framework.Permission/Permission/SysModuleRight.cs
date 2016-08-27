using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///系统模块权限表
    /// <summary>
    [Serializable]
    [Table("SysModuleRight")]
    public partial class SysModuleRightInfo
    {
        #region Model

        private Guid _moduleId = Guid.Empty;

        /// <summary>
        /// 联合主键,模块Id,对应SysModules的Id
        /// </summary>	
        [Key]
        public Guid ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }
        private Guid _rightId = Guid.Empty;

        /// <summary>
        /// 联合主键,权限项Id,对应SysRights的Id
        /// </summary>	
        [Key]
        public Guid RightId
        {
            get { return _rightId; }
            set { _rightId = value; }
        }
        private bool _enabled = false;

        /// <summary>
        /// 是否启用，0：不启用，1：启用,不启用，则当删除CompanyModuleRight中相关的记录
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