using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class DataType
    {
        public string[] arrEmty(string file, string path)
        {
            string[] arr1 = File.ReadAllLines(String.Format("{0}{1}.txt", path, file));
            string[] arr2 = new string[arr1.Length + 1];
            arr2[0] = String.Empty;
            for (int i = 1; i < arr2.Length; i++)
                arr2[i] = arr1[i - 1];
            return arr2;
        }

        public void comboBoxDistinct(ComboBox comboBox, ArrayList arrayList)
        {
            var varList = arrayList.ToArray().Distinct().ToList();
            comboBox.DataSource = varList;
            comboBox.Text = String.Empty;
        }

        public void comboBox(ComboBox comboBox, ArrayList arrayList)
        {
            comboBox.DataSource = arrayList;
        }
    }
}
