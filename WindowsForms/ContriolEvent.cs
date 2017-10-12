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
        SqlQuery sqlQuery = new SqlQuery();

        private Settings settings;

        public ControlEvent(Form form)
        {
            if (form is Settings)
            {
                settings = form as Settings;
                settings.left.CellEnter += new DataGridViewCellEventHandler(left_CellEnter);
            }
        }

        private void left_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SqlApplication table = SqlApplication.ApplicationCustomers;
            switch (settings.left.CurrentRow.Index)
            {
                case 0: table = SqlApplication.ApplicationViewWork; break;
                case 1: table = SqlApplication.ApplicationTypeWorks; break;
                case 2: table = SqlApplication.ApplicationCustomers; break;
                case 3: table = SqlApplication.ApplicationProgreso; break;
                case 4: table = SqlApplication.ApplicationDrawing; break;
                case 5: table = SqlApplication.ApplicationPaint; break;
                case 6: table = SqlApplication.ApplicationSubstrates; break;
                case 7: table = SqlApplication.ApplicationColor; break;
                case 8: table = SqlApplication.ApplicationContactCustomers; break;
                case 9: table = SqlApplication.ApplicationContactsKontinent; break;
                case 10: table = SqlApplication.ApplicationWorkpieceLength; break;
            }
            settings.right.DataSource = null;
            settings.right.DataSource = sqlQuery.GetArrayList(table.ToString());
        }
    }
}
