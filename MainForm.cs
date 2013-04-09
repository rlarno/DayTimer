using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DayTimer.Properties;
using Microsoft.Win32;

namespace DayTimer
{
    public enum Activity
    {
        Startup,
        Working,
        Pauze,
        ExtendedPauze,
        InActive,
        Lunch,
        Meeting
    }

    public struct Timings
    {
        public Activity Activity;
        public TimeSpan day;
        public TimeSpan running;
        public TimeSpan work;
        public TimeSpan pauze;
        public TimeSpan remaining;
        public TimeSpan startupInterval;
        public TimeSpan workInterval;
        public TimeSpan pauzeInterval;
    }

    public interface ITime
    {
        Timings Timings { get; }
        string Time { get; }
    }

    public partial class MainForm : Form, ITime
    {
        private WorkDayTimer _dayTimer;
        private Pomodoro _pomodoro;
        private int _pauzeExtensions = 0;

        public MainForm()
        {
            InitializeComponent();
            this.DataBindings.Add("TopMost", topMostCheckBox, "Checked");
            if (Environment.MachineName == "RLAWIN7SP1")
            {
                Trace.Listeners.Add(new TextWriterTraceListener(@"E:\DayTimer.log"));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Stopwatch;
            notifyIcon.Icon = Properties.Resources.Stopwatch;
            _dayTimer = new WorkDayTimer();
            _dayTimer.Tick += DayTimer_Tick;
            _pomodoro = new Pomodoro();
            _pomodoro.Tick += _pomodoro_Tick;

            clock.Interval = 1000;

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            var settings = Settings.Default;
            if (settings.Date == DateTime.Today)
            {
                _pomodoro.LoadSettings(settings.TotalWork, settings.TotalPauze);
            }

#if DEBUG
            sessionBox.Visible = true;
            sessionBox.Tag = true;
            sessionBox.Image = Properties.Resources.SecurityLock;
#else
#endif
            clock.Start();
            _pomodoro.Start();

            // Holy Crap!
            GC.Collect(); // as the form is minimized and not shown anyway, try to release as much VM as possible.
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    _pomodoro.SessionLock();
                    break;

                case SessionSwitchReason.SessionUnlock:
                    ShowNagScreen("Unlock");
                    break;
            }
        }

        private void DayTimer_Tick(object sender, EventArgs e)
        {
            label.Text = Time;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            TopMost = true;
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            label.Text = Time;
        }

        private void _pomodoro_Tick(object sender, EventArgs e)
        {
            if (_pomodoro.Activity == Activity.Working)
            {
                notifyIcon.Icon = Properties.Resources.TimeForPauze; // SystemIcons.Application;
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipTitle = "Pomodoro end - time to relax";
                notifyIcon.BalloonTipText = string.Format(Properties.Resources.TrayBalloonTipPauze, Pomodoro.PauzeInterval.Minutes);
                notifyIcon.ShowBalloonTip(30 * 1000);
            }
            else
            {
                ShowNagScreen("Tick");
            }
        }

        private void ShowNagScreen(string Title)
        {
            using (var sc = new ScreenBlock(this))
            {
                sc.WindowState = FormWindowState.Maximized;
                sc.TopMost = true;
                sc.Opacity = .75d;
                sc.Debug = Title;
                if (sc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StartWorking();
                }
                else
                {
                    ExtendPauze(sc.PauzeInterval);
                }
            }
        }

        private void ExtendPauze(int pauze)
        {
            Trace.TraceInformation("ExtendPauze: {0}", pauze);
            _pomodoro.ExtendPauze(pauze);
            _pauzeExtensions++;
            notifyIcon.Icon = Properties.Resources.PauzeOverTime;
            if (_pauzeExtensions > 2) notifyIcon.Icon = Properties.Resources.PauzeWayOverTime;

            //PomodoroStart(pauze * MinutesToMilliseconds);
        }

        private void StartWorking()
        {
            Trace.TraceInformation("StartWorking");
            _pomodoro.StartWorking();

            //SwitchPomodoro();
            //_activity = Activity.Working;
            _pauzeExtensions = 0;
            if (autoHideCheckBox.Checked) HideMe();
            startWorkingToolStripMenuItem.Visible = false;
            notifyIcon.Icon = Properties.Resources.Sleeping_2;
        }

        private void StartPauze()
        {
            Trace.TraceInformation("StartPauze");
            _pomodoro.StartPauze();

            //SwitchPomodoro();
            //_activity = Activity.Pauze;
            if (showWhenPauzeCheckBox.Checked) ShowMe();
            startPauzeToolStripMenuItem.Visible = false;
            startWorkingToolStripMenuItem.Visible = true;
            notifyIcon.Icon = Properties.Resources.Pauze;
        }

        public Timings Timings
        {
            get
            {
                Timings t = new Timings();
                t.Activity = _pomodoro.Activity;
                t.startupInterval = Pomodoro.StartupInterval;
                t.workInterval = Pomodoro.WorkInterval;
                t.pauzeInterval = Pomodoro.PauzeInterval;
                t.day = _dayTimer.RunningTime;
                t.running = _pomodoro.Elapsed;
                t.work = _pomodoro.TotalWork;
                t.pauze = _pomodoro.TotalPauze;
                t.remaining = _pomodoro.Remaining;
                return t;
            }
        }
        public string Time
        {
            get
            {
                var t = Timings;
                var format = Properties.Resources.MainFormText;
                var s = string.Format(format,
                    t.day.ToString(@"hh\:mm\:ss"),
                    t.work.ToString(@"hh\:mm\:ss"),
                    t.pauze.ToString(@"hh\:mm\:ss"),
                    t.running.ToString(@"mm\:ss"),
                    t.remaining > TimeSpan.Zero ? string.Empty : "-",
                    t.remaining.ToString(@"mm\:ss"));
                return s;
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            StartPauze();
        }

        private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            _pomodoro.DismissPauze();
            startPauzeToolStripMenuItem.Visible = true;
        }

        private void notifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            var t = Timings;
            var s = string.Format(Properties.Resources.TrayToolTip,
                t.day.ToString(@"hh\:mm\:ss"),
                    t.work.ToString(@"hh\:mm\:ss"),
                    t.pauze.ToString(@"hh\:mm\:ss"),
                t.running.ToString(@"mm\:ss"),
                t.remaining > TimeSpan.Zero ? string.Empty : "-",
                t.remaining.ToString(@"mm\:ss"),
                t.Activity
                );
            notifyIcon.Text = s.Substring(0, Math.Min(s.Length, 63));
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                clock.Enabled = false;
                ShowInTaskbar = false;
                GC.Collect();
            }
            else
            {
                clock.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMe();
        }

        private void ShowMe()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        private void HideMe()
        {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
        }

        private void startPauzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPauze();
        }

        private void startWorkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWorking();
        }

        private void sessionBox_Click(object sender, EventArgs e)
        {
            if ((bool)sessionBox.Tag)
            {
                sessionBox.Image = Properties.Resources.Keys;
                sessionBox.Tag = false;
            }
            else
            {
                sessionBox.Image = Properties.Resources.SecurityLock;
                sessionBox.Tag = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Settings.Default;
            settings.Date = DateTime.Today;
            settings.DayTimer = _dayTimer.RunningTime;
            settings.TotalWork = _pomodoro.TotalWork;
            settings.TotalPauze = _pomodoro.TotalPauze;
        }
    }
}