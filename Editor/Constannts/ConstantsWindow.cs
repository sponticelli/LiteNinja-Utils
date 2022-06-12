using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace com.liteninja.utils.editor
{
    public class ConstantsWindow : EditorWindow
    {
        private readonly List<Object> _folderObjects = new List<Object>();
        
        [MenuItem("LiteNinja/Consts/Constants Table")]
        public static void ShowWindow()
        {
            var window = EditorWindow.GetWindow(typeof(ConstantsWindow));
            var titleContent = window.titleContent;
            titleContent.text = "Constants Table";
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(
                "Folders references used to generate Prefabs Constants, the folders dragged here may contains prefabs",
                EditorStyles.wordWrappedLabel);

            EditorGUILayout.Space();
            DropAreaGui();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            for (var i = 0; i < _folderObjects.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.ObjectField((i + 1).ToString(), _folderObjects[i], typeof(DefaultAsset), false);
                EditorGUI.EndDisabledGroup();

                if (GUILayout.Button("-", GUILayout.Width(20)))
                {
                    _folderObjects.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DropAreaGui()
        {
            var evt = Event.current;
            var dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));

            var boxStyle = new GUIStyle(GUI.skin.box)
            {
                normal =
                {
                    textColor = Color.white
                }
            };
            GUI.Box(dropArea, "Drag and drop folders here", boxStyle);

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(evt.mousePosition))
                        return;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (var draggedObject in DragAndDrop.objectReferences)
                        {
                            // Do On Drag Stuff here
                            _folderObjects.Add(draggedObject);
                        }

                        evt.Use();
                    }

                    break;
            }
        }
    }
}