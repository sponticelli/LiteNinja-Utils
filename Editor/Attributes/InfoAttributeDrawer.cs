using UnityEditor;
using UnityEngine;

namespace com.liteninja.utils.editor
{
    [CustomPropertyDrawer(typeof(InfoAttribute))]
    public class InfoAttributeDrawer : PropertyDrawer
    {
        private const int spaceBeforeTheTextBox = 5;
        private const int spaceAfterTheTextBox = 10;
        private const int iconWidth = 55;

        private InfoAttribute informationAttribute => ((InfoAttribute) attribute);

        public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
        {
            EditorStyles.helpBox.richText = true;

            if (!informationAttribute.ShowAfterProperty)
            {
                rect.height = DetermineTextboxHeight(informationAttribute.Message);
                EditorGUI.HelpBox(rect, informationAttribute.Message, MessageType.Info);

                rect.y += rect.height + spaceBeforeTheTextBox;
                EditorGUI.PropertyField(rect, prop, label, true);
            }
            else
            {
                // we position the property first, then the message
                rect.height = GetPropertyHeight(prop, label);
                EditorGUI.PropertyField(rect, prop, label, true);

                rect.height = DetermineTextboxHeight(informationAttribute.Message);
                // we add the complete property height (property + helpbox, as overridden in this very script), and substract both to get just the property
                rect.y += GetPropertyHeight(prop, label) - DetermineTextboxHeight(informationAttribute.Message) -
                          spaceAfterTheTextBox;
                EditorGUI.HelpBox(rect, informationAttribute.Message, MessageType.Info);
            }
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            return EditorGUI.GetPropertyHeight(property) + DetermineTextboxHeight(informationAttribute.Message) +
                   spaceAfterTheTextBox + spaceBeforeTheTextBox;
        }


        protected virtual float DetermineTextboxHeight(string message)
        {
            var style = new GUIStyle(EditorStyles.helpBox)
            {
                richText = true
            };

            var newHeight = style.CalcHeight(new GUIContent(message), EditorGUIUtility.currentViewWidth - iconWidth);
            return newHeight;
        }
    }
}