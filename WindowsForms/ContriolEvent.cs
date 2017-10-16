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

        public ControlEvent(Form form)
        {
            if (form is Settings)
            {
                settings = form as Settings;
                settings.left.CellEnter += new DataGridViewCellEventHandler(DataGridView_CellEnter);
            }
        }

        private void DataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (settings != null)
                new FormData(settings);
        }
    }
}
