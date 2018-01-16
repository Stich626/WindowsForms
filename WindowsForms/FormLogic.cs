using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    class FormLogic
    {
        public FormLogic(Registry form)
        {
            for (int i = 0; i < form.registry.ColumnCount; i++)
            {
                if ((String)form.filter[1, i].Value == FormText.edit[3])
                    form.registry.Columns[i].Visible = true;
                else
                    form.registry.Columns[i].Visible = false;
            }
        }
    }
}
