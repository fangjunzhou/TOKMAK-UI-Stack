using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

public class DeployButtonController : UIPanelChild
{
    #region Public Field

    [ValidateInput("IsPanelValid")]
    public UIPanelElement HUDPanel;

    #endregion

    public void OpenHUD()
    {
        Debug.Log("Open HUD.");
        ((UITabManager) rootPanel.panelRootManager).SwitchPanelAsync(HUDPanel);
    }
}
