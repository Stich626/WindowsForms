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
                int number = 0;
                for (int i = 0; i < TextType.application.Length; i++)
                {
                    registry.filter.Rows.Add();
                    registry.filter[0, number].Value = TextType.application[number++];
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
