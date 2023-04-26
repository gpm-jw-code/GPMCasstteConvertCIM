using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscAlarmShow : UserControl
    {
        public List<clsAlarmDto> alarms => AlarmManager.AlarmList;
        private bool hasAlarm => alarms.Count > 0;
        private int playingAlarmIndex = 0;
        public bool showAlarmResetBtn
        {
            set
            {
                btnAlarmReset.Visible = value;
            }
        }
        public UscAlarmShow()
        {
            InitializeComponent();

        }

        private void alarm_loop_play_timer_Tick(object sender, EventArgs e)
        {
            labAlarmCount.Text = alarms.Count.ToString();
            if (!hasAlarm)
            {
                playingAlarmIndex = 0;
                return;
            }

            var alarm = alarms[playingAlarmIndex];
            if (alarm != null)
            {
                labAlarmTime.Text = alarm.Time.ToString("yyyy/MM/dd HH:mm:ss");
                labAlarmLevel.Text = alarm.Level.ToString();
                labClassify.Text = alarm.Classify;
                labDescription.Text = alarm.Description;

                UIRenderByAlarmLevel(alarm.Level);
            }

            playingAlarmIndex += 1;
            if (playingAlarmIndex >= alarms.Count)
            {
                playingAlarmIndex = 0;
            }

        }

        private void UIRenderByAlarmLevel(ALARM_LEVEL level)
        {
            Color bgColor = Color.Gray;
            Color textColor = Color.Black;
            if (level == ALARM_LEVEL.None)
            {
                bgColor = Color.LightPink;
                textColor = Color.Black;
            }
            else if (level == ALARM_LEVEL.WARNING)
            {
                //warn
                bgColor = Color.FromArgb(255, 128, 0);
                textColor = Color.Black;
            }
            else
            {
                //alrm
                bgColor = Color.Red;
                textColor = Color.White;
            }

            this.BackColor = bgColor;
            this.ForeColor = textColor;


        }

        private void animate_Tick(object sender, EventArgs e)
        {

        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            AlarmManager.ClearAlarm();
            labAlarmTime.Text = labClassify.Text = labDescription.Text = labAlarmLevel.Text = "";
            UIRenderByAlarmLevel(ALARM_LEVEL.None);
        }
    }
}
