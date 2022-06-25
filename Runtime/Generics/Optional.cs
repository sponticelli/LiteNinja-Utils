using System;
using UnityEngine;

namespace LiteNinja.Utils
{
    [Serializable]
    public struct Optional<T>
    {
        [SerializeField] private bool _enabled;
        public bool Enabled => _enabled;

        [SerializeField] private T _value;
        public T Value => _value;

        public Optional(T initValue, bool enabled = false)
        {
            _enabled = enabled;
            _value = initValue;
        }
    }
}