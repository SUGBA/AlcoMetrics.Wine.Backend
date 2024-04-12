using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Actions.Abstractions.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Калькулятор единиц измерения
    /// Фасад над фабрикой и калькуляторами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseUnitsCalculator<T> where T : Enum
    {
        /// <summary>
        /// Перевести value из fromType в toType
        /// </summary>
        /// <param name="fromType"> Искомая единица измерения </param>
        /// <param name="toType"> Конечная единица измерения </param>
        /// <param name="value"> Значение </param>
        /// <returns></returns>
        public double Calculate(T fromType, T toType, double value);
    }
}
