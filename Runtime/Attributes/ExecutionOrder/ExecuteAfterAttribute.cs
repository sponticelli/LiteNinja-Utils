using System;

namespace LiteNinja.Utils.Attributes
{
    /// <summary>
    /// [ExecuteAfter(<type>[, orderIncrease = <increase>])]
    /// The script execution order is set to a value greater than the one of the script type,
    /// ensuring that your script will be executed after this script.
    ///
    /// By default, the script execution order is increased by 10 but this can be changed
    /// by adding the orderIncrease argument.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ExecuteAfterAttribute : Attribute
    {
        public readonly Type targetType;
        public readonly int orderIncrease;

        public ExecuteAfterAttribute(Type targetType, int orderIncrease = 10)
        {
            this.targetType = targetType;
            this.orderIncrease = orderIncrease;
        }
    }
}