using MathNet.Numerics.OdeSolvers;
using MathNet.Numerics.LinearAlgebra;
using Core.Actions.Abstractions.TimeLineCalculator;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineTimeLineCalculator
{
    /// <summary>
    /// Калькулятор Тайм-Лайнов для виноделия
    /// </summary>
    public class WIneTimeLineCalculator : BaseTimeLineCalculator<WineIndicator>
    {
        #region Consts
        private const double U1 = 0.08;
        private const double U2 = 0.1858;
        private const double B1 = 0.3371;
        private const double B2 = 0.0285;
        private const double KE1 = 0.2616;
        private const double KE2 = 38.90;
        private const double KN = 0.1156;
        private const double KS = 4.3;
        private const double K1 = 0.0536;
        private const double K2 = 1.5;
        private const double DEFAUL_YEAST_VALUE = 0.25;
        private const double DEFAUL_NITROGEN_VALUE = 0.25;
        private const double DEFAUL_ETHANOL_VALUE = 0.25;
        private const double DEFAUL_SUGAR_VALUE = 0.25;
        private const double DEFAUL_WORT_VALUE = 0;

        #endregion

        #region System of differential equations
        /// <summary>
        /// Система дифференциальных уравнений, описывающая процесс брожения вина
        /// </summary>
        /// <returns></returns>
        private Func<double, Vector<double>, Vector<double>> DerivativeMaker()
        {
            return (t, Z) =>
            {
                double[] A = Z.ToArray();
                double x = A[0];
                double n = A[1];
                double e = A[2];
                double s = A[3];

                return Vector<double>.Build.Dense(new[] {
                    (U1*t + U2)*(n/(KN+n))*x,
                    -K1* (U1*t + U2)*(n/(KN+n))*x,
                    (B1*t+B2)*(s/(KS+s))*((-KE1*t+KE2)/(-KE1*t+KE2+e))*x,
                    -K2*(B1*t+B2)*(s/(KS+s))*((-KE1*t+KE2)/(-KE1*t+KE2+e))*x
                });
            };
        }
        #endregion

        public override Vector<double>[] CalculateTimeLine(WineIndicator indicator, int startTime, int endTime)
        {
            var xValue = indicator.YeastValue == default(double) ? DEFAUL_YEAST_VALUE : indicator.YeastValue;
            var nValue = indicator.NitrogenValue == default(double) ? DEFAUL_NITROGEN_VALUE : indicator.NitrogenValue;
            var eValue = indicator.EthanolValue == default(double) ? DEFAUL_ETHANOL_VALUE : indicator.EthanolValue;
            var sValue = indicator.SugarValue == default(double) ? DEFAUL_SUGAR_VALUE : indicator.SugarValue;
            var wValue = indicator.WortValue == default(double) ? DEFAUL_WORT_VALUE : indicator.WortValue;
            var result = GetTimeLine(xValue, nValue, eValue, sValue, wValue, startTime, endTime);
            return result;
        }

        /// <summary>
        /// Все рассчеты происходят здесь
        /// </summary>
        /// <param name="xValue"> Содержание дрожжей </param>
        /// <param name="nValue"> Уровень азота </param>
        /// <param name="eValue"> Уровень етанола </param>
        /// <param name="sValue"> Уровень сахара </param>
        /// <param name="startTime"> День с которого начинается прогнозирование </param>
        /// <param name="endTime"> День которым завершается прогнозирование </param>
        /// <param name="wValue"> Объем сусла </param>
        /// <returns></returns>
        private Vector<double>[] GetTimeLine(double xValue, double nValue, double eValue, double sValue, double wValue, int startTime, int endTime)
        {
            var startValues = Vector<double>.Build.Dense(new[] { xValue, nValue, eValue, sValue });
            Func<double, Vector<double>, Vector<double>> der = DerivativeMaker();

            Vector<double>[] res = RungeKutta.FourthOrder(startValues, startTime, endTime, endTime, der);

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = AddItemToVector(res[i], wValue);
            }

            return res;
        }

        /// <summary>
        /// Метод добавления элемент к вектору
        /// Такие присядания из-за того, что MathNet.Numerics не содержит методов для добавления элементов в вектор
        /// </summary>
        /// <param name="startVector"> Вектор к которому добавляют значение </param>
        /// <param name="item"> Добавляемое значение </param>
        /// <returns></returns>
        private Vector<double> AddItemToVector(Vector<double> startVector, double item)
        {
            // Создаем новый вектор, добавляя новый элемент
            Vector<double> extendedVector = Vector<double>.Build.Dense(startVector.Count + 1);
            for (int i = 0; i < startVector.Count; i++)
            {
                extendedVector[i] = startVector[i];
            }
            // Добавляем новый элемент в конец
            extendedVector[startVector.Count] = item;

            return extendedVector;
        }
    }
}
