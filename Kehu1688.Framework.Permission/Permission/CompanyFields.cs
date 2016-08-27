using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kehu1688.Framework.Base;

namespace CRMWeb_Model.Permission
{
    /// <summary>
    ///公司字段管理表
    /// <summary>
    [Serializable]
    [Table("CompanyFields")]
    public partial class CompanyFieldsInfo:IEntity<CompanyFieldsInfo>
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
        /// 联合主键,字段Id，对应SysFields的Id
        /// </summary>	
        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _field = string.Empty;

        /// <summary>
        /// 字段
        /// </summary>	
        public string Field
        {
            get { return _field; }
            set { _field = value; }
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
        private Guid _tableId = Guid.Empty;

        /// <summary>
        /// 表Id,与SysTables的Id关联
        /// </summary>	
        public Guid TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }
        private bool _authorize = false;

        /// <summary>
        /// 是否进行权限验证，0：不验证，1：验证
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