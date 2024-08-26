// Copyright 2020-present Etherna SA
// This file is part of ExecutionContext.
// 
// ExecutionContext is free software: you can redistribute it and/or modify it under the terms of the
// GNU Lesser General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
// 
// ExecutionContext is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with ExecutionContext.
// If not, see <https://www.gnu.org/licenses/>.

using Etherna.ExecContext.AsyncLocal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Etherna.ExecContext.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExecutionContext(
            this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.TryAddSingleton<IExecutionContext>(serviceProvider =>
               new ExecutionContextSelector( //default
               [
                   new HttpContextExecutionContext(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                   AsyncLocalContext.Instance
               ]));

            return services;
        }
    }
}
