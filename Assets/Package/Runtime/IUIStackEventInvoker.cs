using System;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The interface that provide the finishAction access
    /// </summary>
    public interface IUIStackEventInvoker
    {
        /// <summary>
        /// The finish action
        /// </summary>
        Action finishAction { get; set; }
    }
}