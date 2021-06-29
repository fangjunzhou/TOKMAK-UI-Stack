using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// This is the base class for UIPanel
    /// All the UI panel logic class should inherit this class
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Element Base")]
    public class UIPanelElement : MonoBehaviour
    {
        #region Public Field

        /// <summary>
        /// The root manager of current UIPanelElement
        /// </summary>
        [BoxGroup("Panel Property")]
        public UIStackManager panelRootManager;

        /// <summary>
        /// The name of current UIPanelElement
        /// </summary>
        [Space]
        [BoxGroup("Panel Property")]
        public string panelName;

        [BoxGroup("UI Stack Event")]
        public UnityEvent pushEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent popEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent pauseEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent resumeEvent;

        #endregion

        private void Awake()
        {
            // By default the panel element should be inactivate
            gameObject.SetActive(false);
        }

        #region UI Stack Callback Methods

        /// <summary>
        /// This method will be called when the UIPanelElement is pushed into the UI Stack
        /// </summary>
        public virtual void OnPush()
        {
            pushEvent?.Invoke();
        }

        /// <summary>
        /// This method will be called when the UIPanelElement is popped out from the UI Stack
        /// </summary>
        public virtual void OnPop()
        {
            popEvent?.Invoke();
        }

        /// <summary>
        /// This method will be called when the UIPanelElement is paused
        /// To be specific, when current UIPanelElement is on the top of the UI Stack,
        /// the UIPanelElement is not paused
        /// When there's a new UIPanelElement pushed into the stack and current is no longer at the top of the stack,
        /// OnPause callback method will be called
        /// </summary>
        public virtual void OnPause()
        {
            pauseEvent?.Invoke();
        }

        /// <summary>
        /// This method will be called when the UIPanelElement is resumed
        /// To be specific, when current UIPanelElement is not on the top of the UI Stack,
        /// the UIPanelElement is paused
        /// When the UIPanelElement on top of current panel is popped out,
        /// and current UIPanelElement is on the top of the stack,
        /// OnResume callback method will be called
        /// </summary>
        public virtual void OnResume()
        {
            resumeEvent?.Invoke();
        }

        #endregion
    }
}