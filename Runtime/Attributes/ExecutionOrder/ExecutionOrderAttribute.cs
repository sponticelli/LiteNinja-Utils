using System;

namespace com.liteninja.utils
{
    /// <summary>
    /// [ExecutionOrder(<order>)]
    /// The script execution order is set to order
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ExecutionOrderAttribute : Attribute
    {
        public readonly int order;

        public ExecutionOrderAttribute(int order)
        {
            this.order = order;
        }
    }
}