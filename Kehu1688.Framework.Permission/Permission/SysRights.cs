using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///系统权限项表
    /// <summary>
    [Serializable]
    [Table("SysRights")]
    public partial class SysRightsInfo
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
        private string _rightKey = string.Empty;

        /// <summary>
        /// 权限key值
        /// </summary>	
        public string RightKey
        {
            get { return _rightKey; }
            set { _rightKey = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 权限名称
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _parallelRight = string.Empty;

        /// <summary>
        /// 当拥有RightKey的权限时，ParallelRight所指向的权限也就拥有了。
        /// </summary>	
        public string ParallelRight
        {
            get { return _parallelRight; }
            set { _parallelRight = value; }
        }
        private bool _enabled = false;

        /// <summary>
        /// 是否启用，0：不启用，1：启用,不启用，则当删除CompanyRights中相关的记录
        /// </summary>	
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        private int _order = 0;

        /// <summary>
        /// 权限项顺序
        /// </summary>	
        public int Order
        {
            get { return _order; }
            set { _order = value; }
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