using System;
using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillController : UIPanelChild
{
    #region Public Field

    [ValidateInput("IsPanelValid")]
    public UIPanelElement respawnPanel;

    public InputAction killAction;

    #endregion

    private void Awake()
    {
        killAction.Enable();
        killAction.started += context =>
        {
            Debug.Log("Kill");
            ((UITabManager) rootPanel.panelRootManager).SwitchPanelAsync(respawnPanel);
        };
    }
}
