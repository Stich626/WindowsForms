using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ControlEvent
    {
        private Settings settings = null;
        private Edit edit = null;

        public ControlEvent(Form form)
        {
            if (form is Settings)
            {
                settings = form as Settings;
                settings.left.CellEnter += new DataGridViewCellEventHandler(dataGridView_CellEnter);
            }
            if (form is Edit)
            {
                edit = form as Edit;
                if (edit.bar == MenuBar.registry)
                {
                    ComboBox comboBox = (ComboBox)edit.edit[0];
                    comboBox.SelectionChangeCommitted += new EventHandler(comboBox_SelectionChangeCommitted);
                }
            }
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (settings != null)
                new FormData(settings);
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(edit != null)
                new FormData(edit);
        }
    }
}
