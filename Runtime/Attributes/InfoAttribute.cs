using UnityEngine;

namespace com.liteninja.utils
{
    public class InfoAttribute : PropertyAttribute
    {
#if UNITY_EDITOR
        public string Message;
        public bool ShowAfterProperty;
        
        public InfoAttribute(string message, bool showAfterProperty)
        {
            this.Message = message;
            this.ShowAfterProperty = showAfterProperty;
        }
#else
        public InfoAttribute(string message, bool messageAfterProperty)
        {
        }
#endif
    }
}