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
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Panel Element")]
    public class UIPanelElement : MonoBehaviour, IUIStackEventInvoker
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
        
        [BoxGroup("UI Finish Listeners")]
        [ReorderableList]
        public List<UIStackEventListener> listeners;

        [BoxGroup("UI Stack Event")]
        public UnityEvent pushEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent popEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishPopEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent pauseEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishPauseEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent resumeEvent;
        
        public Action finishAction { get; set; }
        #endregion

        private void Awake()
        {
            // By default the panel element should be inactivate
            gameObject.SetActive(false);
            
            // initialize listeners
            foreach (UIStackEventListener listener in listeners)
            {
                ((IUIStackEventInvoker) listener.eventInvoker).finishAction += () =>
                {
                    // when finish action is triggered
                    
                    // set the state to finished
                    listener.state = true;
                    // check all the finish state and trigger the FinishAction in the panel
                    FinishCheck();
                };
            }
        }
        
        private void OnEnable()
        {
            foreach (UIStackEventListener listener in listeners)
            {
                listener.state = false;
            }
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
            
            // Check the finish event
            FinishCheck();
        }

        /// <summary>
        /// This method will be called when the UIPanelElement finish the pop state
        /// and new panel will be resumed
        /// </summary>
        public virtual void OnFinishPop()
        {
            finishPopEvent?.Invoke();
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
            
            // Check the finish event
            FinishCheck();
        }

        /// <summary>
        /// This method will be called when the UIPanelElement finish the pause state
        /// and new panel will be pushed into the stack
        /// </summary>
        public virtual void OnFinishPause()
        {
            finishPauseEvent?.Invoke();
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

        #region Public Methods

        /// <summary>
        /// Check all the listeners' state and trigger the finish event if all the listeners are finished
        /// </summary>
        public void FinishCheck()
        {
            // if all the UIStackEventListeners are finished, call the finish pause event

            foreach (UIStackEventListener listener in listeners)
            {
                if (!listener.state)
                    return;
            }
            
            finishAction?.Invoke();
        }

        [Button("UI Active Setup")]
        public void UIActiveSetup()
        {
            UnityAction methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectActive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (pushEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectInactive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (finishPopEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectInactive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (finishPauseEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectActive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (resumeEvent, methodDelegate);
#endif
        }

        public void SetGameObjectActive()
        {
            gameObject.SetActive(true);
        }
        
        public void SetGameObjectInactive()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}