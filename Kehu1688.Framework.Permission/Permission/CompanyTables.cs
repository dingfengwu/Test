using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///公司表管理表
    /// <summary>
    [Serializable]
    [Table("CompanyTables")]
    public partial class CompanyTablesInfo
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
        /// 联合主键,表Id，对应SysTables的Id
        /// </summary>	
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name = string.Empty;

        /// <summary>
        /// 表名
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _fLName = string.Empty;

        /// <summary>
        /// 别名
        /// </summary>	
        public string FLName
        {
            get { return _fLName; }
            set { _fLName = value; }
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