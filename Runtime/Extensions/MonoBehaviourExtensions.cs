using System;
using System.Collections;
using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void DelayInvoking(this MonoBehaviour self, float delay, Action action)
        {
            self.StartCoroutine(DelayedCoroutine());

            IEnumerator DelayedCoroutine()
            {
                yield return new WaitForSeconds(delay);
                action();
            }
        }
    }
}