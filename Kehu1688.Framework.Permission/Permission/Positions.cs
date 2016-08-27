using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kehu1688.Framework.Model.Permission
{
    /// <summary>
    ///职位表
    /// <summary>
    [Serializable]
    [Table("Positions")]
    public partial class PositionsInfo
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
        private string _name = string.Empty;

        /// <summary>
        /// 职位名称
        /// </summary>	
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private bool _isSysPosition = false;

        /// <summary>
        /// 是否为系统职务
        /// </summary>	
        public bool IsSysPosition
        {
            get { return _isSysPosition; }
            set { _isSysPosition = value; }
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
        private string _remark = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private Guid _updateUserId = Guid.Empty;

        /// <summary>
        /// 修改用户Id,对应Users的Id
        /// </summary>
        public Guid UpdateUserId
        {
            get { return _updateUserId; }
            set { _updateUserId = value; }
        }
        private DateTime _updateTime = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 修改时间
        /// </summary>	
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
        private Guid _createUserId = Guid.Empty;

        /// <summary>
        /// 创建用户Id，对应Users的Id
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