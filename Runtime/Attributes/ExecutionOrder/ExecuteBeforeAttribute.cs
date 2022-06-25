using System;

namespace LiteNinja.Utils.Attributes
{
    /// <summary>
    /// ExecuteBefore(<type>[, orderDecrease = <decrease>])]
    /// The script execution order is set to a value lower than the one of the script type,
    /// ensuring that your script will be executed before this script.
    ///
    /// By default, the script execution order is decreased by 10 but this can be changed
    /// by adding the orderDecrease argument.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ExecuteBeforeAttribute : Attribute
    {
        public readonly Type targetType;
        public readonly int orderDecrease;

        public ExecuteBeforeAttribute(Type targetType, int orderDecrease = 10)
        {
            this.targetType = targetType;
            this.orderDecrease = orderDecrease;
        }
    }
}