namespace DayTimer
{
    using System;
    using System.Collections.Generic;

    //using System.Linq;
    using System.Text;
    using System.Threading;

    public interface ITimer
    {
        event EventHandler Tick;

        void Change(TimeSpan dueTime);

        void Change(TimeSpan dueTime, TimeSpan period);

        void Stop();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class TimerProvider : ITimer
    {
        private Timer timer;

        public event EventHandler Tick;

        private void TimerCallback(object state)
        {
            EventHandler tick = Tick;
            if (tick != null)
                tick(this, new EventArgs());
        }

        public TimerProvider(TimeSpan dueTime, TimeSpan period, object state = null)
        {
            timer = new Timer(TimerCallback, state, dueTime, period);
        }

        public void Change(TimeSpan dueTime)
        {
            Change(dueTime, TimeSpan.Zero);
        }

        public void Change(TimeSpan dueTime, TimeSpan period)
        {
            timer.Change(dueTime, period);
        }

        public void Stop()
        {
            timer.Change(-1, -1);
        }
    }
}