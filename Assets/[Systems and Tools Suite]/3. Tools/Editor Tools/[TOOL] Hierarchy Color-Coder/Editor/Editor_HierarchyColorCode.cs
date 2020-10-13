using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UTS
{
    public class Editor_HierarchyColorCode : MonoBehaviour
    {

        /// <summary>
        /// The Logic that drives the color coding
        /// Depending on the lisence, the colors will change
        /// </summary>
#if UNITY_PRO_LICENSE
        #region Hierarchy Logic Class
#if UNITY_EDITOR
        [InitializeOnLoad]
        public class CustomHierarchyWindow : MonoBehaviour
        {
            private static Vector2 offset = new Vector2(0, 0);
            public static Color inActiveColor = new Color(0.3113208f, 0.02790138f, 0.08047181f);
            public static Color gameObjectFontColor = Color.gray;
            public static Color gameObjectBackgroundColor = new Color(0.2196079f, 0.2196079f, 0.2196079f);
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
                if (isActive)
                {
                    Color fontColor = gameObjectFontColor;
                    Color backgroundColor = gameObjectBackgroundColor;
                    FontStyle styleFont = FontStyle.Normal;
                    var obj = EditorUtility.InstanceIDToObject(instanceID);
                    GameObject gameObj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

                    if (obj != null)
                    {
                        PrefabAssetType prefabType = PrefabUtility.GetPrefabAssetType(obj);

                        if (gameObj.activeInHierarchy == false)
                        {
                            backgroundColor = inActiveColor;
                        }

                        Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                        EditorGUI.DrawRect(selectionRect, backgroundColor);

                        #region Prefix Color Logic
                        if (obj.name[0] == '*')
                        {
                            string name = obj.name.Remove(0, 1);
                            if (prefabType == PrefabAssetType.Regular)
                            {
                                styleFont = FontStyle.Bold;
                                fontColor = prefabColor;
                            }
                            else
                                styleFont = FontStyle.Normal;
                            EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                            {
                                normal = new GUIStyleState() { textColor = Asterix },
                                fontStyle = styleFont
                            });
                        }
                        else if (obj.name[0] == '!')
                        {
                            string name = obj.name.Remove(0, 1);
                            if (prefabType == PrefabAssetType.Regular)
                            {
                                styleFont = FontStyle.Bold;
                                fontColor = prefabColor;
                            }
                            else
                                styleFont = FontStyle.Normal;
                            EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                            {
                                normal = new GUIStyleState() { textColor = Exclamation },
                                fontStyle = styleFont
                            });
                        }
                        else if (obj.name[0] == '~')
                        {
                            string name = obj.name.Remove(0, 1);

                            if (prefabType == PrefabAssetType.Regular)
                            {
                                styleFont = FontStyle.Bold;
                                fontColor = prefabColor;
                            }
                            else
                                styleFont = FontStyle.Normal;
                            EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                            {

                                normal = new GUIStyleState() { textColor = Tilde },
                                fontStyle = FontStyle.Normal
                            });
                        }
                        #endregion Prefix Color Logic


                        if (obj.name[0] != '!' && obj.name[0] != '~' && obj.name[0] != '*')
                        {
                            if (prefabType == PrefabAssetType.Regular)
                            {
                                styleFont = FontStyle.Bold;
                                fontColor = prefabColor;
                            }
                            else
                                styleFont = FontStyle.Normal;

                            EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                            {
                                normal = new GUIStyleState() { textColor = fontColor },
                                fontStyle = styleFont
                            });
                        }
                    }
                }
            }
        }
#endif
        #endregion
#else
        #region Hierarchy Logic Class
#if UNITY_EDITOR
    [InitializeOnLoad]
    public class CustomHierarchyWindow : MonoBehaviour
    {
        private static Vector2 offset = new Vector2(0, 0);
        public static Color inActiveColor = new Color(0.3113208f, 0.02790138f, 0.08047181f);
        public static Color gameObjectFontColor = Color.black;
        public static Color gameObjectBackgroundColor = new Color(0.7607844f, 0.7607844f, 0.7607844f);
        public static Color prefabColor = new Color(0, 0.1124015f, 1);
        public static Color Asterix = new Color(0, 0.5f, 0);
        public static Color Exclamation = new Color(1f, 1f, 0);
        public static Color Tilde = new Color(1f, 0, 0);


        static CustomHierarchyWindow()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }
        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            Color fontColor = gameObjectFontColor;
            Color backgroundColor = gameObjectBackgroundColor;
            FontStyle styleFont = FontStyle.Normal;
            var obj = EditorUtility.InstanceIDToObject(instanceID);
            GameObject gameObj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj != null)
            {
                PrefabAssetType prefabType = PrefabUtility.GetPrefabAssetType(obj);

                if (gameObj.activeInHierarchy == false)
                {
                    backgroundColor = inActiveColor;
                }

                Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                EditorGUI.DrawRect(selectionRect, backgroundColor);

        #region Prefix Color Logic
                if (obj.name[0] == '*')
                {
                    string name = obj.name.Remove(0, 1);
                    if (prefabType == PrefabAssetType.Regular)
                    {
                        styleFont = FontStyle.Bold;
                        fontColor = prefabColor;
                    }
                    else
                        styleFont = FontStyle.Normal;
                    EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = Asterix },
                        fontStyle = styleFont
                    });
                }
                else if (obj.name[0] == '!')
                {
                    string name = obj.name.Remove(0, 1);
                    if (prefabType == PrefabAssetType.Regular)
                    {
                        styleFont = FontStyle.Bold;
                        fontColor = prefabColor;
                    }
                    else
                        styleFont = FontStyle.Normal;
                    EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = Exclamation },
                        fontStyle = styleFont
                    });
                }
                else if (obj.name[0] == '~')
                {
                    string name = obj.name.Remove(0, 1);

                    if (prefabType == PrefabAssetType.Regular)
                    {
                        styleFont = FontStyle.Bold;
                        fontColor = prefabColor;
                    }
                    else
                        styleFont = FontStyle.Normal;
                    EditorGUI.LabelField(offsetRect, name, new GUIStyle()
                    {

                        normal = new GUIStyleState() { textColor = Tilde },
                        fontStyle = FontStyle.Normal
                    });
                }
        #endregion Prefix Color Logic


                if (obj.name[0] != '!' && obj.name[0] != '~' && obj.name[0] != '*')
                {
                    if (prefabType == PrefabAssetType.Regular)
                    {
                        styleFont = FontStyle.Bold;
                        fontColor = prefabColor;
                    }
                    else
                        styleFont = FontStyle.Normal;

                    EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = fontColor },
                        fontStyle = styleFont
                    });
                }
            }
        }
    }
#endif
        #endregion
#endif

        /// <summary>
        /// Editor Class that handles the actual Editor Window UI
        /// </summary>
        #region Hierarchy Editor Class
#if UNITY_EDITOR
        public class HierarchyEditorWindow : EditorWindow
        {
            [MenuItem("UTS/Utility/Hierarchy Color Coder")]
            public static void ShowWindow()
            {
                GetWindow<HierarchyEditorWindow>("HierarchyEditor");
            }
            private void OnGUI()
            {
                CustomHierarchyWindow.gameObjectFontColor = EditorGUILayout.ColorField("Original Font Color", CustomHierarchyWindow.gameObjectFontColor);
                CustomHierarchyWindow.gameObjectBackgroundColor = EditorGUILayout.ColorField("Background Color", CustomHierarchyWindow.gameObjectBackgroundColor);
                CustomHierarchyWindow.inActiveColor = EditorGUILayout.ColorField("Inactive Color", CustomHierarchyWindow.inActiveColor);
                CustomHierarchyWindow.Asterix = EditorGUILayout.ColorField(" * Color", CustomHierarchyWindow.Asterix);
                CustomHierarchyWindow.Exclamation = EditorGUILayout.ColorField(" ! Color", CustomHierarchyWindow.Exclamation);
                CustomHierarchyWindow.Tilde = EditorGUILayout.ColorField(" ~ Color", CustomHierarchyWindow.Tilde);
                CustomHierarchyWindow.isActive = EditorGUILayout.Toggle("Is Active?", CustomHierarchyWindow.isActive);
            }
        }
#endif
        #endregion

    }
}