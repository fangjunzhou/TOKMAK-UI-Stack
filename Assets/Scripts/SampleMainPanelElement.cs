using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class SampleMainPanelElement : UIPanelElement
    {
        #region Public Field

        #region Panel References

        [BoxGroup("Panel References")]
        [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
        public UIPanelElement settingsPanel;

        #endregion

        #endregion

        #region Naughty Attribute Methods

        /// <summary>
        /// This method is used to check if the panel is a valid panel in current panelRootManager
        /// </summary>
        /// <param name="panelElement">the panel passed in to check</param>
        /// <returns>if the panel is valid</returns>
        private bool IsPanelValid(UIPanelElement panelElement)
        {
            if (panelElement == null || !panelRootManager.UIPanels.ContainsKey(panelElement))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Call this method to open the settings panel in the UI Stack Manager
        /// </summary>
        public void OpenSettingsPanel()
        {
            panelRootManager.Push(settingsPanel);
        }

        #endregion
        
        #region UIPanelElement Callback
        
        public override void OnPush()
        {
            base.OnPush();
            
            // Activate self
            gameObject.SetActive(true);
        }

        public override void OnPop()
        {
            base.OnPop();
            
            // Deactivate self
            gameObject.SetActive(false);
        }

        public override void OnPause()
        {
            base.OnPause();
            
            // Deactivate self
            gameObject.SetActive(false);
        }

        public override void OnResume()
        {
            base.OnResume();
            
            // Activate self
            gameObject.SetActive(true);
        }

        #endregion
    }
}