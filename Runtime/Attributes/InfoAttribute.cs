using UnityEngine;

namespace LiteNinja.Utils.Attributes
{
    public class InfoAttribute : PropertyAttribute
    {
#if UNITY_EDITOR
        public string Message;
        public bool ShowAfterProperty;

        public InfoAttribute(string message, bool showAfterProperty)
        {
            Message = message;
            ShowAfterProperty = showAfterProperty;
        }
#else
        public InfoAttribute(string message, bool messageAfterProperty)
        {
        }
#endif
    }
}