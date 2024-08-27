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

using System.Threading.Tasks;
using Xunit;

namespace Etherna.ExecContext.AsyncLocal
{
    public class AsyncLocalContextTests
    {
        private readonly AsyncLocalContext asyncLocalContext;

        public AsyncLocalContextTests()
        {
            asyncLocalContext = new AsyncLocalContext();
        }

        [Fact]
        public void ItemsNullAtCreation()
        {
            // Assert.
            Assert.Null(asyncLocalContext.Items);
        }

        [Fact]
        public async Task AsyncLocalLifeCycle()
        {
            await Task.Run(async () =>
            {
                // Action.
                asyncLocalContext.InitAsyncLocalContext();

                // Assert.
                Assert.NotNull(asyncLocalContext.Items);
                await Task.Run(() =>
                {
                    Assert.NotNull(asyncLocalContext.Items);
                });
            });

            // Assert.
            Assert.Null(asyncLocalContext.Items);
        }

        [Fact]
        public void SyncLocalLifeCycle()
        {
            void localMethod()
            {
                // Action.
                asyncLocalContext.InitAsyncLocalContext();

                // Assert.
                Assert.NotNull(asyncLocalContext.Items);
                void subLocalMethod()
                {
                    Assert.NotNull(asyncLocalContext.Items);
                }
                subLocalMethod();
            }
            localMethod();

            // Assert.
            /* Outside of an async invoker, the container is not automatically disposed. */
            Assert.NotNull(asyncLocalContext.Items);
        }

        [Fact]
        public void ContextDispose()
        {
            // Action.
            using (var handler = asyncLocalContext.InitAsyncLocalContext())
            {
                // Assert.
                Assert.NotNull(asyncLocalContext.Items);
            }

            // Assert.
            Assert.Null(asyncLocalContext.Items);
        }

        [Fact]
        public void SupportMultiInitialization()
        {
            // Action.
            using (var handler0 = AsyncLocalContext.Instance.InitAsyncLocalContext())
            {
                var originalItems = asyncLocalContext.Items;
                using var handler1 = AsyncLocalContext.Instance.InitAsyncLocalContext();

                // Assert.
                Assert.Equal(originalItems, asyncLocalContext.Items);
            }

            Assert.Null(asyncLocalContext.Items);
        }
    }
}
