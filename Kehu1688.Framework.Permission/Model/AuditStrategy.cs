/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：AuditStrategy.cs
// 文件功能描述：
// 审核策略实体类
//
// 创建人  ：WZJ
// 创建日期：2016-04-27 10:20:00
//----------------------------------------------------------------*/


using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Model
{
    public class AuditStrategy : IEntity<AuditStrategy>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 来源类型
        /// </summary>
        public string fromType { get; set; }
        /// <summary>
        /// 来源id
        /// </summary>
        public string fromId { get; set; }
        /// <summary>
        /// 是否可以反审核
        /// </summary>
        public bool isReaudit { get; set; }
        /// <summary>
        /// 是否允许所有人审核
        /// </summary>
        public bool isAllApply { get; set; }
        /// <summary>
        /// 审核最大轮数
        /// </summary>
        public int maxRountNumber { get; set; }
        /// <summary>
        /// 可申请对象
        /// </summary>
        public string canApplicant { get; set; }
        /// <summary>
        /// 可审核对象
        /// </summary>
        public string canAuditor { get; set; }
        /// <summary>
        /// 可反审核对象
        /// </summary>
        public string canReauditor { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 设置可申请对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SetCanApplicant(List<Framework.Permission.Model.OperationManViewModel> list)
        {
            try
            {
                canApplicant = list.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置可审核对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SetCanAuditor(List<Framework.Permission.Model.OperationManViewModel> list)
        {
            try
            {
                canAuditor = list.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置可反审核对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SetCanReauditor(List<Framework.Permission.Model.OperationManViewModel> list)
        {
            try
            {
                canReauditor = list.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取可申请对象
        /// </summary>
        /// <returns></returns>
        public List<Framework.Permission.Model.OperationManViewModel> GetCanApplicant()
        {
            try
            {
                return CommonExtenstion.ToJson<List<Framework.Permission.Model.OperationManViewModel>>(canApplicant);
            }
            catch
            {
                return new List<Framework.Permission.Model.OperationManViewModel>();
            }
        }

        /// <summary>
        /// 获取可审核对象
        /// </summary>
        /// <returns></returns>
        public List<Framework.Permission.Model.OperationManViewModel> GetCanAuditor( )
        {
            try
            { 
                return CommonExtenstion.ToJson<List<Framework.Permission.Model.OperationManViewModel>>(canAuditor);
            }
            catch
            {
                return new List<Framework.Permission.Model.OperationManViewModel>();
            }
        }

        /// <summary>
        /// 获取可反审核对象
        /// </summary>
        /// <returns></returns>
        public List<Framework.Permission.Model.OperationManViewModel> GetCanReauditor( )
        {
            try
            {
                return CommonExtenstion.ToJson<List<Framework.Permission.Model.OperationManViewModel>>(canReauditor); 
            }
            catch
            {
                return new List<Framework.Permission.Model.OperationManViewModel>();
            }
        }

    }
}
