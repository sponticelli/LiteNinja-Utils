using UnityEditor;
using UnityEngine;

namespace com.liteninja.utils.editor
{
    [CustomPropertyDrawer(typeof(ConditionAttribute))]
    public class ConditionAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var conditionAttribute = (ConditionAttribute)attribute;
            var enabled = GetConditionAttributeResult(conditionAttribute, property);
            var previouslyEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!conditionAttribute.Hidden || enabled)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            GUI.enabled = previouslyEnabled;
        }

        private bool GetConditionAttributeResult(ConditionAttribute condHAtt, SerializedProperty property)
        {
            var enabled = true;
            var propertyPath = property.propertyPath; 
            var conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionBoolean); 
            var sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

            if (sourcePropertyValue != null)
            {
                enabled = sourcePropertyValue.boolValue;
            }
            else
            {
                Debug.LogWarning("No matching boolean found for ConditionAttribute in object: " + condHAtt.ConditionBoolean);
            }

            return enabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var conditionAttribute = (ConditionAttribute)attribute;
            var enabled = GetConditionAttributeResult(conditionAttribute, property);

            if (!conditionAttribute.Hidden || enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }

            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}