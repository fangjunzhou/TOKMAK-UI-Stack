using FinTOKMAK.UIStackSystem.Runtime;
using UnityEngine;

namespace DefaultNamespace
{
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Element/Settings Panel")]
    public class SampleSettingsPanelElement : UIPanelElement
    {
        #region Public Methods

        /// <summary>
        /// Call this method to close the settings panel.
        /// The method will check if settings panel is on the top of the stack.
        /// Otherwise, it will do nothing
        /// </summary>
        public void CloseSettingsPanelIfOnTop()
        {
            if (panelRootManager.Peek() == this)
            {
                panelRootManager.Pop();
            }
        }

        #endregion
        
        #region UIPanelElement Callback
        
        public override void OnPush()
        {
            // Activate self
            gameObject.SetActive(true);
            
            base.OnPush();
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
            // Activate self
            gameObject.SetActive(true);
            
            base.OnResume();
        }

        #endregion
    }
}