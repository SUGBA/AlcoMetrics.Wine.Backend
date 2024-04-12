using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Второстепенные рассчеты после смешивания
    /// </summary>
    public class MixingCalculator
    {
        /// <summary>
        /// Рассчитать объем конечного вещества правилом креста
        /// </summary>
        /// <param name="firstSubstancePercent"> Содержание вещества в первой жидкости в % </param>
        /// <param name="secondSubstancePercent"> Содержание вещества во второй жидкости в %  </param>
        /// <param name="firstSubstanceVolume"> Объем первой жидкости в Л </param>
        /// <param name="desiredPercent"> Желаемое содержание в конечной жидкости в % </param>
        /// <returns></returns>
        public static double GetVolume(double firstSubstancePercent, double secondSubstancePercent,
            double firstSubstanceVolume, double desiredPercent)
        {
            return firstSubstanceVolume * (firstSubstancePercent - desiredPercent) / (desiredPercent - secondSubstancePercent);
        }

        /// <summary>
        /// Получить конечное содержание вещества после смешивания
        /// Отрицательный результат, если невозможно достичь заданных показателей
        /// </summary>
        /// <param name="c1"> Содержание вещества в первой смеси </param>
        /// <param name="v1"> Объм первого вещества </param>
        /// <param name="c2"> Содержание вещества во второй смеси </param>
        /// <param name="v2"> Объм второго вещества </param>
        /// <returns></returns>
        public static double GetContent(double c1, double v1, double c2, double v2)
        {
            return (c1 * v1 + c2 * v2) / (v1 + v2);
        }
    }
}
