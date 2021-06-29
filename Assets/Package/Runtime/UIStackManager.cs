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
    public class UIStackManager : MonoBehaviour
    {
        #region Public Field
        
        [Tooltip("This field list all the UIPanelElement children. " +
                 "The key is panel name and value is UIPanelElement MonoBehaviour.")]
        public UIPanelElementStringDict UIPanels;
        
        #endregion
    }
}