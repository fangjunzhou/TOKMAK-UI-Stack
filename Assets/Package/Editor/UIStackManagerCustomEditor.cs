using System;
using System.Linq;
using FinTOKMAK.UIStackSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace Package.Editor
{
    [CustomEditor(typeof(UIStackManager))]
    public class UIStackManagerCustomEditor : UnityEditor.Editor
    {
        #region Private Field

        private UIStackManager _stackManager;

        private SerializedProperty _uiPanels;

        #endregion

        private void OnEnable()
        {
            _stackManager = (UIStackManager) serializedObject.targetObject;

            _uiPanels = serializedObject.FindProperty("UIPanels");
            
            UpdateUIPanelDictionary();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("UI Panels", EditorStyles.boldLabel);
            
            EditorGUI.BeginChangeCheck();
            {
                serializedObject.Update();
                EditorGUILayout.BeginVertical("Box");
                {
                    EditorGUILayout.PropertyField(_uiPanels);
                }
                EditorGUILayout.EndVertical();
                serializedObject.ApplyModifiedProperties();
            }
            // When the _uiPanels property changed
            if (EditorGUI.EndChangeCheck())
            {
                // DebugDictionary();
                UpdateUIPanelDictionary();
            }
        }

        /// <summary>
        /// Update the panel name in the panel dictionary
        /// </summary>
        private void UpdateUIPanelDictionary()
        {
            foreach (UIPanelElement panelElement in _stackManager.UIPanels.Keys.ToArray())
            {
                if (panelElement != null)
                {
                    _stackManager.UIPanels[panelElement] = panelElement.panelName;
                }
            }
        }

        /// <summary>
        /// The debug method that prints all the keys and values in the dictionary
        /// </summary>
        private void DebugDictionary()
        {
            string keyStr = "[";
            string valueStr = "[";
            foreach (UIPanelElement key in _stackManager.UIPanels.Keys)
            {
                keyStr += key + ", ";
            }

            foreach (string value in _stackManager.UIPanels.Values)
            {
                if (value == null)
                {
                    valueStr += "null, ";
                }
                else
                {
                    valueStr += value + ", ";
                }
            }

            keyStr = keyStr.Remove(keyStr.Length - 2, 2);
            valueStr = valueStr.Remove(valueStr.Length - 2, 2);

            keyStr += "]";
            valueStr += "]";

            Debug.Log(keyStr);
            Debug.Log(valueStr);
        }
    }
}