using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class FormData
    {
        public FormData(Form form)
        {
            if (form is Registry)
                formData((Registry)form);
            if (form is Settings)
                formData((Settings)form);
            if (form is Edit)
                formData((Edit)form);
        }

        public FormData(Settings settings)
        {
            //
            //привязка к спискам настроек
            //
            settings.right.DataSource = null;
            string table = String.Empty;
            if (settings.typeForm == TypeForm.application)
            {
                switch (settings.left.CurrentRow.Index)
                {
                    case 0: table = SqlApplication.ApplicationCustomers.ToString(); break;
                    case 1: table = SqlApplication.ApplicationTypeWorks.ToString(); break;
                    case 2: table = SqlApplication.ApplicationViewWork.ToString(); break;
                    case 3: table = SqlApplication.ApplicationSubstrates.ToString(); break;
                    case 4: table = SqlApplication.ApplicationPaint.ToString(); break;
                    case 5: table = SqlApplication.ApplicationPrint.ToString(); break;
                    case 6: table = SqlApplication.ApplicationWorkpieceLength.ToString(); break;
                    case 7: table = SqlApplication.ApplicationProgreso.ToString(); break;
                    case 8: table = SqlApplication.ApplicationDrawing.ToString(); break;
                    case 9: table = SqlApplication.ApplicationContactsKontinent.ToString(); break;
                    case 10: table = SqlApplication.ApplicationContactCustomers.ToString(); break;
                }
                settings.right.DataSource = SqlData.GetArrayList(table);
                settings.right.Columns[0].Visible = false;
                settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
            }
            if (settings.typeForm == TypeForm.specification)
            {
                switch (settings.left.CurrentRow.Index)
                {
                    case 0: table = SqlSpecification.SpecificationParametersWorkpiece.ToString(); break;
                    case 1: table = SqlSpecification.SpecificationPrametryMachining.ToString(); break;
                    case 2: table = SqlSpecification.SpecificationRotationalSpeed.ToString(); break;
                }
                if (table == SqlSpecification.SpecificationParametersWorkpiece.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    for (int i = 0; i < settings.right.Columns.Count; i++)
                        if (i != 1 && i != 2 && i != 3 && i != 8 && i != 9)
                            settings.right.Columns[i].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.specification[7];
                    settings.right.Columns[3].HeaderText = FormText.specification[8];
                    settings.right.Columns[8].HeaderText = FormText.specification[41];
                    settings.right.Columns[9].HeaderText = FormText.specification[42];
                }
                if (table == SqlSpecification.SpecificationPrametryMachining.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    for (int i = 0; i < settings.right.Columns.Count; i++)
                        if (i != 1 && i != 3 && i != 8 && i != 10 && i != 14)
                            settings.right.Columns[i].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[3].HeaderText = String.Format("{0} {1}", FormText.specification[29], FormText.specification[26]);
                    settings.right.Columns[8].HeaderText = String.Format("{0} {1}", FormText.specification[36], FormText.specification[27]);
                    settings.right.Columns[10].HeaderText = FormText.specification[26];
                    settings.right.Columns[14].HeaderText = FormText.specification[27];
                }
                if (table == SqlSpecification.SpecificationRotationalSpeed.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = FormText.specification[38];
                    settings.right.Columns[2].HeaderText = FormText.specification[39];
                    settings.right.Columns[3].HeaderText = FormText.specification[40];
                }
            }
            if (settings.typeForm == TypeForm.engraving)
            {
                switch (settings.left.CurrentRow.Index)
                {
                    case 0: table = SqlEngraving.EngravingCode.ToString(); break;
                    case 1: table = SqlEngraving.EngravingCompensation.ToString(); break;
                    case 2: table = SqlEngraving.EngravingCutter.ToString(); break;
                    case 3: table = SqlEngraving.EngravingTime.ToString(); break;
                }

                if (table == SqlEngraving.EngravingCompensation.ToString() ||
                    table == SqlEngraving.EngravingCutter.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                }
                if (table == SqlEngraving.EngravingCode.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[1].Width = 200;
                    for (int i = 0; i < 5; i++)
                        settings.right.Columns[i + 2].HeaderText = FormText.engraving[i + 33];
                    settings.right.Columns[7].HeaderText = FormText.engraving[39];
                }
                if (table == SqlEngraving.EngravingTime.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.engraving[50];
                    settings.right.Columns[3].HeaderText = FormText.engraving[2];
                    settings.right.Columns[4].HeaderText = FormText.engraving[3];
                }
            }
            if (settings.typeForm == TypeForm.printing)
            {
                switch (settings.left.CurrentRow.Index)
                {
                    case 0: table = SqlPrinting.TrialPrintingAngle.ToString(); break;
                    case 1: table = SqlPrinting.TrialPrintingMaterial.ToString(); break;
                    case 2: table = SqlPrinting.TrialPrintingPaint.ToString(); break;
                    case 3: table = SqlPrinting.TrialPrintingPantone.ToString(); break;
                    case 4: table = SqlPrinting.TrialPrintingPrintOptions.ToString(); break;
                    case 5: table = SqlPrinting.TrialPrintingPrintSettings.ToString(); break;
                    case 6: table = SqlPrinting.TrialPrintingTime.ToString(); break;
                }
                if (table == SqlPrinting.TrialPrintingAngle.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = FormText.specification[38];
                    settings.right.Columns[2].HeaderText = FormText.printing[17];
                    settings.right.Columns[3].HeaderText = FormText.printing[16];
                }
                if (table == SqlPrinting.TrialPrintingMaterial.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.printing[15];
                }
                if (table == SqlPrinting.TrialPrintingPaint.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.printing[28];
                    settings.right.Columns[3].HeaderText = FormText.printing[8];
                    settings.right.Columns[4].HeaderText = FormText.printing[54];
                    settings.right.Columns[5].HeaderText = FormText.printing[25];
                }
                if (table == SqlPrinting.TrialPrintingPantone.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[1].Width = 200;
                    for (int i = 0; i < 18; i++)
                    {
                        settings.right.Columns[i + 2].HeaderText = System.Text.RegularExpressions.Regex.Replace(FormText.printing[i + 29], @"(\w)", "$1" + Environment.NewLine).Trim();
                        settings.right.Columns[i + 2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                if (table == SqlPrinting.TrialPrintingPrintOptions.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    for (int i = 0; i < settings.right.ColumnCount; i++)
                        if (i != 1)
                            settings.right.Columns[i].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                }
                if (table == SqlPrinting.TrialPrintingPrintSettings.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.printing[19];
                    settings.right.Columns[3].HeaderText = FormText.printing[21];
                    settings.right.Columns[4].HeaderText = FormText.printing[20];
                }
                if (table == SqlPrinting.TrialPrintingTime.ToString())
                {
                    settings.right.DataSource = SqlData.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.printing[23];
                }
            }
            settings.right.CurrentCell = settings.right[1, 0];
        }

        public FormData(Edit edit)
        {
            if (edit.form is Registry)
            {
                Registry registry = edit.form as Registry;
                for (int i = 1; i < 5; i++)
                {
                    if (edit.menu != MenuFile.clean)
                        registry.filter[i, registry.filter.CurrentRow.Index].Value = edit.edit[i].Text;
                    else
                        registry.filter[i, registry.filter.CurrentRow.Index].Value = String.Empty;
                }
            }
        }

        private void formData(Registry registry)
        {
            //
            //сортировка в реестре
            //
            List<int> order_by = new List<int>();
            for (int i = 1; i < registry.filter.RowCount + 1; i++)
            {
                if ((String)registry.filter[3, i - 1].Value == FormText.edit[4])
                    order_by.Add(-i);
                if ((String)registry.filter[3, i - 1].Value == FormText.edit[5])
                    order_by.Add(i);
            }
            registry.registry.DataSource = null;
            registry.registry.DataSource = SqlData.GetArrayList(registry, null, null, order_by);
            //
            //фильтр реестра
            //
            List<int> list2 = new List<int>();
            for (int i = 1; i < registry.filter.RowCount + 1; i++)
                if ((String)registry.filter[3, i - 1].Value == FormText.edit[4])
                    order_by.Add(-i);
            //
            //содержит в реестре
            //


            //
            //количество строк в фильтре
            //
            registry.filter.RowCount = registry.registry.ColumnCount;
            //
            //видимость колонок в реестре
            //
            for (int i = 0; i < registry.registry.ColumnCount; i++)
            {
                if ((String)registry.filter[1, i].Value == FormText.edit[3])
                    registry.registry.Columns[i].Visible = true;
                else
                    registry.registry.Columns[i].Visible = false;
            }
        }

        private void formData(Settings settings)
        {
            //
            //списки настроек
            //
            int j = 0;
            if (settings.typeForm == TypeForm.application)
            {
                settings.left.Columns[0].HeaderText = FormText.name[11];
                settings.left.RowCount = 11;
                settings.left.Rows[j++].Cells[0].Value = FormText.application[3];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[5];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[6];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[9];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[10];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[11];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[12];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[19];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[20];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[26];
                settings.left.Rows[j++].Cells[0].Value = FormText.application[24];
            }
            if (settings.typeForm == TypeForm.specification)
            {
                settings.left.Columns[0].HeaderText = FormText.name[12];
                settings.left.RowCount = 3;
                settings.left.Rows[j++].Cells[0].Value = FormText.specification[24];
                settings.left.Rows[j++].Cells[0].Value = FormText.specification[25];
                settings.left.Rows[j++].Cells[0].Value = FormText.specification[37];
            }
            if (settings.typeForm == TypeForm.engraving)
            {
                settings.left.Columns[0].HeaderText = FormText.name[13];
                settings.left.RowCount = 4;
                settings.left.Rows[j++].Cells[0].Value = FormText.engraving[31];
                settings.left.Rows[j++].Cells[0].Value = FormText.engraving[30];
                settings.left.Rows[j++].Cells[0].Value = FormText.engraving[32];
                settings.left.Rows[j++].Cells[0].Value = FormText.engraving[26];
            }
            if (settings.typeForm == TypeForm.printing)
            {
                settings.left.Columns[0].HeaderText = FormText.name[14];
                settings.left.RowCount = 7;
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[1];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[14];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[27];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[2];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[24];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[18];
                settings.left.Rows[j++].Cells[0].Value = FormText.printing[22];
            }            
        }

        private void formData(Edit edit)
        {
            if (edit.form is Settings)
            {
                Settings settings = edit.form as Settings;
                for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                {
                    if (edit.menu != MenuFile.add)
                        edit.edit[i].Text = settings.right[i + 1, settings.right.CurrentRow.Index].Value.ToString();
                    if (edit.menu == MenuFile.clean)
                        edit.edit[i].Enabled = false;
                }
            }
            if (edit.form is Registry)
            {
                Registry registry = edit.form as Registry;
                string column = String.Format("Column{0}", registry.filter.CurrentRow.Index + 1);
                ControlData.comboBox((ComboBox)edit.edit[1], FormText.edit[0]);
                ControlData.comboBox((ComboBox)edit.edit[1], FormText.edit[3]);
                ControlData.comboBox((ComboBox)edit.edit[2], SqlData.GetDataTable(registry, column), column);
                ControlData.comboBox((ComboBox)edit.edit[3], FormText.edit[0]);
                ControlData.comboBox((ComboBox)edit.edit[3], FormText.edit[4]);
                ControlData.comboBox((ComboBox)edit.edit[3], FormText.edit[5]);
                for (int i = 0; i < 5; i++)
                {
                    if (edit.edit[i] is ComboBox)
                    {
                        ComboBox comboBox = edit.edit[i] as ComboBox;
                        comboBox.SelectedIndex = comboBox.FindString((String)registry.filter.CurrentRow.Cells[i].Value);
                    }
                    else
                        edit.edit[i].Text = (String)registry.filter.CurrentRow.Cells[i].Value;
                    if (edit.menu == MenuFile.clean)
                        edit.edit[i].Enabled = false;
                }
            }
        }
    }
}

