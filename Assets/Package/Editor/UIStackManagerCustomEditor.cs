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

        #region Serializaed Property

        private SerializedProperty _uiPanels;
        private SerializedProperty _initializationPanel;

        #endregion

        private bool _containInitializationPanel;

        #endregion

        private void OnEnable()
        {
            _stackManager = (UIStackManager) serializedObject.targetObject;

            _uiPanels = serializedObject.FindProperty("UIPanels");
            _initializationPanel = serializedObject.FindProperty("initializationPanel");
            
            UpdateUIPanelDictionary();
            CheckInitializationPanel();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            #region UI Panels

            EditorGUILayout.LabelField("UI Panels", EditorStyles.boldLabel);
            
            EditorGUI.BeginChangeCheck();
            {
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

            #endregion

            #region Initialization Panel

            EditorGUILayout.LabelField("Initialization Panel", EditorStyles.boldLabel);

            _stackManager.useInitializePanel =
                EditorGUILayout.Toggle("Has Initialization Panel", _stackManager.useInitializePanel);
            if (_stackManager.useInitializePanel)
            {
                EditorGUI.BeginChangeCheck();
                {
                    EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.PropertyField(_initializationPanel);
                        
                        if (!_containInitializationPanel)
                        {
                            EditorGUILayout.HelpBox(
                                "Your initialization panel is not in the UIPanels! Add to your UIPanels first!",
                                MessageType.Error);
                        }
                    }
                    EditorGUILayout.EndVertical();
                    
                    serializedObject.ApplyModifiedProperties();
                }
                if (EditorGUI.EndChangeCheck())
                {
                    // check if the initialization panel in the
                    CheckInitializationPanel();
                }
            }

            #endregion
            
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Check if the initialization panel is in the UIPanels dictionary
        /// </summary>
        private void CheckInitializationPanel()
        {
            if (_stackManager.initializationPanel == null ||
                !_stackManager.UIPanels.ContainsKey(_stackManager.initializationPanel))
            {
                _containInitializationPanel = false;
            }
            else
            {
                _containInitializationPanel = true;
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
                    // Set the panel name in the dictionary
                    _stackManager.UIPanels[panelElement] = panelElement.panelName;
                    
                    // Set the root manager in panel elements
                    panelElement.panelRootManager = _stackManager;
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