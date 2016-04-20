/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CustomRelationalCommandBuilder.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-19 10:18:37
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Internal;
using Microsoft.Data.Entity.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kehu1688.Framework.Store
{
    public class CustomRelationalCommandBuilder: IRelationalCommandBuilder
    {
        private readonly ISensitiveDataLogger _logger;
        private readonly DiagnosticSource _diagnosticSource;
        private readonly IRelationalTypeMapper _typeMapper;
        private readonly List<RelationalParameter> _parameters = new List<RelationalParameter>();

        public CustomRelationalCommandBuilder(
            [NotNull] ISensitiveDataLogger logger,
            [NotNull] DiagnosticSource diagnosticSource,
            [NotNull] IRelationalTypeMapper typeMapper)
        {
            Check.NotNull(logger, nameof(logger));
            Check.NotNull(diagnosticSource, nameof(diagnosticSource));
            Check.NotNull(typeMapper, nameof(typeMapper));

            _logger = logger;
            _diagnosticSource = diagnosticSource;
            _typeMapper = typeMapper;
        }

        public virtual IndentedStringBuilder CommandTextBuilder { get; } = new IndentedStringBuilder();

        public virtual IRelationalCommandBuilder AddParameter(
            [NotNull] string name,
            [CanBeNull] object value,
            [NotNull] Func<IRelationalTypeMapper, RelationalTypeMapping> mapType,
            bool? nullable)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(mapType, nameof(mapType));

            _parameters.Add(
                new RelationalParameter(
                    name,
                    value,
                    mapType(_typeMapper),
                    nullable));

            return this;
        }

        public virtual IRelationalCommand BuildRelationalCommand()
                => new CustomRelationalCommand(
                    _logger,
                    _diagnosticSource,
                    CommandTextBuilder.ToString(),
                    _parameters);

        public override string ToString() => CommandTextBuilder.ToString();
    }
}
