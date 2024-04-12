using Core.Actions.Abstractions.TimeLineCalculator;
using Core.Models.Abstractions;
using MathNet.Numerics.LinearAlgebra;

namespace Core.Actions.Abstractions.TimeLineCreator
{
    /// <summary>
    /// Генератор TimeLine
    /// </summary>
    /// <typeparam name="I"> BaseIndicator </typeparam>
    /// <typeparam name="TL"> BaseTimeLine </typeparam>
    /// <typeparam name="D"> BaseDay </typeparam>
    public abstract class BaseTimeLineCreator<I, TL, D> where I : BaseIndicator where TL : BaseEntity
    {
        protected BaseTimeLineCalculator<I> calculator;

        public BaseTimeLineCreator(BaseTimeLineCalculator<I> calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Получить Тайм-лайн
        /// </summary>
        /// <param name="indicator"> Начальный показания сусла </param>
        /// <param name="startTime"> Начало прогноза </param>
        /// <param name="endTime"> До какого дня будет рассчитываться (без учета корректировки) </param>
        /// <returns></returns>
        public TL GetTimeLine(I indicator, int startTime, int endTime)
        {
            var baseCalculatedTimeLine = Calculate(indicator, startTime, endTime);      //Рассчитали
            var convertedTimeLine = Convert(baseCalculatedTimeLine);                    //Спарсили
            convertedTimeLine = Correct(convertedTimeLine);                             //Скорректировали
            return convertedTimeLine;
        }

        /// <summary>
        /// Рассчет модели таймлайна
        /// </summary>
        /// <returns></returns>
        protected abstract Vector<double>[] Calculate(I indicator, int startTime, int endTime);

        /// <summary>
        /// Конвертация модели таймлайна
        /// </summary>
        /// <param name="vectors"></param>
        /// <returns></returns>
        protected abstract TL Convert(Vector<double>[] vectors);

        /// <summary>
        /// Корректировки модели таймлайна
        /// </summary>
        /// <param name="timeLine"></param>
        /// <returns></returns>
        protected virtual TL Correct(TL timeLine)
        {
            return timeLine;        //Базовый случай без корректировок
        }
    }
}
