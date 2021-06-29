using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The SerializableDictionary that has int value as keys and UIPanelElements as values
    /// </summary>
    [System.Serializable]
    public class IntUIPanelElementDict : SerializableDictionary<int, UIPanelElement>{}
    
    /// <summary>
    /// This is the Stack Manager for the UI Stack System
    /// This MonoBehaviour should be attached to every root GameObject of UIPanelElements
    /// </summary>
    public class UIStackManager : MonoBehaviour
    {
        #region Public Field
        
        public IntUIPanelElementDict UIPanels;
        
        #endregion
    }
}