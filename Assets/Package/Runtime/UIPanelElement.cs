using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// This is the base class for UIPanel
    /// All the UI panel logic class should inherit this class
    /// </summary>
    public class UIPanelElement : MonoBehaviour
    {
        #region Public Field

        /// <summary>
        /// The name of current UIPanelElement
        /// </summary>
        [BoxGroup("Panel Property")]
        public string panelName;

        #endregion
        
        #region UI Stack Callback Methods

        /// <summary>
        /// This method will be called when the UIPanelElement is pushed into the UI Stack
        /// </summary>
        public virtual void OnPush(){}
        
        /// <summary>
        /// This method will be called when the UIPanelElement is popped out from the UI Stack
        /// </summary>
        public virtual void OnPop(){}
        
        /// <summary>
        /// This method will be called when the UIPanelElement is paused
        /// To be specific, when current UIPanelElement is on the top of the UI Stack,
        /// the UIPanelElement is not paused
        /// When there's a new UIPanelElement pushed into the stack and current is no longer at the top of the stack,
        /// OnPause callback method will be called
        /// </summary>
        public virtual void OnPause(){}
        
        /// <summary>
        /// This method will be called when the UIPanelElement is resumed
        /// To be specific, when current UIPanelElement is not on the top of the UI Stack,
        /// the UIPanelElement is paused
        /// When the UIPanelElement on top of current panel is popped out,
        /// and current UIPanelElement is on the top of the stack,
        /// OnResume callback method will be called
        /// </summary>
        public virtual void OnResume(){}

        #endregion
    }
}