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

using System.Collections.Generic;

namespace Etherna.ExecContext
{
    /// <summary>
    /// Represents an execution context, where information can be put and retrieve alongside
    /// the process with a key-value dictionary.
    /// </summary>
    public interface IExecutionContext
    {
        /// <summary>
        /// The context dictionary.
        /// </summary>
        IDictionary<object, object?>? Items { get; }
    }
}
