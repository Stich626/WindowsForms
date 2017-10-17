using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class FormData
    {
        SqlQuery sqlQuery = new SqlQuery();
        private Form form;

        public FormData(Form Form)
        {
            form = Form;
            //if (form is Registry)
            //   
            if (form is Settings)
                settingsText((Settings)form);
        }

        private void settingsText(Settings settings)
        {
            int i = 0;
            if (settings.typeForm == TypeForm.application)
            {
                settings.left.Columns[0].HeaderText = FormText.name[12];
                settings.left.RowCount = 11;
                settings.left.Rows[i++].Cells[0].Value = FormText.application[3];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[5];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[6];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[9];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[10];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[11];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[12];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[19];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[20];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[26];
                settings.left.Rows[i++].Cells[0].Value = FormText.application[24];
            }
            if (settings.typeForm == TypeForm.specification)
            {
                settings.left.Columns[0].HeaderText = FormText.name[13];
                settings.left.RowCount = 3;
                settings.left.Rows[i++].Cells[0].Value = FormText.specification[24];
                settings.left.Rows[i++].Cells[0].Value = FormText.specification[25];
                settings.left.Rows[i++].Cells[0].Value = FormText.specification[37];
            }
            if (settings.typeForm == TypeForm.engraving)
            {
                settings.left.Columns[0].HeaderText = FormText.name[13];
                settings.left.RowCount = 4;
                settings.left.Rows[i++].Cells[0].Value = FormText.engraving[31];
                settings.left.Rows[i++].Cells[0].Value = FormText.engraving[30];
                settings.left.Rows[i++].Cells[0].Value = FormText.engraving[32];
                settings.left.Rows[i++].Cells[0].Value = FormText.engraving[26];
            }
        }

        public FormData(Settings settings)
        {
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
                settings.right.DataSource = sqlQuery.GetArrayList(table);
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
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
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
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                    for (int i = 0; i < settings.right.Columns.Count; i++)
                        if (i != 1 && i != 3 && i != 8 && i != 10 && i != 14)
                            settings.right.Columns[i].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[3].HeaderText = String.Format("{0} {1}",  FormText.specification[29], FormText.specification[26]);
                    settings.right.Columns[8].HeaderText = String.Format("{0} {1}", FormText.specification[36], FormText.specification[27]);
                    settings.right.Columns[10].HeaderText = FormText.specification[26];
                    settings.right.Columns[14].HeaderText = FormText.specification[27];
                }
                if (table == SqlSpecification.SpecificationRotationalSpeed.ToString())
                {
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
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
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                }
                if (table == SqlEngraving.EngravingCode.ToString())
                {
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    for(int i = 0; i < 5; i++)
                        settings.right.Columns[i + 2].HeaderText = FormText.engraving[i + 33];
                    settings.right.Columns[7].HeaderText = FormText.engraving[39];
                }
                if (table == SqlEngraving.EngravingTime.ToString())
                {
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                    settings.right.Columns[2].HeaderText = FormText.engraving[50];
                    settings.right.Columns[3].HeaderText = FormText.engraving[2];
                    settings.right.Columns[4].HeaderText = FormText.engraving[3];
                }
            }
        }
    }
}

