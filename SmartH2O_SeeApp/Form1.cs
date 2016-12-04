using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartH2O_SeeApp
{

    //mejehedfkjnjgjgjkgkhjgsdgsdg
    //edicao edicao no branch JP

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializeComponents(sender, e);
        }

        private void inicializeComponents(object sender, EventArgs e)
        {
            weeklyDateTimePicker_ValueChanged(sender, e);
        }

        private void optionsAlarmsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionsAlarmsComboBox.SelectedIndex == 1)
            {
                fromAlarmsDateTimePicker.Enabled = true;
                toAlarmsDateTimePicker.Enabled = true;
            }
            if (optionsAlarmsComboBox.SelectedIndex == 0)
            {
                fromAlarmsDateTimePicker.Enabled = false;
                toAlarmsDateTimePicker.Enabled = false;
            }
        }

        private void submitAlarmsButton_Click(object sender, EventArgs e)
        {
            if (optionsAlarmsComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Must select a option");
                return;
            }
            else if (optionsAlarmsComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("All alarms");
                return;
            }
            else if (optionsAlarmsComboBox.SelectedIndex == 1)
            {
                DateTime startDate = fromAlarmsDateTimePicker.Value;
                DateTime endDate = toAlarmsDateTimePicker.Value;

                if (checkDates(startDate, endDate))
                {
                    MessageBox.Show("Check the dates order FROM < TO");
                    return;
                }

                String sDate = startDate.ToString("dd;MM;yyyy");
                String eDate = endDate.ToString("dd;MM;yyyy");
                MessageBox.Show(sDate);
                MessageBox.Show(eDate);

            }

        }

        private void submitDailyParameterButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = fromDailyDateTimePicker.Value;
            DateTime endDate = toDailyDateTimePicker.Value;

            if (checkDates(startDate, endDate))
            {
                MessageBox.Show("Check the dates order FROM < TO");
                return;
            }

            String sDate = startDate.ToString("dd;MM;yyyy");
            String eDate = endDate.ToString("dd;MM;yyyy");
            MessageBox.Show(sDate);
            MessageBox.Show(eDate);
        }

        private void submitHourlyParameterButton_Click(object sender, EventArgs e)
        {
            DateTime todayDate = DateTime.Now;
            DateTime selectedDate = parameterHourlyDateTimePicker.Value;

            if (checkDates(selectedDate, todayDate))
            {
                MessageBox.Show("Check the dates order FROM < TO");
                return;
            }

            String sDate = selectedDate.ToString("dd;MM;yyyy");
            String eDate = todayDate.ToString("dd;MM;yyyy");
            MessageBox.Show(sDate);
            MessageBox.Show(eDate);
        }

        public bool checkDates(DateTime startDate, DateTime endDate)
        {
            return (startDate.Date > endDate.Date ? true : false);
        }

        private void submitWeeklyParameterButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show((weekComboBox.SelectedIndex + 1).ToString());
            //MessageBox.Show(weeklyDateTimePicker.Value.Year.ToString());
            /*CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            // Displays the total number of weeks in the current year.
            DateTime LastDay = new System.DateTime(weeklyDateTimePicker.Value.Year, 12, 31);
            MessageBox.Show("There are " + myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW) + " weeks in the current year " + LastDay.Year);

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime currentDate = weeklyDateTimePicker.Value;
            Calendar cal = dfi.Calendar;

            MessageBox.Show(currentDate + " Week " + cal.GetWeekOfYear(currentDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + cal.ToString().Substring(cal.ToString().LastIndexOf(".") + 1));

            int thisWeek = GetIso8601WeekOfYear(weeklyDateTimePicker.Value);
            DateTime firstDayOfWeek = FirstDateOfWeek(currentDate.Year, thisWeek, CultureInfo.CurrentCulture);
            DateTime lastDayOfWek = firstDayOfWeek.AddDays(6);


            MessageBox.Show(firstDayOfWeek.ToString());
            MessageBox.Show(lastDayOfWek.ToString());*/
        }

        /*public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }*/

        private void weeklyDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime jan1 = new DateTime(weeklyDateTimePicker.Value.Year, 1, 1);
            //beware different cultures, see other answers
            DateTime startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
            var weeks =
                Enumerable
                    .Range(0, 54)
                    .Select(i => new
                    {
                        weekStart = startOfFirstWeek.AddDays(i * 7)
                    })
                    .TakeWhile(x => x.weekStart.Year <= jan1.Year)
                    .Select(x => new
                    {
                        x.weekStart,
                        weekFinish = x.weekStart.AddDays(7)
                    })
                    .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
                    .Select((x, i) => new
                    {
                        x.weekStart,
                        x.weekFinish,
                        weekNum = i + 1
                    });

            weekComboBox.Items.Clear();
            foreach (var week in weeks)
            {
                weekComboBox.Items.Add("Semana nº " + week.weekNum + " de " + week.weekStart.ToShortDateString() + " a " + week.weekFinish.ToShortDateString());
            }
        }
    }
}
