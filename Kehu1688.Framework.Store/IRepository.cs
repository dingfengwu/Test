/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IRepository.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 19:02:54
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public interface IRepository<TService, TModel> 
        where TModel : class, IEntity<TModel>, new()
        where TService : IRepository<TService, TModel>
    {
        TService Add(TModel entity);
        TService Update(TModel entity);
        TService Delete(TModel entity);
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate = null);
        Task BulkUpdate(List<TModel> entities);
        Task BulkDelete(Expression<Func<TModel, bool>> predicate = null);
        Task BulkAdd(List<TModel> entities);
        void SaveChanges();
    }

    public interface IRepository<TService>
    {
        TService Add<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new();
        TService Update<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new();
        TService Delete<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new();
        IEnumerable<TModel> Find<TModel>(Expression<Func<TModel, bool>> predicate = null) 
            where TModel : class, IEntity<TModel>, new();
        Task BulkUpdate<TModel>(List<TModel> entities) where TModel : class, IEntity<TModel>, new();
        Task BulkDelete<TModel>(Expression<Func<TModel, bool>> predicate = null) 
            where TModel : class, IEntity<TModel>, new();
        Task BulkAdd<TModel>(List<TModel> entities) where TModel : class, IEntity<TModel>, new();
        void SaveChanges();
    }
}
