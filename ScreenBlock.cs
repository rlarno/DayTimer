using System.Windows.Forms;

namespace DayTimer
{
    public partial class ScreenBlock : Form
    {
        private ITime _time;
        private int _lastValue;

        public ScreenBlock(ITime time)
        {
            InitializeComponent();
            Icon = Properties.Resources.Sleeping_2;
            _time = time;
            _lastValue = 5;

            debug.DataBindings.Add("Text", this, "Debug");
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            Text = _time.Time;
#if !DEBUG
            Debug = Text;
#endif
        }

        private void numericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            var val = numericUpDown.Value;
            numericUpDown.Increment = Increment(val, val < _lastValue);
            _lastValue = (int)val;
        }

        private decimal Increment(decimal value, bool decrementing = false)
        {
            value += decrementing ? -1 : 0;
            if (value < 10) return 1;
            else if (value < 30) return 5;
            return 10;
        }

        public int PauzeInterval { get { return (int)numericUpDown.Value; } }
        public string Debug { get; set; }
    }
}