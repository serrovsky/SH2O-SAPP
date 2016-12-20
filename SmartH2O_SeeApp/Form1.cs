using SmartH2O_SeeApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartH2O_SeeApp
{

    public partial class Form1 : Form
    {

        ServiceSmartH2OClient smartH2OClient;
        //List<Week> listOfWeekDays = new List<Week>();
        WeekList weeksDatesManager = new WeekList();

        public Form1()
        {
            smartH2OClient = new ServiceSmartH2OClient();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializeComponents(sender, e);
        }

        private void inicializeComponents(object sender, EventArgs e)
        {
            weeklyDateTimePicker_ValueChanged(sender, e);
            dateTimePickerYearGraph_ValueChanged(sender, e);
            optionsAlarmsComboBox.SelectedIndex = 0;
            periodGraphicallComboBox.SelectedIndex = 0;
            parametersCheckedListBox.SetItemChecked(0, true);
            parametersCheckedListBox.SetItemChecked(1, true);
            parametersCheckedListBox.SetItemChecked(2, true);
        }

        private void optionsAlarmsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionsAlarmsComboBox.SelectedIndex == 1)
            {
                toAlarmsDateTimePicker.Enabled = true;
            }
            if (optionsAlarmsComboBox.SelectedIndex == 0)
            {
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

            /*
            if (checkDates(selectedDate, todayDate))
            {
                MessageBox.Show("PLEASE CHECK THE DATES (SELECTEDDATE <= TODAY)");
                return;
            }*/

            List<ParameterType> parameters = new List<ParameterType>();
            if (parametersCheckedListBox.GetItemChecked(0)) //PH
            {
                parameters.Add(ParameterType.PH);
            }
            if (parametersCheckedListBox.GetItemChecked(1)) //NH3
            {
                parameters.Add(ParameterType.NH3);
            }
            if (parametersCheckedListBox.GetItemChecked(2)) //CI2
            {
                parameters.Add(ParameterType.CI2);
            }

            List<HourlySummarizedValues> list = new List<HourlySummarizedValues>();
            foreach (ParameterType type in parameters)
            {
                try
                {
                    list.AddRange(smartH2OClient.getHourlySummarizedByDay(type, selectedDate));
                }
                catch (FaultException<FoundNoResultsException> ex)
                {/* não adiciona nada à lista*/}
                catch (FaultException<InternalErrorException> ex)
                {
                    // erro interno no servico, nao interessa dar detalhes
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            if (list.Count == 0)
            {
                MessageBox.Show("No Results were found from " + selectedDate.ToString("dd/MM/yyyy"));
                return;
            }

            foreach (HourlySummarizedValues values in list)
            {
                listBoxParametersValues.Items.Add("Parameter: " + values.Parameter.ToString() + " | Hour: " + values.Hour + " | Minimum value: " + values.Min + " | Maximum value: " + values.Max + " | Averange value: " + values.Averange);
            }

        }

        private void submitAlarmsButton_Click(object sender, EventArgs e)
        {
            //TODO: se tiver tempo
            //limpar este metodo, dividir por funcoes privadas..

            listBoxAlarms.Items.Clear();

            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            List<AlarmData> list = new List<AlarmData>();
            string feedback = "";

            if (optionsAlarmsComboBox.SelectedIndex == 0) // selecionou dia especifico
            {
                DateTime startDate = fromAlarmsDateTimePicker.Value;
                if (checkDates(startDate, DateTime.Now))
                {
                    MessageBox.Show("PLEASE CHECK THE DATES (SELECTEDDATE <= TODAY)");
                    return;
                }

                try
                {
                    list.AddRange(smartH2OClient.getDailyAlarmsInformation(startDate));
                }
                catch (FaultException<FoundNoResultsException> ex)
                {/* não adiciona nada à lista*/}
                catch (FaultException<InternalErrorException> ex)
                {
                    // erro interno no servico, nao interessa dar detalhes
                    MessageBox.Show(ex.Message);
                    return;
                }

                feedback = "No Results were found from " + startDate.ToString("dd/MM/yyyy");
            }
            else if (optionsAlarmsComboBox.SelectedIndex == 1) // selecionou intervalo de dias
            {
                DateTime startDate = fromAlarmsDateTimePicker.Value;
                DateTime endDate = toAlarmsDateTimePicker.Value;
                DateTime todayDate = DateTime.Now;

                if (checkDates(startDate, todayDate) || checkDates(endDate, todayDate))
                {
                    MessageBox.Show("Check the dates order STARTDATE OR ENDDATE < TODAY");
                    return;
                }

                if (checkDates(startDate, endDate))
                {
                    MessageBox.Show("Check the dates order FROM < TO");
                    return;
                }

                try
                {
                    list.AddRange(smartH2OClient.getAlarmsInformationByDataInterval(startDate, endDate));
                }
                catch (FaultException<FoundNoResultsException> ex)
                {/* não adiciona nada à lista*/}
                catch (FaultException<InternalErrorException> ex)
                {
                    // erro interno no servico, nao interessa dar detalhes
                    MessageBox.Show(ex.Message);
                    return;
                }
                feedback = "No Results were found from " + startDate.ToString("dd/MM/yyyy") + "to " + endDate.ToString("dd/MM/yyyy");
            }


            if (list.Count == 0)
            {
                MessageBox.Show(feedback);
                return;
            }

            foreach (AlarmData alarmData in list)
            {
                listBoxAlarms.Items.Add("Parameter: " + alarmData.ParameterType.ToString() + " | Value: " + alarmData.Parametervalue + " | Date: " + alarmData.Date.ToString("dd/MM/yyyy HH:mm:ss") + " | Description: " + alarmData.AlarmDescription);
            }
        }

        private void submitDailyParameterButton_Click(object sender, EventArgs e)
        {
            listBoxParametersValues.Items.Clear();

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

            //TODO: testar melhor com melhores datas
            List<ParameterType> parameters = new List<ParameterType>();
            if (parametersCheckedListBox.GetItemChecked(0)) //PH
            {
                parameters.Add(ParameterType.PH);
            }
            if (parametersCheckedListBox.GetItemChecked(1)) //NH3
            {
                parameters.Add(ParameterType.NH3);
            }
            if (parametersCheckedListBox.GetItemChecked(2)) //CI2
            {
                parameters.Add(ParameterType.CI2);
            }

            List<DailySummarizedValues> list = new List<DailySummarizedValues>();
            foreach (ParameterType type in parameters)
            {
                try
                {
                    list.AddRange(smartH2OClient.getDailySummarizedByDataInterval(type, startDate, endDate));
                }
                catch (FaultException<FoundNoResultsException> ex)
                {/* não adiciona nada à lista*/}
                catch (FaultException<InternalErrorException> ex)
                {
                    // erro interno no servico, nao interessa dar detalhes
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            if (list.Count == 0)
            {
                MessageBox.Show("No Results were found from " + startDate.ToString("dd/MM/yyyy") + "to " + endDate.ToString("dd/MM/yyyy"));
                return;
            }

            //TODO: ENVIAR FAULTS SE NAO EXISTIREM RESULTADOS
            foreach (DailySummarizedValues values in list)
            {
                //Debug.WriteLine("\t !!!!!!!!!!!!!!! hora: {0}, min: {1}, max: {2}, avg: {3}", values.Hour, values.Min, values.Max, values.Averange);
                listBoxParametersValues.Items.Add("Parameter: " + values.Parameter.ToString() + " | Date: " + values.DayDate.ToString("dd/MM/yyyy") + " | Minimum value: " + values.Min + " | Maximum value: " + values.Max + " | Averange value: " + values.Averange);
            }

        }

        private void submitWeeklyParameterButton_Click(object sender, EventArgs e)
        {

            //TODO: alterar restantes metodos com base neste
            listBoxParametersValues.Items.Clear();

            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            if (weekComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Must select a week");
                return;
            }

            List<ParameterType> parameters = new List<ParameterType>();
            if (parametersCheckedListBox.GetItemChecked(0)) // PH selected
            {
                parameters.Add(ParameterType.PH);
            }
            if (parametersCheckedListBox.GetItemChecked(1)) //NH3 selected
            {
                parameters.Add(ParameterType.NH3);
            }
            if (parametersCheckedListBox.GetItemChecked(2)) // CI2 Selected
            {
                parameters.Add(ParameterType.CI2);
            }

            int selectedYear = weeklyDateTimePicker.Value.Year;
            int selectedWeek = weekComboBox.SelectedIndex + 1;
            List<WeeklySummarizedValues> list = new List<WeeklySummarizedValues>();

            foreach (ParameterType type in parameters)
            {
                try
                {
                    list.Add(smartH2OClient.getWeeklySummarized(type, selectedWeek, selectedYear));
                }
                catch (FaultException<FoundNoResultsException> ex)
                { /*não adiciona nada à lista*/}
                catch (FaultException<InternalErrorException> ex)
                {
                    // erro interno no servico, nao interessa dar detalhes
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            if (list.Count == 0)
            {
                MessageBox.Show("No Results were found: Week: " + selectedWeek + ", Year: " + selectedYear);
                return;
            }

            foreach (WeeklySummarizedValues values in list)
            {
                listBoxParametersValues.Items.Add("Parameter: " + values.Parameter.ToString() + " | Week: " + values.WeekNumber + " | Minimum value: " + values.Min + " | Maximum value: " + values.Max + " | Averange value: " + values.Averange);
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
            List<string> weeks = getWeekNumbers();

            weekComboBox.Items.Clear();
            foreach (var week in weeks)
            {
                weekComboBox.Items.Add(week);
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
            List<String> weeks = getWeekNumbers();
            weekGraphComboBox.Items.Clear();
            foreach (var week in weeks)
            {
                weekGraphComboBox.Items.Add(week);
            }
        }

        private List<string> getWeekNumbers()
        {
            List<String> weeksList = new List<string>();


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

            foreach (var week in weeks)
            {
                weeksList.Add("Semana nº " + week.weekNum + " de " + week.weekStart.ToShortDateString() + " a " + week.weekFinish.ToShortDateString());
                //guarda datas de cada semana
                weeksDatesManager.add(new Week((int)week.weekNum, (DateTime)week.weekStart, (DateTime)week.weekFinish));
            }

            return weeksList;
        }

        private void submitGraphicallInformationButton_Click(object sender, EventArgs e)
        {
            // limpa grafico
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }

            try
            {
                if (periodGraphicallComboBox.SelectedIndex == 0) //pesquisa por dia
                {
                    displayChartsByDay();
                }
                else if (periodGraphicallComboBox.SelectedIndex == 1) //pesquisa por semana
                {

                    displayChartsByWeek();
                }
            }
            catch (FaultException<InternalErrorException> ex)
            {
                // erro interno no servico, nao interessa dar detalhes
                MessageBox.Show(ex.Message);
                return;
            }
            catch (FaultException<FunctionParameterException> ex)
            {
                //TODO: nao esta a funcionar
                MessageBox.Show("" + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                //catch para o caso de correr alguma coisa mal com o parse em displayChartsByWeek()
                MessageBox.Show("Este erro aconteceu porque quem desenvolveu isto é uma besta! - " + ex.Message);
                return;
            }
        }

        private void displayChartsByWeek()
        {
            // quem chama esta funcao está dentro de um try catch para apanhar
            //algum problema que acontece com o PARSE..////////////////////////////////
            int selectedWeek = weekGraphComboBox.SelectedIndex + 1;//

            ///////////////////////////////////////////////////////////////////////////                                                                                     

            DateTime firstDayDate = weeksDatesManager.getFirstDayOf(selectedWeek);
            DateTime lastDayDate = weeksDatesManager.geLastDayOf(selectedWeek);

            bool nothingAdded = true;
            foreach (ParameterType type in Enum.GetValues(typeof(ParameterType)))
            {
                try
                {
                    addDailyValuesByDateInterval(smartH2OClient.getDailySummarizedByDataInterval(type, firstDayDate, lastDayDate));
                    nothingAdded = false;
                }
                catch (FaultException<FoundNoResultsException> ex) // esta tem de ser apanhada no local
                {/* não adiciona nada à lista*/
                    //MessageBox.Show("apanhou22222222222222");
                }
            }

            if (nothingAdded)
            {
                MessageBox.Show("No Results were found from " + firstDayDate.ToString("dd/MM/yyyy") + " to " + lastDayDate.ToString("dd/MM/yyyy"));
            }

        }

        private void addDailyValuesByDateInterval(DailySummarizedValues[] arr)
        {
            //TODO: tirar isto daqui
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[1].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[2].AxisX.LabelStyle.Interval = 1;

            //MessageBox.Show(arr.Length.ToString());

            //TODO: se houver apenas um resultado mudar para grafico de barras
            for (int i = 0; i < arr.Length; i++)
            {
                //string idn = arr[i].DayDate.ToString("ddd");

                string idn = arr[i].DayDate.ToString("dd/MM");

                string typeS = arr[i].Parameter.ToString();

                chart.Series[typeS + " Min"].Points.AddXY(idn, arr[i].Min);
                chart.Series[typeS + " Avg"].Points.AddXY(idn, arr[i].Averange);
                chart.Series[typeS + " Max"].Points.AddXY(idn, arr[i].Max);
            }
        }

        private void displayChartsByDay()
        {
            DateTime selectedDate = dateTimePickerDateGraph.Value;

            bool nothingAdded = true;
            foreach (ParameterType type in Enum.GetValues(typeof(ParameterType)))
            {
                try
                {
                    addHoursValuesToChartByDay(smartH2OClient.getHourlySummarizedByDay(type, selectedDate));
                    nothingAdded = false;
                }
                catch (FaultException<FoundNoResultsException> ex) // esta tem de ser apanhada no local
                {/* não adiciona nada à lista*/
                 //MessageBox.Show("apanhou22222222222222");
                }
            }

            if (nothingAdded)
            {
                MessageBox.Show("No Results were found from " + selectedDate.ToString("dd/MM/yyyy"));
            }
        }

        private void addHoursValuesToChartByDay(HourlySummarizedValues[] arr)
        {
            //TODO: tirar isto daqui
            //chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //chart.ChartAreas[1].AxisX.LabelStyle.Interval = 1;
            //chart.ChartAreas[2].AxisX.LabelStyle.Interval = 1;

            //MessageBox.Show(arr.Length.ToString());

            //TODO: se houver apenas um resultado mudar para grafico de barras
            for (int i = 0; i < arr.Length; i++)
            {
                string idn = arr[i].Hour.ToString() + "h";
                string typeS = arr[i].Parameter.ToString();

                chart.Series[typeS + " Min"].Points.AddXY(idn, arr[i].Min);
                chart.Series[typeS + " Avg"].Points.AddXY(idn, arr[i].Averange);
                chart.Series[typeS + " Max"].Points.AddXY(idn, arr[i].Max);
            }
        }

        internal class Week
        {
            public int WeekNum { get; }
            public DateTime FirstDay { get; }
            public DateTime LastDay { get; }

            public Week(int weeknumber, DateTime first, DateTime last)
            {
                WeekNum = weeknumber;
                FirstDay = first;
                LastDay = last;
            }
        }
        internal class WeekList
        { // esta class é preenchida cada vez que uma lista de semanas é preenchida.
            private Week[] weeks;

            public WeekList()
            {
                weeks = new Week[53];
            }

            public void add(int weekNum, DateTime first, DateTime last)
            {
                add(new Week(weekNum, first, last));
            }

            public void add(Week week)
            {
                weeks[week.WeekNum - 1] = week;
            }

            public DateTime getFirstDayOf(int weekNumber)
            {
                return weeks[weekNumber - 1].FirstDay;
            }

            public DateTime geLastDayOf(int weekNumber)
            {
                return weeks[weekNumber - 1].LastDay;
            }
        }
    }
}


