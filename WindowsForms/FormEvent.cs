using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class FormEvent
    {
        private Settings settings;
        private Edit edit;

        public FormEvent(Form form)
        {
            if (form is Main)
                new MenuEvent((Main)form);
            if (form is Settings)
            {
                settings = form as Settings;
                settings.left.CellEnter += new DataGridViewCellEventHandler(dataGridView_CellEnter);
            }
            if (form is Edit)
            {
                edit = form as Edit;
                edit.button[0].Click += new EventHandler(buttonRight_Click);
                edit.button[1].Click += new EventHandler(buttonLeft_Click);
            }
            form.Load += new EventHandler(load);
            form.Shown += new EventHandler(shown);
            form.Activated += new EventHandler(activated);
            form.VisibleChanged += new EventHandler(visible);
            form.FormClosing += new FormClosingEventHandler(closing);
            form.FormClosed += new FormClosedEventHandler(closed);
        }

        private void load(object sender, EventArgs e)
        {
            if (sender is Registry)
            {
                //
                //фильтр по умолчанию
                //
                Registry registry = sender as Registry;
                registry.filter[1, 0].Value = FormText.edit[3];
                registry.filter[1, 3].Value = FormText.edit[3];
                registry.filter[3, 0].Value = FormText.edit[5];
                //
                //применить фильтр по умолчанию
                //
                new FormData((Form)sender);
                new FormText((Form)sender);
            }
        }

        private void visible(object sender, EventArgs e)
        {
            new MenuVisible(FormType.mdiParent.ActiveMdiChild);
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            new MenuVisible(FormType.mdiParent);
        }

        private void shown(object sender, EventArgs e)
        {
            new FormSize(sender);
            if (sender is Main)
                new MenuVisible(FormType.mdiParent);
            else
                new MenuVisible(FormType.mdiParent.ActiveMdiChild);
            if (sender is Edit)
                new MenuVisible((Edit)sender);
        }

        private void activated(object sender, EventArgs e)
        {
            new MenuVisible(FormType.mdiParent.ActiveMdiChild);
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            if (sender is Registry)
            {
                Registry registry = sender as Registry;
                if (registry.filterOn)
                {
                    e.Cancel = true;
                    registry.filterOn = false;
                    registry.filter.Visible = false;
                    registry.registry.Visible = true;
                    new MenuVisible(registry);
                    new FormData(registry);
                    new FormText(registry);
                }
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
    }
}
