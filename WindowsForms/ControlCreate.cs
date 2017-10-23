using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace WindowsForms
{       
    class ControlCreate
    {
        ControlType control = new ControlType();

        public ControlCreate(Form form)
        {
            if (form is Document)
            {
                Document document = form as Document;
                if (document.typeForm == TypeForm.application)
                    application(document);
                if (document.typeForm == TypeForm.specification)
                    specification(document);
                if (document.typeForm == TypeForm.engraving)
                    engraving(document);
                if (document.typeForm == TypeForm.printing)
                    printing(document);
            }
            if (form is Registry)
                registry(form as Registry);
            if (form is Settings)
                settings(form as Settings);
            if (form is Edit)
                edit(form as Edit);
        }

        private void application(Document form)
        {
            //
            //создание заголовков
            //
            int number = 0;
            for (int i = 0; i < 37; i++)
                form.name.Add(control.label(number++));
            //
            //создание контролов save
            //
            number = 0;
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            for (int i = 0; i < 14; i++)
                form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.dateTimePicker(number++));
            //
            //создание контролов load
            //
            number = 0;
            form.load.Add(control.textBox(number++, false));
            for (int i = 0; i < 36; i++)
                form.load.Add(control.textBox(number++, true));        
        }

        private void specification(Document form)
        {
            //
            //создание заголовков
            //
            int number = 0;
            for (int i = 0; i < 31; i++)
                form.name.Add(control.label(number++));
            //
            //создание контролов save
            //
            number = 0;
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.dateTimePicker(number++));
            for (int i = 0; i < 6; i++)
                form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.dateTimePicker(number++));
            form.save.Add(control.textBox(number++, false));
            for (int i = 0; i < 6; i++)
                form.save.Add(control.textBox(number++, true));
            for (int i = 0; i < 40; i++)
                form.save.Add(control.textBox(number++, true));
            for (int i = 0; i < 10; i++)
                form.save.Add(control.comboBox(number++));
            //
            //создание контролов load
            //
            number = 0;
            form.load.Add(control.textBox(number++, false));
            for (int i = 0; i < 71; i++)
                form.load.Add(control.textBox(number++, true));
        }

        private void engraving(Document form)
        {
            //
            //создание заголовков
            //
            int number = 0;
            for (int i = 0; i < 69; i++)
                form.name.Add(control.label(number++));
            //
            //создание контролов save
            //
            number = 0;
            form.save.Add(control.textBox(number++, false));   
            form.save.Add(control.dateTimePicker(number++));
            for (int i = 0; i < 7; i++)
                form.save.Add(control.textBox(number++, true));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.textBox(number++, false));
            for (int i = 0; i < 8; i++)
                form.save.Add(control.textBox(number++, true));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 10; i++)
                form.save.Add(control.textBox(number++, true));
            for (int i = 0; i < 40; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 60; i++)
                form.save.Add(control.textBox(number++, true));
            for (int i = 0; i < 20; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 20; i++)
            {
                form.save.Add(control.textBox(number++, true));
                form.save.Add(control.textBox(number++, false));
            }
            for (int i = 0; i < 5; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 20; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 30; i++)
                form.save.Add(control.textBox(number++, true));
            for (int i = 0; i < 10; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 10; i++)
            {
                form.save.Add(control.textBox(number++, true));
                form.save.Add(control.textBox(number++, false));
            }
            for (int i = 0; i < 5; i++)
                form.save.Add(control.textBox(number++, false));
            //
            //создание контролов load
            //
            number = 0;
            form.load.Add(control.textBox(number++, false));
            for (int i = 0; i < 289; i++)
                form.load.Add(control.textBox(number++, true));           
        }

        private void printing(Document form)
        {
            //
            //создание заголовков
            //
            int number = 0;
            for (int i = 0; i < 51; i++)
                form.name.Add(control.label(number++));
            //
            //создание контролов save
            //
            number = 0;
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.dateTimePicker(number++));
            for (int i = 0; i < 4; i++)
                form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 8; i++)
                form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));            
            form.save.Add(control.textBox(number++, true));
            form.save.Add(control.comboBox(number++));
            form.save.Add(control.textBox(number++, false));
            form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 22; i++)
                form.save.Add(control.comboBox(number++));
            for (int i = 0; i < 10; i++)
            {
                form.save.Add(control.textBox(number++, true));
                form.save.Add(control.textBox(number++, true));
                for (int j = 0; j < 22; j++)
                    form.save.Add(control.textBox(number++, false));
                form.save.Add(control.textBox(number++, true));
                form.save.Add(control.textBox(number++, true));
                form.save.Add(control.textBox(number++, true));
            }
            //
            //создание контролов load
            //
            number = 0;
            form.load.Add(control.textBox(number++, false));
            for (int i = 0; i < 606; i++)
                form.load.Add(control.textBox(number++, true));
        }

        private void registry(Registry form)
        {
            form.filter = control.dataGridView(5);
            form.filter.Visible = false;
            form.registry = control.dataGridView();
            form.Controls.Add(form.registry);
            form.Controls.Add(form.filter);
        }

        private void settings(Settings form)
        {
            form.left = control.dataGridView(1);            
            form.right = control.dataGridView();
        }

        private void edit(Edit edit)
        {
            int number = 0;
            if (FormType.mdiParent.ActiveMdiChild is Settings)
            {
                Settings settings = (Settings)FormType.mdiParent.ActiveMdiChild;
                for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                    edit.name.Add(control.label(number++));
                number = 0;
                for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                    edit.edit.Add(control.textBox(number++));
            }
            if (FormType.mdiParent.ActiveMdiChild is Registry)
            {
                Registry registry = (Registry)FormType.mdiParent.ActiveMdiChild;
                for (int i = 0; i < 5; i++)
                    edit.name.Add(control.label(number++));
                number = 0;
                for (int i = 0; i < 4; i++)
                {
                    ComboBox comboBox = control.comboBox(number++);
                    comboBox.Margin = new Padding(3, 1, 3, 1);
                    edit.edit.Add(comboBox);
                }
                edit.edit.Add(control.textBox(number++));
            }
            edit.button.Add(control.button(AnchorStyles.Right));
            edit.button.Add(control.button(AnchorStyles.Left));
        }
    }
}
