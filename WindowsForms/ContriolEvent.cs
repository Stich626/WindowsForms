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
                //if (edit.bar == MenuBar.registry)
                //{
                //Label label = (Label)edit.edit[0];
                //comboBox.SelectionChangeCommitted += new EventHandler(comboBox_SelectionChangeCommitted);
                //}
                edit.button[0].Click += new EventHandler(buttonRight_Click);
                edit.button[1].Click += new EventHandler(buttonLeft_Click);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            edit.Close();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            new FormData(edit);
            edit.Close();       
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (settings != null)
                new FormData(settings);
        }

        //private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if(edit != null)
        //        new DataForm(edit);
        //}
    }
}
