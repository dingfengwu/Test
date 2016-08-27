using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///公司表
    /// <summary>
    [Serializable]
    [Table("SysCompany")]
    public partial class SysCompanyInfo
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
        private string _name = string.Empty;

        /// <summary>
        /// 公司名
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _license = string.Empty;

        /// <summary>
        /// 授权码
        /// </summary>	
        public string License
        {
            get { return _license; }
            set { _license = value; }
        }
        private string _tel = string.Empty;

        /// <summary>
        /// 电话
        /// </summary>	
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        private string _fax = string.Empty;

        /// <summary>
        /// 传真
        /// </summary>	
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _address = string.Empty;

        /// <summary>
        /// 公司地址
        /// </summary>	
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _domain = string.Empty;

        /// <summary>
        /// 域名
        /// </summary>	
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
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