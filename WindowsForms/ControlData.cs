using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ControlData
    {
        public static void comboBox(ComboBox comboBox, ArrayList arrayList)
        {
            comboBox.DataSource = arrayList;
        }
        public static void comboBox(ComboBox comboBox, DataTable dataTable, string column)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = column;
        }
    }
}
