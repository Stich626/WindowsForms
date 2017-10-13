using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ControlData
    {
        SqlQuery sqlQuery = new SqlQuery();
        private Form form;

        public ControlData(Form Form)
        {
            form = Form;
            //if (form is Registry)
            //   
            if (form is Settings)
                settings((Settings)form);
        }

        private void settings(Settings settings)
        {
            int i = 0;
            if (settings.typeForm == TypeForm.application)
            {
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
                settings.left.RowCount = 3;
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[4];
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[25];
                settings.left.Rows[i++].Cells[0].Value = TextType.specification[26];
            }
        }

        public ControlData(Settings settings)
        {
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
            }
            if (settings.typeForm == TypeForm.specification)
            {
                switch (settings.left.CurrentRow.Index)
                {
                    case 0: table = SqlSpecification.SpecificationParametersWorkpiece.ToString(); break;
                    case 1: table = SqlSpecification.SpecificationPrametryMachining.ToString(); break;
                    case 2: table = SqlSpecification.SpecificationRotationalSpeed.ToString(); break;
                }
            }
            settings.right.DataSource = null;
            settings.right.DataSource = sqlQuery.GetArrayList(table);
            settings.right.Columns[0].Visible = false;
        }
    }
}

