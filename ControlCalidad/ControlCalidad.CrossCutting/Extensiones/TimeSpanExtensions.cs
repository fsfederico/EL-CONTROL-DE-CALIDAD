using System;

namespace ControlCalidad.Transversal.Extensiones
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Return now time without minutes and seconds
        /// </summary>
        /// <param name="timeSpan">This TimeSpan to get time for.</param>
        /// <returns></returns>
        public static TimeSpan GetTime(this TimeSpan timeSpan)
        {
            var subTime = new TimeSpan(0, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            return timeSpan - subTime;
        }
    }
}
