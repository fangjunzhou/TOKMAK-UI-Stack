using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The SerializableDictionary that has int value as keys and UIPanelElements as values
    /// </summary>
    [System.Serializable]
    public class UIPanelElementStringDict : SerializableDictionary<UIPanelElement, string>{}
    
    /// <summary>
    /// This is the Stack Manager for the UI Stack System
    /// This MonoBehaviour should be attached to every root GameObject of UIPanelElements
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Manager")]
    public class UIStackManager : MonoBehaviour
    {
        #region Public Field
        
        /// <summary>
        /// All the available UIPanelElements
        /// </summary>
        [Tooltip("This field list all the UIPanelElement children. " +
                 "The key is panel name and value is UIPanelElement MonoBehaviour.")]
        public UIPanelElementStringDict UIPanels;

        /// <summary>
        /// if the UIStackManager has an initialization panel
        /// </summary>
        public bool useInitializePanel = false;

        /// <summary>
        /// The panel that will be pushed into the stack when Start
        /// </summary>
        public UIPanelElement initializationPanel;
        
        #endregion

        #region Private Field

        /// <summary>
        /// The internal UI Stack
        /// </summary>
        private Stack<UIPanelElement> _UIStack = new Stack<UIPanelElement>();

        #endregion

        private void Start()
        {
            if (useInitializePanel)
            {
                Push(initializationPanel);
            }
        }

        #region UIStack Operation

        /// <summary>
        /// Peek at the UIStack to check the top of UI Stack
        /// </summary>
        /// <returns></returns>
        public UIPanelElement Peek()
        {
            return _UIStack.Peek();
        }

        /// <summary>
        /// Push a UIPanelElement into the UIStack
        /// </summary>
        /// <param name="panel">the panel that need to be pushed into the stack</param>
        public void Push(UIPanelElement panel)
        {
            // Check if the panel is in the UIPanels dictionary
            if (!UIPanels.ContainsKey(panel))
            {
                throw new ArgumentException("The panel is not in the UIPanels dictionary." +
                                            "Make sure you are using the panel in the dictionary.");
            }
            
            // pause the top of the UI Stack
            if (_UIStack.Count != 0)
            {
                _UIStack.Peek().OnPause();
            }
            // push the panel into the stack
            _UIStack.Push(panel);
            panel.OnPush();
        }

        /// <summary>
        /// Pop the panel at the top of the stack
        /// </summary>
        /// <returns>the panel popped out from the stack</returns>
        public UIPanelElement Pop()
        {
            // Check if the UIStack is empty
            if (_UIStack.Count == 0)
            {
                return null;
            }

            UIPanelElement popPanel = _UIStack.Pop();
            popPanel.OnPop();
            
            // resume the current stack
            UIPanelElement resumePanel = _UIStack.Peek();
            if (resumePanel != null)
                resumePanel.OnResume();

            return popPanel;
        }

        #endregion
    }
}