using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteNinja.Utils
{
    /// <summary>
    /// It allows to easily map a list of objects to a list of float.
    /// It's possible to retrieve the value of an object by using a float index.
    /// It interpolates between the values of the objects, if the index is not one of the objects' indexes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class RangeMap<T>
    {
        private SortedList<float, T> _values;
        private Func<T, T, float, T> _interpolation;
        
        public RangeMap(Func<T, T, float, T> interpolation)
        {
            _values = new SortedList<float, T>();
            _interpolation = interpolation;
        }

        

        public void Add(float key, T value)
        {
            _values.Add(key, value);
        }
        
        public void Remove(float key)
        {
            _values.Remove(key);
        }
        
        public void Clear()
        {
            _values.Clear();
        }
        
        public T GetValue(float key)
        {
            if (_values.Count == 0)
                return default(T);
            
            if (key <= _values.Keys[0])
                return _values.Values[0];
            
            if (key >= _values.Keys[_values.Count - 1])
                return _values.Values[_values.Count - 1];
            
            if (_values.ContainsKey(key)) return _values[key];
            
            var upperKey = _values.Keys.FirstOrDefault(k => k > key);
            var upperValue = _values[upperKey];
            

            var lowerKey = _values.Keys.LastOrDefault(k => k < key);   
            var lowerValue = _values[lowerKey];
            
            var t = (key - lowerKey) / (upperKey - lowerKey);
            
            return _interpolation(lowerValue, upperValue, t);
        }
    }
}