/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CustomRelationalCommandBuilderFactory.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-19 10:16:37
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public class CustomRelationalCommandBuilderFactory: IRelationalCommandBuilderFactory
    {
        private readonly ISensitiveDataLogger _logger;
        private readonly DiagnosticSource _diagnosticSource;
        private readonly IRelationalTypeMapper _typeMapper;

        public CustomRelationalCommandBuilderFactory(
            ISensitiveDataLogger<CustomRelationalCommandBuilderFactory> logger,
            DiagnosticSource diagnosticSource,
            IRelationalTypeMapper typeMapper)
        {
            Check.NotNull(logger, nameof(logger));
            Check.NotNull(diagnosticSource, nameof(diagnosticSource));
            Check.NotNull(typeMapper, nameof(typeMapper));

            _logger = logger;
            _diagnosticSource = diagnosticSource;
            _typeMapper = typeMapper;
        }

        public virtual IRelationalCommandBuilder Create()
            => new CustomRelationalCommandBuilder(
                _logger,
                _diagnosticSource,
                _typeMapper);
    }
}
