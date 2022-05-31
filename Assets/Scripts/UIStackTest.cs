using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

public class UIStackTest : MonoBehaviour
{
    #region Public Field

    public UIStackManager _manager;

    public UIPanelElement targetPanel;

    #endregion

    [Button()]
    public void OpenPanelAsync()
    {
        _manager.OpenPanelAsync(targetPanel);
    }
    
    [Button()]
    public void ClosePanelAsync()
    {
        _manager.ClosePanelAsync(targetPanel);
    }
}
