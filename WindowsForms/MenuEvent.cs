using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class MenuEvent
    {
        public MenuEvent(Main form)
        {
            for (int i = 0; i < form.item.Count; i++)
                form.item[i].Click += new EventHandler(menu_Click);
            for (int i = 0; i < form.button.Count; i++)
                form.button[i].Click += new EventHandler(menu_Click);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            string name = null;
            ToolStripMenuItem toolStripMenuItem = null;
            ToolStripButton toolStripButton = null;
            if (sender is ToolStripMenuItem)
            {
                toolStripMenuItem = (ToolStripMenuItem)sender;
                name = toolStripMenuItem.Name;
            }
            if (sender is ToolStripButton)
            {
                toolStripButton = (ToolStripButton)sender;
                name = toolStripButton.Name;
            }
            //
            //создание форм
            //
            if (name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                new Document(TypeForm.application).Show();
            if (name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                new Document(TypeForm.specification).Show();
            if (name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                new Document(TypeForm.engraving).Show();
            if (name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                new Document(TypeForm.printing).Show();
            if (name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                new Registry(TypeForm.application).Show();
            if (name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                new Registry(TypeForm.specification).Show();
            if (name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                new Registry(TypeForm.engraving).Show();
            if (name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                new Registry(TypeForm.printing).Show();
            if (name == String.Format("{0}{1}", TypeForm.main, MenuBar.settings))
                settings(TypeForm.main);
            if (name == String.Format("{0}{1}", TypeForm.application, MenuBar.settings))
                settings(TypeForm.application);
            if (name == String.Format("{0}{1}", TypeForm.specification, MenuBar.settings))
                settings(TypeForm.specification);
            if (name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.settings))
                settings(TypeForm.engraving);
            if (name == String.Format("{0}{1}", TypeForm.printing, MenuBar.settings))
                settings(TypeForm.printing);
            if (FormType.mdiParent.ActiveMdiChild is Settings)
            {
                //Settings settings = FormType.mdiParent.ActiveMdiChild as Settings;
                if (name == String.Format("{0}", MenuFile.add))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.add).ShowDialog();
                if (name == String.Format("{0}", MenuFile.clean))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.clean).ShowDialog();
                if (name == String.Format("{0}", MenuFile.edit))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.edit).ShowDialog();
            }
            if (FormType.mdiParent.ActiveMdiChild is Registry)
            {
                Registry registry = FormType.mdiParent.ActiveMdiChild as Registry;
                if (name == String.Format("{0}", MenuFile.filter))
                {
                    //
                    //видимость контролов
                    //
                    registry.filterOn = true;
                    registry.registry.Visible = false;
                    registry.filter.Visible = true;
                    new MenuVisible(registry);
                    new FormText(registry);
                }
                if (name == String.Format("{0}", MenuFile.add))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.add).ShowDialog();
                if (name == String.Format("{0}", MenuFile.clean))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.clean).ShowDialog();
                if (name == String.Format("{0}", MenuFile.edit))
                    new Edit(FormType.mdiParent.ActiveMdiChild, MenuFile.edit).ShowDialog();
            }
            //
            //расположение форм
            //
            if (name == MenuView.horizontally.ToString())
                new FormSize(MenuView.horizontally);
            if (name == MenuView.cascade.ToString())
                new FormSize(MenuView.cascade);
            if (name == MenuView.vertically.ToString())
                new FormSize(MenuView.vertically);
        }

        private void settings(TypeForm type)
        {
            bool flag = true;
            for (int i = 0; i < FormType.mdiParent.MdiChildren.Length; i++)
                if (FormType.mdiParent.MdiChildren[i] is Settings)
                {
                    Settings settings = (Settings)FormType.mdiParent.MdiChildren[i];
                    if (settings.typeForm == type)
                    {
                        settings.Activate();
                        flag = false;
                    }
                }
            if (flag)
                new Settings(type).Show();
        }
    }
}
