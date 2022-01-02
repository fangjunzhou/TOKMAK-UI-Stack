using System;
using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class SettingsController : UIPanelChild
    {
        #region Public Field

        [BoxGroup("Panel References")]
        [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
        public UIPanelElement settingsPanel;

        /// <summary>
        /// The action to trigger settings panel open.
        /// </summary>
        [BoxGroup("Panel References")]
        public InputAction escAction;
        
        #endregion

        #region Private Field

        #endregion

        private void Awake()
        {
            escAction.performed += EscActionOnPerformed;
        }

        private void OnEnable()
        {
            escAction.Enable();
        }

        private void OnDisable()
        {
            escAction.Disable();
        }

        private void EscActionOnPerformed(InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx.phase);
            //OpenSettingsPanel();
        }

        #region Private Methods

        /// <summary>
        /// Call this method to open the settings panel in the UI Stack Manager
        /// </summary>
        private void OpenSettingsPanel()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
