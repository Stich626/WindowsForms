using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class FormInspector 
    {
        private List<Object> load;
        private List<Object> save;
        private List<Object> sql = new List<object>();
        private Control controlSave;
        private TextBox controlLoad;
        private string sqlText;

        FormInspector(List<Object> Load, List<Object> Save)
        {
            load = Load;
            save = Save;
        }
        
        public void inspector()
        {
            for (int i = 0; i < save.Count; i++)
            {
                controlSave = (Control)save[i];
                controlLoad = (TextBox)load[i];
                if (controlSave.Text != controlLoad.Text)
                    controlLoad.BackColor = Color.Red;
                else
                {
                    if (controlLoad.ReadOnly)
                        controlLoad.BackColor = SystemColors.Control;
                    else
                        controlLoad.BackColor = SystemColors.Window;
                }
            }
        }

        public bool inspectorSave()
        {
            bool result = true;
            for (int i = 0; i < save.Count; i++)
            {
                controlSave = (Control)save[i];
                //
                //запрос из б/д
                //
                sqlText = String.Empty;
                if (controlSave.Text != controlLoad.Text)
                {
                    result = false;
                    break;
                }
                else
                {
                    if (controlLoad.ReadOnly)
                        controlLoad.BackColor = SystemColors.Control;
                    else
                        controlLoad.BackColor = SystemColors.Window;
                }
            }
            return result;
        }

        public void inspector(int[] number)
        {
            for (int i = 0; i < save.Count; i++)
                for (int j = 0; j < number.Length; j++)
                    if (i == number[j])
                    {
                        controlSave = (Control)save[i];
                        controlLoad = (TextBox)load[i];
                        if (controlSave.Text != controlLoad.Text)
                            controlLoad.BackColor = Color.Red;
                        else
                        {
                            if (controlLoad.ReadOnly)
                                controlLoad.BackColor = SystemColors.Control;
                            else
                                controlLoad.BackColor = SystemColors.Window;
                        }
                    }
        }

        public void inspector(int number)
        {
            controlSave = (Control)save[number];
            controlLoad = (TextBox)load[number];
            if (controlSave.Text != controlLoad.Text)
                controlLoad.BackColor = Color.Red;
            else
            {
                if (controlLoad.ReadOnly)
                    controlLoad.BackColor = SystemColors.Control;
                else
                    controlLoad.BackColor = SystemColors.Window;
            }
        }
    }
}
