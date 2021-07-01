using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The UI Stack Listener
    /// </summary>
    [System.Serializable]
    public class UIStackEventListener
    {
        /// <summary>
        /// The event invoker on the UI element
        /// </summary>
        [InterfaceType(typeof(IUIStackEventInvoker))]
        public MonoBehaviour eventInvoker;

        /// <summary>
        /// The state of the listener.
        /// Finished is true.
        /// </summary>
        [Tooltip("Finished is true")]
        public bool state;
    }
}