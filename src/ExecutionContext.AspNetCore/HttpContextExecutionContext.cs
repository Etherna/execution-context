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

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Etherna.ExecContext.AspNetCore
{
    public class HttpContextExecutionContext : IExecutionContext
    {
        // Fields.
        private readonly IHttpContextAccessor httpContextAccessor;

        // Constructors.
        public HttpContextExecutionContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        // Properties.
        public IDictionary<object, object?>? Items => httpContextAccessor.HttpContext?.Items;
    }
}
