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
        public IDictionary<object, object?>? Items => httpContextAccessor?.HttpContext?.Items;
    }
}
