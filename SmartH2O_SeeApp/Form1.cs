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

        public Form1()
        {
            InitializeComponent();
            initializeService();
        }

        private void initializeService()
        {
            smartH2OClient = new ServiceSmartH2OClient(); //TODO: acho que esta incompleto..neve precisar de mais alguma coisa quando o servico nao for local..



            /*
            try
            {
                HourlySummarizedValues[] list = smartH2OClient.getHourlySummarizedByDay(ParameterType.PH, DateTime.Today);
            }
            catch (FaultException<Fault> f)
            {
                MessageBox.Show("rebentou na excepcao");
                return;
            }
            */


            //HourlySummarizedValues[] list = smartH2OClient.getHourlySummarizedByDay(ParameterType.PH, DateTime.Today);

            //TODO: validar se a lista esta vazia..
            //Console.WriteLine("Testing service!!!!!!!!!!!!JP!!!!!!!! __>>>>>" + list[0].Averange + "<<<<<<");

            //AlarmData[] list2 = smartH2OClient.getDailyAlarmsInformation();

            Console.WriteLine("STEP 3");

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
                fromAlarmsDateTimePicker.Enabled = true;
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
                MessageBox.Show("PLEASE CHECK THE DATES (SELECTEDDATE <= TODAY)");
                return;
            }

            List<HourlySummarizedValues> list = new List<HourlySummarizedValues>();

            if (parametersCheckedListBox.GetItemChecked(0))
            {

                //chamar o metodo do servico com (selectedDate, PH
                list.AddRange(smartH2OClient.getHourlySummarizedByDay(ParameterType.PH, selectedDate));

            }
            if (parametersCheckedListBox.GetItemChecked(1))
            {
                //chamar o metodo do servico com (selectedDate, NH3)
                list.AddRange(smartH2OClient.getHourlySummarizedByDay(ParameterType.NH3, selectedDate));
            }
            if (parametersCheckedListBox.GetItemChecked(2))
            {
                //chamar o metodo do servico com (selectedDate, CI2)
                list.AddRange(smartH2OClient.getHourlySummarizedByDay(ParameterType.CI2, selectedDate));
            }

            //TODO: validar se lista vazia
            //Se a data nao der resultado, nao chega lista para ser apanhado por este if.. confimar..

            if (list.Count == 0)
            {
                listBoxParametersValues.Items.Add("Não existem resultados");
                return;
            }

            foreach (HourlySummarizedValues values in list)
            {
                listBoxParametersValues.Items.Add("Parameter: " + values.Parameter.ToString() + " | Hour: " + values.Hour + " | Minimum value: " + values.Min + " | Maximum value: " + values.Max + " | Averange value: " + values.Averange);
            }

        }

        private void submitAlarmsButton_Click(object sender, EventArgs e)
        {

            listBoxAlarms.Items.Clear();

            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            List<AlarmData> list = new List<AlarmData>();

            if (optionsAlarmsComboBox.SelectedIndex == 0) // selecionou dia especifico
            {
                DateTime startDate = fromAlarmsDateTimePicker.Value;
                DateTime todayDate = DateTime.Now;
                if (checkDates(startDate, todayDate))
                {
                    MessageBox.Show("PLEASE CHECK THE DATES (SELECTEDDATE <= TODAY)");
                    return;
                }
                //chamar o metodo do servico com (PH)
                //chamar o metodo do servico com (NH3)
                //chamar o metodo do servico com (CI2)

                //TODO: prof
                //{"The maximum message size quota for incoming messages (65536) has been exceeded. To increase the quota, use the MaxReceivedMessageSize property on the appropriate binding element."}
                // esta linha da este erro caso o ficheiro seja muito grande.. como Resolver??
                list.AddRange(smartH2OClient.getDailyAlarmsInformation(startDate));

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

                //chamar o metodo do servico com (startDate, endDate, PH)
                //chamar o metodo do servico com (startDate, endDate, NH3)
                //chamar o metodo do servico com (startDate, endDate, CI2)
                list.AddRange(smartH2OClient.getAlarmsInformationByDataInterval(startDate, endDate));
            }

            Debug.WriteLine("/t/t/t/t ListCount: " + list.Count);
            //TODO: Se tiver tempo
            //Completar data com horas e minutos e mostrar.. Fica com melhor aspecto
            foreach (AlarmData alarmData in list)
            {
                //Debug.WriteLine("\t !!!!!!!!!!!!!!! hora: {0}, min: {1}, max: {2}, avg: {3}", values.Hour, values.Min, values.Max, values.Averange);
                listBoxAlarms.Items.Add("Parameter: " + alarmData.ParameterType.ToString() + " | Value: " + alarmData.Parametervalue + " | Date: " + alarmData.Date.ToString("dd/MM/yyyy") + " | Description: " + alarmData.AlarmDescription);
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
            DailySummarizedValues[] array;
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

        //TODO: SERRA!!
        // as listas das semanas estao erradas.. Uma semana não acaba e começa no mesmo dia

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

        private void submitGraphicallInformationButton_Click(object sender, EventArgs e)
        {

            // limpa grafico
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            //TODO: validar quais a opçoes escolhidas..

            DateTime date = dateTimePickerDateGraph.Value;

            //TODO: alterar para daily
            HourlySummarizedValues[] list = smartH2OClient.getHourlySummarizedByDay(ParameterType.CI2, date);

            for (int i = 0; i < list.Length; i++)
            {
                //string name = i.ToString("D" + 2) + "h";
                string name = list[i].Hour.ToString() + "h";
                chart1.Series[2].Points.AddXY(name, list[i].Min);
                chart1.Series[0].Points.AddXY(name, list[i].Max);
                chart1.Series[1].Points.AddXY(name, list[i].Averange);

                Console.WriteLine("Result parametro: " + list[i].Parameter.ToString());
                Console.WriteLine("OUTPUT SMATH20_SEEAPP " + list[i].Averange);
                Console.WriteLine("OUTPUT SMATH20_SEEAPP " + list[i].Min);
                Console.WriteLine("OUTPUT SMATH20_SEEAPP " + list[i].Max);
            }

            /*
            chart1.Series[0].Points.AddXY("50h", 50);
            chart1.Series[1].Points.AddXY("50h", 80);
            chart1.Series[2].Points.AddXY("50h", 60);
            */

            //TODO: grafico semanal
            //tem de mostrar todos os dias de uma semana
            //calcular o dia inicial e final da semana e chamar getDailySummarizedByDataInterval

        }
    }
}
