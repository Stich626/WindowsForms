using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    class FormLogic
    {
        public FormLogic(Registry registry)
        {
            string table = String.Empty;
            switch (registry.typeForm)
            {
                case TypeForm.application: table = SqlApplication.ApplicationRegister.ToString(); break;
                case TypeForm.specification: table = SqlSpecification.SpecificationRegistry.ToString(); break;
                case TypeForm.engraving: table = SqlEngraving.EngravingRegister.ToString(); break;
                case TypeForm.printing: table = SqlPrinting.TrialPrintingRegister.ToString(); break;
            }

            List<int> column1 = new List<int>();
            //List<int> column2 = new List<int>();
            for (int i = 0; i < registry.filter.RowCount; i++)
            {
                if ((String)registry.filter[3, i].Value == FormText.edit[4])
                    column1.Add(i);
                //    if ((String)registry.filter[3, i].Value == FormText.edit[5])
                //        column2.Add(i);
            }
            registry.registry.DataSource = null;
            registry.registry.DataSource = SqlData.GetArrayList(table, column1);

            for (int i = 0; i < registry.registry.ColumnCount; i++)
            {
                if ((String)registry.filter[1, i].Value == FormText.edit[3])
                    registry.registry.Columns[i].Visible = true;
                else
                    registry.registry.Columns[i].Visible = false;
            }
        }
    }
}
