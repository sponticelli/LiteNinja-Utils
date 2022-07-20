using LiteNinja.Utils.Attributes;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.Utils.Editor
{
    
    [CustomPropertyDrawer(typeof(InfoAttribute))]
    public class InfoAttributeDrawer : PropertyDrawer
    {
        private const int SpaceBeforeTheTextBox = 5;
        private const int SpaceAfterTheTextBox = 10;
        private const int IconWidth = 55;

        private InfoAttribute informationAttribute => ((InfoAttribute) attribute);

        public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
        {
            EditorStyles.helpBox.richText = true;

            if (!informationAttribute.ShowAfterProperty)
            {
                rect.height = DetermineTextboxHeight(informationAttribute.Message);
                EditorGUI.HelpBox(rect, informationAttribute.Message, MessageType.Info);

                rect.y += rect.height + SpaceBeforeTheTextBox;
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
                          SpaceAfterTheTextBox;
                EditorGUI.HelpBox(rect, informationAttribute.Message, MessageType.Info);
            }
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            return EditorGUI.GetPropertyHeight(property) + DetermineTextboxHeight(informationAttribute.Message) +
                   SpaceAfterTheTextBox + SpaceBeforeTheTextBox;
        }


        protected virtual float DetermineTextboxHeight(string message)
        {
            var style = new GUIStyle(EditorStyles.helpBox)
            {
                richText = true
            };

            var newHeight = style.CalcHeight(new GUIContent(message), EditorGUIUtility.currentViewWidth - IconWidth);
            return newHeight;
        }
    }
    
}