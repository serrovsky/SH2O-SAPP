﻿using System;
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
            optionsAlarmsComboBox.SelectedIndex = 0;
            parametersCheckedListBox.SetItemChecked(0, true);
            parametersCheckedListBox.SetItemChecked(1, true);
            parametersCheckedListBox.SetItemChecked(2, true);
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


        private void submitHourlyParameterButton_Click(object sender, EventArgs e)
        {
            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            DateTime todayDate = DateTime.Now;
            DateTime selectedDate = parameterHourlyDateTimePicker.Value;

            if (checkDates(selectedDate, todayDate))
            {
                MessageBox.Show("Check the dates order FROM < TO");
                return;
            }

            if (parametersCheckedListBox.GetItemChecked(0))
            {
                //chamar o metodo do servico com (selectedDate, PH)
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

        private void submitDailyParameterButton_Click(object sender, EventArgs e)
        {
            if (checkIfAreNoItemsSelected())
            {
                return;
            }

            DateTime startDate = fromDailyDateTimePicker.Value;
            DateTime endDate = toDailyDateTimePicker.Value;

            if (checkDates(startDate, endDate))
            {
                MessageBox.Show("Check the dates order FROM < TO");
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
    }
}
