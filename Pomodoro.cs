namespace DayTimer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    //using System.Linq;
    using System.Text;

    public class Pomodoro
    {
        public const int MinutesToMilliseconds = 1000 * 60;
#if DEBUG
        public static TimeSpan StartupInterval = TimeSpan.FromSeconds(2);
        public static TimeSpan WorkInterval = TimeSpan.FromSeconds(10);
        public static TimeSpan PauzeInterval = TimeSpan.FromSeconds(5);
#else
        public static TimeSpan StartupInterval = TimeSpan.FromMinutes(45);
        public static TimeSpan WorkInterval = TimeSpan.FromMinutes(25);
        public static TimeSpan PauzeInterval = TimeSpan.FromMinutes(5);
#endif

        private IDateTimeProvider dateTime;
        private ITimer timer;
        private DateTime start;

        private TimeSpan working = TimeSpan.Zero;
        private TimeSpan pauze = TimeSpan.Zero;
        private TimeSpan inactive = TimeSpan.Zero;

        public Pomodoro(IDateTimeProvider dateTime, ITimer timer)
        {
            this.dateTime = dateTime;
            this.timer = timer;
            timer.Tick += timerTick;
            start = dateTime.Now;
            Activity = Activity.Startup;
        }

        public Pomodoro()
            : this(new DateTimeProvider(), new TimerProvider(StartupInterval, TimeSpan.Zero))
        {
        }

        public void LoadSettings(TimeSpan totalWork, TimeSpan totalPauze)
        {
            working = totalWork;
            pauze = totalPauze;
        }

        public void Start()
        {
            start = dateTime.Now;
        }

        public void StartWorking()
        {
            CommitTime();
            Activity = Activity.Working;
            Interval = WorkInterval;
            timer.Change(WorkInterval);
        }

        public void StartPauze()
        {
            CommitTime();
            Activity = Activity.Pauze;
            Interval = PauzeInterval;
            timer.Change(PauzeInterval);
        }

        public void SessionLock()
        {
            CommitTime();
            Activity = Activity.InActive;
            timer.Stop();
        }

        private void CommitTime()
        {
            var now = dateTime.Now;
            var add = now.Subtract(start);
            start = now;
            switch (Activity)
            {
                case Activity.Startup:
                    break;

                case Activity.Working:
                    working += add;
                    break;

                case Activity.Pauze:
                case Activity.ExtendedPauze:
                    pauze += add;
                    break;

                case Activity.InActive:
                    inactive += add;
                    break;

                case Activity.Lunch:
                    break;

                case Activity.Meeting:
                    break;

                default:
                    break;
            }
        }

        public TimeSpan Interval { get; private set; }
        public Activity Activity { get; private set; }
        public TimeSpan Elapsed { get { return dateTime.Now.Subtract(start); } }
        public TimeSpan Remaining { get { return Interval - Elapsed; } }

        public TimeSpan TotalWork
        {
            get
            {
                return working + (Activity == Activity.Working ? Elapsed : TimeSpan.Zero); ;
            }
        }

        public TimeSpan TotalPauze
        {
            get { return pauze + (IsPauze ? Elapsed : TimeSpan.Zero); }
        }

        public bool IsPauze
        {
            get
            {
                return Activity == Activity.Pauze
                    || Activity == Activity.ExtendedPauze;
            }
        }

        internal void ExtendPauze(int pauze)
        {
            Activity = Activity.ExtendedPauze;
            Interval = TimeSpan.FromMinutes(pauze);
            timer.Change(Interval);
        }

        internal void DismissPauze()
        {
            if (Activity != Activity.Working) throw new InvalidOperationException("DismissPauze Should not be called if not working");
            timer.Change(PauzeInterval);
        }

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