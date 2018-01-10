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

        public static void comboBox(ComboBox comboBox, string item)
        {
            comboBox.Items.Add(item);
            comboBox.SelectedIndex = 0;
        }

        public static void comboBox(ComboBox comboBox, DataTable dataTable, string column)
        {
            bool flag = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if(dataTable.Rows[i].ToString() == String.Empty)
                    flag = true;
            }
            if (!flag)
                dataTable.Rows.InsertAt(dataTable.NewRow(), 0);    
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = column;
            comboBox.SelectedIndex = 0;
        }
    }
}
