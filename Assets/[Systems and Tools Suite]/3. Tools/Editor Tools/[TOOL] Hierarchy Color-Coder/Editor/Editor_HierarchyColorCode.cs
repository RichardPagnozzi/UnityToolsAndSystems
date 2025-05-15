using UnityEngine;
using UnityEditor;

namespace UTS
{
    public class Editor_HierarchyColorCode : MonoBehaviour
    {
#if UNITY_EDITOR
        #region Hierarchy Logic Class
        [InitializeOnLoad]
        public static class CustomHierarchyWindow
        {
            private static readonly Vector2 Offset = Vector2.zero;

            public static Color inActiveColor = new Color(0.31f, 0.03f, 0.08f);
            public static Color gameObjectFontColor = Color.gray;
            public static Color gameObjectBackgroundColor = new Color(0.22f, 0.22f, 0.22f);
            public static Color prefabColor = Color.white;

            public static Color Asterix = Color.green;
            public static Color Exclamation = Color.yellow;
            public static Color Tilde = Color.red;

            public static bool isActive = false;

            static CustomHierarchyWindow()
            {
                EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
            }

            private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
            {
                if (!isActive) return;

                Object obj = EditorUtility.InstanceIDToObject(instanceID);
                GameObject gameObj = obj as GameObject;
                if (obj == null || gameObj == null) return;

                Color fontColor = gameObjectFontColor;
                Color backgroundColor = gameObjectBackgroundColor;
                FontStyle styleFont = FontStyle.Normal;
                PrefabAssetType prefabType = PrefabUtility.GetPrefabAssetType(obj);

                if (!gameObj.activeInHierarchy)
                {
                    backgroundColor = inActiveColor;
                }

                Rect offsetRect = new Rect(selectionRect.position + Offset, selectionRect.size);
                EditorGUI.DrawRect(selectionRect, backgroundColor);

                string name = obj.name;
                if (string.IsNullOrEmpty(name)) return;

                char prefix = name[0];
                string displayName = name;
                GUIStyle style = new GUIStyle { fontStyle = styleFont };

                // Set color based on prefix
                if (prefix == '*' || prefix == '!' || prefix == '~')
                {
                    displayName = name.Substring(1);
                    switch (prefix)
                    {
                        case '*':
                            style.normal.textColor = Asterix;
                            break;
                        case '!':
                            style.normal.textColor = Exclamation;
                            break;
                        case '~':
                            style.normal.textColor = Tilde;
                            break;
                    }
                }
                else
                {
                    style.normal.textColor = fontColor;
                }

                // Apply prefab styling
                if (prefabType == PrefabAssetType.Regular)
                {
                    style.fontStyle = FontStyle.Bold;
                    style.normal.textColor = prefabColor;
                }
                bool isSelected = System.Array.IndexOf(Selection.instanceIDs, instanceID) >= 0;
                if (isSelected)
                {
                    style.normal.textColor = Color.cyan;
                }

                EditorGUI.LabelField(offsetRect, displayName, style);
            }
        }
        #endregion

        #region Hierarchy Editor Class
        public class HierarchyEditorWindow : EditorWindow
        {
            [MenuItem("UTS/Utility/Hierarchy Color Coder")]
            public static void ShowWindow()
            {
                GetWindow<HierarchyEditorWindow>("HierarchyEditor");
            }

            private void OnGUI()
            {
                CustomHierarchyWindow.gameObjectFontColor = EditorGUILayout.ColorField("Font Color", CustomHierarchyWindow.gameObjectFontColor);
                CustomHierarchyWindow.gameObjectBackgroundColor = EditorGUILayout.ColorField("Background Color", CustomHierarchyWindow.gameObjectBackgroundColor);
                CustomHierarchyWindow.inActiveColor = EditorGUILayout.ColorField("Inactive BG Color", CustomHierarchyWindow.inActiveColor);

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Prefix Color Overrides", EditorStyles.boldLabel);
                CustomHierarchyWindow.Asterix = EditorGUILayout.ColorField("* (Asterix)", CustomHierarchyWindow.Asterix);
                CustomHierarchyWindow.Exclamation = EditorGUILayout.ColorField("! (Exclamation)", CustomHierarchyWindow.Exclamation);
                CustomHierarchyWindow.Tilde = EditorGUILayout.ColorField("~ (Tilde)", CustomHierarchyWindow.Tilde);

                EditorGUILayout.Space();
                CustomHierarchyWindow.isActive = EditorGUILayout.Toggle("Enable Color Coding", CustomHierarchyWindow.isActive);
            }
        }
        #endregion
#endif
    }
}

