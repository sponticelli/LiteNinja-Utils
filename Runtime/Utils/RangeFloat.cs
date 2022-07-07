using System;
using UnityEngine;

namespace LiteNinja.Utils
{
    /// <summary>
    /// A class that represent a range of float (min and max, both included).
    /// </summary>
    [Serializable]
    public class RangeFloat
    {
        [SerializeField]
        private float _min;
        [SerializeField]
        private float _max;

        public float Min => _min;
        public float Max => _max;

        public RangeFloat(float min, float max)
        {
            if (min > max)
            {
                (min, max) = (max, min);
            }
            _min = min;
            _max = max;
        }

        public float GetValue(float t)
        {
            return Mathf.Lerp(Min, Max, t);
        }

        public bool Contains(float value)
        {
            return value >= Min && value <= Max;
        }
    }
}