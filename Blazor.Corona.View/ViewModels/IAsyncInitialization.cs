using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    /// <summary>
    /// Marks a type as requiring asynchronous initialization and provides the result of that initialization.
    /// 코드 참조 : https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
    /// </summary>
    internal interface IAsyncInitialization
    {
        /// <summary>
        /// The result of the asynchronous initialization of this instance.
        /// </summary>
        Task Initialization { get; }
    }
}
