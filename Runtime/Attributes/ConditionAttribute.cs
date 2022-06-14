using System;
using UnityEngine;

namespace com.liteninja.utils
{
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct,
        Inherited = true)]
    public class ConditionAttribute : PropertyAttribute
    {
        public string ConditionBoolean = "";
        public bool Hidden = false;

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