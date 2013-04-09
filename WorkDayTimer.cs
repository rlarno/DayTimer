namespace DayTimer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    //using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// A timer that records how long you have been 'at the job'
    /// </summary>
    public class WorkDayTimer
    {
        private DateTime dayStart;
        private IDateTimeProvider dateTime;
        private ITimer timer;

        public WorkDayTimer()
            : this(new DateTimeProvider(), null)
        {
        }

        public WorkDayTimer(IDateTimeProvider dateTimeProvider, ITimer timerProvider)
        {
            dateTime = dateTimeProvider;
            dayStart = dateTime.Now;
            timer = timerProvider;

#if DEBUG
            if (timer == null) timer = new TimerProvider(TimeSpan.FromMinutes(1), TimeSpan.Zero);
#else
            if (timer == null) timer = new TimerProvider(TimeSpan.FromHours(8), TimeSpan.Zero);
#endif
            timer.Tick += timerTick;
        }

        public DateTime Start { get { return dayStart; } }
        public TimeSpan RunningTime { get { return dateTime.Now.Subtract(dayStart); } }

        public event EventHandler<EventArgs> Tick;

        private void timerTick(object sender, EventArgs e)
        {
            var tick = Tick;
            if (tick == null) return;
            var sync = tick.Target as ISynchronizeInvoke;
            if (sync != null && sync.InvokeRequired)
            {
                sync.BeginInvoke(tick, new object[] { sender, e });
            }
            else
            {
                tick(sender, e);
            }
        }
    }
}