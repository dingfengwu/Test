/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：User.cs
// 文件功能描述：
// 用户
//
// 创建人  ：WDF
// 创建日期：2016-03-08 
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kehu1688.Framework.Permission
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Employee:IEntity<Employee>
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }
        
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 员工工号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 性别(0：男;1：女)
        /// </summary>
        [Required]
        public int Gender { get; set; }
                
        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(50)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        [MaxLength(50)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [MaxLength(50)]
        public string Weixin { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [MaxLength(50)]
        public string QQ { get; set; }

        /// <summary>
        /// 其他联系方式
        /// </summary>
        [MaxLength(500)]
        public string OtherLink { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [MaxLength(100)]
        public string Photo { get; set; }
        
        /// <summary>
        /// 是否为系统用户
        /// </summary>
        [Required]
        public bool SysUser { get; set; } = false;

        /// <summary>
        /// 是否已经离职
        /// </summary>
        [Required]
        public bool IsDimission { get; set; } = false;

        /// <summary>
        /// 职务Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string PositionId { get; set; }

        /// <summary>
        /// 部门Id,对应<seealso cref="Department.Id"/>,且<seealso cref="Department.DepartmentType"/>为1
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 公司Id,对应<seealso cref="Department.Id"/>,且<seealso cref="Department.DepartmentType"/>为0
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string CompanyId { get; set; }

        /// <summary>
        /// 团队Id,对应<seealso cref="Department.Id"/>,且<seealso cref="Department.DepartmentType"/>为2
        /// </summary>
        [MaxLength(32)]
        public string TeamId { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(18)]
        public string IdCard { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? LeaveDate { get; set; }

        /// <summary>
        /// 员工姓名首字母拼音
        /// </summary>
        [MaxLength(10)]
        public string PinYin { get; set; }
        
        /// <summary>
        /// 帐号
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public Position Position { get; set; }
    }
}
