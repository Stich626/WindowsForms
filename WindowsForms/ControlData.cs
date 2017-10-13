using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class settingsData
    {
        SqlQuery sqlQuery = new SqlQuery();
        private Form form;

        public settingsData(Form Form)
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
                settings.left.Columns[0].HeaderText = TextType.name[10];
                settings.left.RowCount = 11;
                settings.left.Rows[i++].Cells[0].Value = TextType.application[2];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[4];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[5];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[8];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[9];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[10];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[14];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[18];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[19];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[25];
                settings.left.Rows[i++].Cells[0].Value = TextType.application[23];
            }
            if (settings.typeForm == TypeForm.specification)
            {
                settings.left.Columns[0].HeaderText = TextType.name[11];
                settings.left.RowCount = 3;
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[4];
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[24];
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[25];
            }
            if (settings.typeForm == TypeForm.engraving)
            {
                settings.left.Columns[0].HeaderText = TextType.name[11];
                settings.left.RowCount = 3;
                settings.left.Rows[i++].Cells[0].Value = TextType.engraving[4];
                settings.left.Rows[i++].Cells[0].Value = TextType.engraving[24];
                settings.left.Rows[i++].Cells[0].Value = TextType.engraving[25];
            }
        }

        public settingsData(Settings settings)
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
                if (table == SqlSpecification.SpecificationParametersWorkpiece.ToString() ||
                    table == SqlSpecification.SpecificationPrametryMachining.ToString())
                {
                    for (int i = 0; i < settings.right.Columns.Count; i++)
                        if (i != 1)
                            settings.right.Columns[i].Visible = false;
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                    settings.right.Columns[1].HeaderText = (string)settings.left.CurrentRow.Cells[0].Value;
                }
                if (table == SqlSpecification.SpecificationRotationalSpeed.ToString())
                {
                    settings.right.Columns[0].Visible = false;
                    settings.right.Columns[1].HeaderText = TextType.specification[37];
                    settings.right.Columns[2].HeaderText = TextType.specification[37];
                    settings.right.Columns[3].HeaderText = TextType.specification[38];
                    settings.right.DataSource = sqlQuery.GetArrayList(table);
                }
            }
        }
    }
}

