using System;
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
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("UI Panels", EditorStyles.boldLabel);

            EditorGUILayout.BeginVertical("Box");
            {
                EditorGUILayout.PropertyField(_uiPanels);
            }
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}