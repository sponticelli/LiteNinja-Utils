using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace com.liteninja.utils
{
    public static class EventTriggerExtensions
    {
        public static void AddListener(this EventTrigger self, EventTriggerType type,
            UnityAction<BaseEventData> callback)
        {
            var triggers = self.triggers;
            var index = triggers.FindIndex(entry => entry.eventID == type);
            if (index < 0)
            {
                var entry = new EventTrigger.Entry
                {
                    eventID = type
                };
                entry.callback.AddListener(callback);
                triggers.Add(entry);
            }
            else
            {
                triggers[index].callback.AddListener(callback);
            }
        }

        public static void RemoveListener(this EventTrigger self, EventTriggerType type,
            UnityAction<BaseEventData> callback)
        {
            var triggers = self.triggers;
            var index = triggers.FindIndex(entry => entry.eventID == type);
            if (index >= 0)
            {
                triggers[index].callback.RemoveListener(callback);
            }
        }
    }
}