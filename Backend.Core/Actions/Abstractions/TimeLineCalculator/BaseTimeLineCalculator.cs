using Core.Models.Abstractions;
using MathNet.Numerics.LinearAlgebra;

namespace Core.Actions.Abstractions.TimeLineCalculator
{
    /// <summary>
    /// База рассчета таймлайна
    /// </summary>
    /// <typeparam name="I"> Индикатор </typeparam>
    public abstract class BaseTimeLineCalculator<I> where I : BaseIndicator
    {
        public abstract Vector<Double>[] CalculateTimeLine(I indicator, int startTime, int endTime);
    }
}
