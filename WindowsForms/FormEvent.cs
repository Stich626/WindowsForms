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
        public FormEvent(Form form)
        {
            if (form is Main)
                new MenuEvent((Main)form);
            form.Activated += new EventHandler(activated);
            form.FormClosing += new FormClosingEventHandler(closing);
            form.FormClosed += new FormClosedEventHandler(closed);
            form.VisibleChanged += new EventHandler(visibleChanged);
            form.Shown += new EventHandler(shown);
        }

        private void visibleChanged(object sender, EventArgs e)
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
            if (sender is Registry)
                new FormLogic((Registry)sender);
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
                    new FormText(registry);
                    new FormLogic(registry);
                }
            }
            //if (sender is FilterEdit)
            //{
            //    e.Cancel = true;
            //    FilterEdit edit = sender as FilterEdit;
            //    edit.Hide();
            //}
        }
    }
}
