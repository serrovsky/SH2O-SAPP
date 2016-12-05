using SmartH2O_SeeApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartH2O_SeeApp
{

    public partial class Form1 : Form
    {

        ServiceSmartH2OClient smartH2OClient;

        public Form1()
        {
            InitializeComponent();
            initializeService();
        }

        private void initializeService()
        {
            /*
            smartH2OClient = new ServiceSmartH2OClient(); //TODO: acho que esta incompleto..neve precisar de mais alguma coisa quando o servico nao for local..

            HourlySummarizedValues[] list = smartH2OClient.getHourlySummarizedByDay(ParameterType.PH, DateTime.Today);

            //TODO: validar se a lista esta vazia..
            //Console.WriteLine("Testing service!!!!!!!!!!!!SERRA!!!!!!!!!!!!!! __>>>>>" + list[0].Averange + "<<<<<<");

            AlarmData[] list2 = smartH2OClient.getDailyAlarmsInformation();
            mais um test
            Console.WriteLine("STEP 3");
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializeComponents(sender, e);
        }

        private void inicializeComponents(object sender, EventArgs e)
        {
            weeklyDateTimePicker_ValueChanged(sender, e);
            optionsAlarmsComboBox.SelectedIndex = 0;
            periodGraphicallComboBox.SelectedIndex = 0;
            parametersCheckedListBox.SetItemChecked(0, true);
            parametersCheckedListBox.SetItemChecked(1, true);
            parametersCheckedListBox.SetItemChecked(2, true);

            /*
            listViewParametersValues.Columns.Add("Parameter", -2, HorizontalAlignment.Left);
            listViewParametersValues.Columns.Add("Value", -2, HorizontalAlignment.Left);
            listViewParametersValues.Columns.Add("Date", -2, HorizontalAlignment.Left);
            listViewParametersValues.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listViewParametersValues.View = View.Details;
            */

        }

        private void optionsAlarmsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            // TODO: No parameters alarm, haver uma opção de predefinida..
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

        private void submitHourlyParameterButton_Click(object sender, EventArgs e)
        {
            listBoxParametersValues.Items.Clear();

            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            DateTime todayDate = DateTime.Now;
            DateTime selectedDate = parameterHourlyDateTimePicker.Value;

            if (checkDates(selectedDate, todayDate))
            {
                MessageBox.Show("PLEASE CHECK THE DATES (SELECTEDDATE <= TODAY ");
                return;
            }

            if (parametersCheckedListBox.GetItemChecked(0))
            {
                //chamar o metodo do servico com (selectedDate, PH)

                HourlySummarizedValues[] list = smartH2OClient.getHourlySummarizedByDay(ParameterType.PH, selectedDate);

                //TODO: validar se ficheiro vazio

                foreach (HourlySummarizedValues values in list)
                {
                    Debug.WriteLine("\t !!!!!!!!!!!!!!! hora: {0}, min: {1}, max: {2}, avg: {3}", values.Hour, values.Min, values.Max, values.Averange);
                    listBoxParametersValues.Items.Add("Parameter Type: PH | Hour: " + values.Hour + " | Minimum value: " + values.Min + " | Maximum value: " + values.Max + " | Averange value: " + values.Averange);
                }


            }
            if (parametersCheckedListBox.GetItemChecked(1))
            {
                //chamar o metodo do servico com (selectedDate, NH3)
            }
            if (parametersCheckedListBox.GetItemChecked(2))
            {
                //chamar o metodo do servico com (selectedDate, CI2)
            }
        }

        private void submitAlarmsButton_Click(object sender, EventArgs e)
        {
            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            if (optionsAlarmsComboBox.SelectedIndex == 0)
            {
                //chamar o metodo do servico com (PH)
                //chamar o metodo do servico com (NH3)
                //chamar o metodo do servico com (CI2)
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

                //chamar o metodo do servico com (startDate, endDate, PH)
                //chamar o metodo do servico com (startDate, endDate, NH3)
                //chamar o metodo do servico com (startDate, endDate, CI2)
            }
        }

        private void submitDailyParameterButton_Click(object sender, EventArgs e)
        {
            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            DateTime todayDate = DateTime.Now;
            DateTime startDate = fromDailyDateTimePicker.Value;
            DateTime endDate = toDailyDateTimePicker.Value;

            if (checkDates(startDate, todayDate) || checkDates(endDate, todayDate))
            {
                MessageBox.Show("Check the dates order STARTDATE OR ENDDATE < TODAY");
                return;
            }

            if (checkDates(startDate, endDate))
            {
                MessageBox.Show("Check the dates order FROMDATE < TODATE");
                return;
            }

            if (parametersCheckedListBox.GetItemChecked(0))
            {
                //chamar o metodo do servico com (startDate, endDate, PH)
            }
            if (parametersCheckedListBox.GetItemChecked(1))
            {
                //chamar o metodo do servico com (startDate, endDate, NH3)
            }
            if (parametersCheckedListBox.GetItemChecked(2))
            {
                //chamar o metodo do servico com (startDate, endDate, CI2)
            }
        }

        private void submitWeeklyParameterButton_Click(object sender, EventArgs e)
        {
            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            if (weekComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Must select a week");
                return;
            }

            int year = weeklyDateTimePicker.Value.Year;
            int selectedWeek = weekComboBox.SelectedIndex + 1;

            if (parametersCheckedListBox.GetItemChecked(0))
            {
                //chamar o metodo do servico com (selectedWeek, year, PH)
            }
            if (parametersCheckedListBox.GetItemChecked(1))
            {
                //chamar o metodo do servico com (selectedWeek, year, NH3)
            }
            if (parametersCheckedListBox.GetItemChecked(2))
            {
                //chamar o metodo do servico com (selectedWeek, year, CI2)
            }
        }



        private bool checkIfAreNoItemsSelected()
        {
            if (parametersCheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Must select a parameter to show values");
                return true;
            }

            return false;
        }

        private bool checkDates(DateTime startDate, DateTime endDate)
        {
            return (startDate.Date > endDate.Date ? true : false);
        }


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

        private void periodGraphicallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (periodGraphicallComboBox.SelectedIndex == 0)
            {
                weekGraphComboBox.Enabled = false;
                dateTimePickerDateGraph.Enabled = true;
                dateTimePickerYearGraph.Enabled = false;
            }
            else if (periodGraphicallComboBox.SelectedIndex == 1)
            {
                weekGraphComboBox.Enabled = true;
                dateTimePickerDateGraph.Enabled = false;
                dateTimePickerYearGraph.Enabled = true;
            }
        }

        private void dateTimePickerYearGraph_ValueChanged(object sender, EventArgs e)
        {
            DateTime jan1 = new DateTime(dateTimePickerYearGraph.Value.Year, 1, 1);
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

            weekGraphComboBox.Items.Clear();
            foreach (var week in weeks)
            {
                weekGraphComboBox.Items.Add("Semana nº " + week.weekNum + " de " + week.weekStart.ToShortDateString() + " a " + week.weekFinish.ToShortDateString());
            }
        }

    }
}
