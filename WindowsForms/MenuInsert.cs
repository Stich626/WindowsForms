using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    enum MenuBar { file, document, registry, view, settings, window }
    enum MenuFile { save, print, fill, delete, filter, open, add, edit, clean }
    enum MenuView { vertically, cascade, horizontally }

    class MenuInsert
    {
        MenuType menu = new MenuType();

        public MenuInsert(Main form)
        {
            //
            //строка меню
            //
            form.menu = menu.stripMenu();
            form.item.Add(menu.toolStripMenu(MenuBar.file, form.menu));
            form.item.Add(menu.toolStripMenu(MenuBar.document, form.menu));
            form.item.Add(menu.toolStripMenu(MenuBar.registry, form.menu));
            form.item.Add(menu.toolStripMenu(MenuBar.view, form.menu));
            form.item.Add(menu.toolStripMenu(MenuBar.settings, form.menu));
            form.item.Add(menu.toolStripMenu(MenuBar.window, form.menu));
            //
            //меню
            //
            for (int i = 0; i < form.item.Count; i++)
            {
                if (form.item[i].Name == MenuBar.window.ToString())
                    form.menu.MdiWindowListItem = form.item[i];
                if (form.item[i].Name == MenuBar.file.ToString())
                {
                    form.item.Add(menu.toolStripMenu(MenuFile.save, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.print, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.fill, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.delete, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.filter, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.open, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.add, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.edit, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuFile.clean, form.item[i]));
                }
                if (form.item[i].Name == MenuBar.document.ToString())
                {
                    form.item.Add(menu.toolStripMenu(TypeForm.application, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.specification, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.engraving, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.printing, form.item[i]));
                }
                if (form.item[i].Name == MenuBar.registry.ToString())
                {
                    form.item.Add(menu.toolStripMenu(TypeForm.application, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.specification, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.engraving, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.printing, form.item[i]));
                }
                if (form.item[i].Name == MenuBar.view.ToString())
                {
                    form.item.Add(menu.toolStripMenu(MenuView.vertically, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuView.cascade, form.item[i]));
                    form.item.Add(menu.toolStripMenu(MenuView.horizontally, form.item[i]));
                }
                if (form.item[i].Name == MenuBar.settings.ToString())
                {
                    form.item.Add(menu.toolStripMenu(TypeForm.application, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.specification, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.engraving, form.item[i]));
                    form.item.Add(menu.toolStripMenu(TypeForm.printing, form.item[i]));
                }
            }
            //
            //панель инструментов
            //
            form.tool = menu.stripTool();
            form.button.Add(menu.toolStripButton(TypeForm.application, MenuBar.document, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.specification, MenuBar.document, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.engraving, MenuBar.document, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.printing, MenuBar.document, form.tool));
            menu.toolStripSeparator(form.tool);
            form.button.Add(menu.toolStripButton(TypeForm.application, MenuBar.registry, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.specification, MenuBar.registry, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.engraving, MenuBar.registry, form.tool));
            form.button.Add(menu.toolStripButton(TypeForm.printing, MenuBar.registry, form.tool));
            menu.toolStripSeparator(form.tool);
            form.button.Add(menu.toolStripButton(MenuFile.save, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.print, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.fill, form.tool));
            menu.toolStripSeparator(form.tool);
            form.button.Add(menu.toolStripButton(MenuFile.delete, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.filter, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.open, form.tool));
            menu.toolStripSeparator(form.tool);
            form.button.Add(menu.toolStripButton(MenuFile.add, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.edit, form.tool));
            form.button.Add(menu.toolStripButton(MenuFile.clean, form.tool));
            menu.toolStripSeparator(form.tool);
            form.button.Add(menu.toolStripButton(MenuView.vertically, form.tool));
            form.button.Add(menu.toolStripButton(MenuView.cascade, form.tool));
            form.button.Add(menu.toolStripButton(MenuView.horizontally, form.tool));
            menu.toolStripSeparator(form.tool);
            //
            //картинки кнопок
            //
            for (int i = 0; i < form.button.Count; i++)
            {
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    form.button[i].Image = Properties.Resources.ApplicationForm;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    form.button[i].Image = Properties.Resources.SpecificationForm;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    form.button[i].Image = Properties.Resources.EngravingForm;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    form.button[i].Image = Properties.Resources.TrialPrintingForm;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    form.button[i].Image = Properties.Resources.ApplicationRegistry;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    form.button[i].Image = Properties.Resources.SpecificationRegistry;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    form.button[i].Image = Properties.Resources.EngravingRegistry;
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    form.button[i].Image = Properties.Resources.TrialPrintingRegistry;
                if (form.button[i].Name == MenuView.vertically.ToString())
                    form.button[i].Image = Properties.Resources.Vertical;
                if (form.button[i].Name == MenuView.cascade.ToString())
                    form.button[i].Image = Properties.Resources.Cascade;
                if (form.button[i].Name == MenuView.horizontally.ToString())
                    form.button[i].Image = Properties.Resources.Horizontal;
                if (form.button[i].Name == MenuFile.save.ToString())
                    form.button[i].Image = Properties.Resources.Save;
                if (form.button[i].Name == MenuFile.print.ToString())
                    form.button[i].Image = Properties.Resources.Print;
                if (form.button[i].Name == MenuFile.fill.ToString())
                    form.button[i].Image = Properties.Resources.Fill;
                if (form.button[i].Name == MenuFile.delete.ToString())
                    form.button[i].Image = Properties.Resources.Dell;
                if (form.button[i].Name == MenuFile.filter.ToString())
                    form.button[i].Image = Properties.Resources.Filter;
                if (form.button[i].Name == MenuFile.open.ToString())
                    form.button[i].Image = Properties.Resources.Open;
                if (form.button[i].Name == MenuFile.add.ToString())
                    form.button[i].Image = Properties.Resources.Add;
                if (form.button[i].Name == MenuFile.edit.ToString())
                    form.button[i].Image = Properties.Resources.Edit;
                if (form.button[i].Name == MenuFile.clean.ToString())
                    form.button[i].Image = Properties.Resources.Clean;
            }
            form.Controls.Add(form.tool);
            form.Controls.Add(form.menu);
        }
    }
}
