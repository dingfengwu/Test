using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///系统模块与表的关系表
    /// <summary>
    [Serializable]
    [Table("SysModuleTable")]
    public partial class SysModuleTableInfo
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
        private string _tableId = string.Empty;

        /// <summary>
        /// 联合主键,表Id,对应SysTables的Id
        /// </summary>	
        [Key]
        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
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