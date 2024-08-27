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

using Moq;
using Xunit;

namespace Etherna.ExecContext.AsyncLocal
{
    public class AsyncLocalContextHandlerTests
    {
        private readonly Mock<IHandledAsyncLocalContext> handledContext;
        private readonly AsyncLocalContextHandler handler;

        public AsyncLocalContextHandlerTests()
        {
            handledContext = new Mock<IHandledAsyncLocalContext>();
            handler = new AsyncLocalContextHandler(handledContext.Object, true);
        }

        [Fact]
        public void Initialization()
        {
            // Assert.
            Assert.Equal(handledContext.Object, handler.HandledContext);
        }

        [Fact]
        public void ActiveHandlerDispose()
        {
            // Action.
            handler.Dispose();

            // Assert.
            handledContext.Verify(c => c.OnDisposed(handler), Times.Once);
        }

        [Fact]
        public void PassiveHandlerDispose()
        {
            // Setup.
            var passiveHandler = new AsyncLocalContextHandler(handledContext.Object, false);

            // Action.
            passiveHandler.Dispose();

            // Assert.
            handledContext.Verify(c => c.OnDisposed(passiveHandler), Times.Never);
        }
    }
}
