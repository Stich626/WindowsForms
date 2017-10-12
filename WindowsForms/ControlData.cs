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
        public ControlData(Form form)
        {
            if (form is Registry)
            {
                Registry registry = (Registry)form;
            }

            if (form is Settings)
            {
                Settings settings = form as Settings;
                if (settings.typeForm == TypeForm.application)
                {
                    settings.left.Rows[0].Cells[0].Value = TextType.application[2];
                    settings.left.Rows[1].Cells[0].Value = TextType.application[4];
                    settings.left.Rows[2].Cells[0].Value = TextType.application[5];
                    settings.left.Rows[3].Cells[0].Value = TextType.application[8];
                    settings.left.Rows[4].Cells[0].Value = TextType.application[9];
                    settings.left.Rows[5].Cells[0].Value = TextType.application[10];
                    settings.left.Rows[6].Cells[0].Value = TextType.application[14];
                    settings.left.Rows[7].Cells[0].Value = TextType.application[18];
                    settings.left.Rows[8].Cells[0].Value = TextType.application[19];
                    settings.left.Rows[9].Cells[0].Value = TextType.application[1];
                    settings.left.Rows[10].Cells[0].Value = TextType.application[1];
                }
            }



            //int number = 0;
            //for (int i = 0; i < TextType.application.Length; i++)
            //{
            //    form.filter.Rows.Add();
            //    form.filter[0, number].Value = TextType.application[number++];
            //    for (int i = 0; i < form.filter.Columns.Count; i++)
            //        form.filter.Columns[i].HeaderText = TextType.filter[i];
            //}



        }
    }
}
