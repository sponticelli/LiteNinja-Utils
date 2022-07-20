using System;
using UnityEngine;

namespace LiteNinja.Utils.Attributes
{
    
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
    public class ConditionAttribute : PropertyAttribute
    {
        public string ConditionBoolean = "";
        public bool Hidden;

        public ConditionAttribute(string conditionBoolean)
        {
            ConditionBoolean = conditionBoolean;
            Hidden = false;
        }

        public ConditionAttribute(string conditionBoolean, bool hideInInspector)
        {
            ConditionBoolean = conditionBoolean;
            Hidden = hideInInspector;
        }
    }
    
    
}