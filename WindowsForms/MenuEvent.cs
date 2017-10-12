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
                new Settings(TypeForm.main).Show();
            if (name == String.Format("{0}{1}", TypeForm.application, MenuBar.settings))
                new Settings(TypeForm.application).Show();
            if (name == String.Format("{0}{1}", TypeForm.specification, MenuBar.settings))
                new Settings(TypeForm.specification).Show();
            if (name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.settings))
                new Settings(TypeForm.engraving).Show();
            if (name == String.Format("{0}{1}", TypeForm.printing, MenuBar.settings))
                new Settings(TypeForm.printing).Show();
            if (FormType.mdiParent.ActiveMdiChild is Registry)
            {
                //
                //видимость контролов
                //
                Registry registry = FormType.mdiParent.ActiveMdiChild as Registry;
                if (name == String.Format("{0}", MenuFile.filter))
                {
                    registry.filterOn = true;
                    registry.registry.Visible = false;
                    registry.filter.Visible = true;
                    new MenuVisible(registry);
                    new TextCreate(registry);
                }
                //
                //
                //
                if (name == String.Format("{0}", MenuFile.add))
                    new Edit(registry, MenuFile.add).ShowDialog();
                if (name == String.Format("{0}", MenuFile.clean))
                    new Edit(registry, MenuFile.clean).ShowDialog();
                if (name == String.Format("{0}", MenuFile.edit))
                    new Edit(registry, MenuFile.edit).ShowDialog();
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
    }
}
