using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class MenuVisible
    {
        //
        //видимость пунктов меню, включение и выключения кнопок панели управления
        //
        public MenuVisible(Form form)
        {
            if (form is Edit)
            {
                FormType.mdiParent.menu.Enabled = false;
                FormType.mdiParent.tool.Enabled = false;
            }
            else
            {
                FormType.mdiParent.menu.Enabled = true;
                FormType.mdiParent.tool.Enabled = true;
            }
            for (int i = 0; i < FormType.mdiParent.item.Count; i++)
            {
                if (form is Main)
                {
                    if (FormType.mdiParent.item[i].Name == MenuFile.save.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.print.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.fill.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.open.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.add.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.edit.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.clean.ToString())
                        FormType.mdiParent.item[i].Visible = false;
                    else
                        FormType.mdiParent.item[i].Visible = true;
                }
                if (form is Document)
                {
                    if (FormType.mdiParent.item[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.open.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.add.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.edit.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.clean.ToString())
                        FormType.mdiParent.item[i].Visible = false;
                    else
                        FormType.mdiParent.item[i].Visible = true;
                }
                if (form is Registry)
                {
                    Registry registry = form as Registry;
                    if (registry.filterOn)
                    {
                        if (FormType.mdiParent.item[i].Name == MenuFile.save.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.print.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.fill.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.delete.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.filter.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.open.ToString())
                            FormType.mdiParent.item[i].Visible = false;
                        else
                            FormType.mdiParent.item[i].Visible = true;
                    }
                    else
                    {
                        if (FormType.mdiParent.item[i].Name == MenuFile.save.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.print.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.fill.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.add.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.edit.ToString() ||
                            FormType.mdiParent.item[i].Name == MenuFile.clean.ToString())
                            FormType.mdiParent.item[i].Visible = false;
                        else
                            FormType.mdiParent.item[i].Visible = true;
                    }
                }
                if (form is Settings)
                {
                    if (FormType.mdiParent.item[i].Name == MenuFile.save.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.print.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.fill.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.item[i].Name == MenuFile.open.ToString())
                        FormType.mdiParent.item[i].Visible = false;
                    else
                        FormType.mdiParent.item[i].Visible = true;
                }
            }
            for (int i = 0; i < FormType.mdiParent.button.Count; i++)
            {
                if (form is Main)
                {
                    if (FormType.mdiParent.button[i].Name == MenuFile.save.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.print.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.fill.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.open.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.add.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.edit.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.clean.ToString())
                        FormType.mdiParent.button[i].Enabled = false;
                    else
                        FormType.mdiParent.button[i].Enabled = true;
                }
                if (form is Document)
                {
                    if (FormType.mdiParent.button[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.open.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.add.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.edit.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.clean.ToString())
                        FormType.mdiParent.button[i].Enabled = false;
                    else
                        FormType.mdiParent.button[i].Enabled = true;
                }
                if (form is Registry)
                {
                    Registry registry = form as Registry;
                    if (registry.filterOn)
                    {
                        if (FormType.mdiParent.button[i].Name == MenuFile.save.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.print.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.fill.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.delete.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.filter.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.open.ToString())
                            FormType.mdiParent.button[i].Enabled = false;
                        else
                            FormType.mdiParent.button[i].Enabled = true;
                    }
                    else
                    {
                        if (FormType.mdiParent.button[i].Name == MenuFile.save.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.print.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.fill.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.add.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.edit.ToString() ||
                            FormType.mdiParent.button[i].Name == MenuFile.clean.ToString())
                            FormType.mdiParent.button[i].Enabled = false;
                        else
                            FormType.mdiParent.button[i].Enabled = true;
                    }
                }
                if (form is Settings)
                {
                    if (FormType.mdiParent.button[i].Name == MenuFile.save.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.print.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.fill.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.delete.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.filter.ToString() ||
                        FormType.mdiParent.button[i].Name == MenuFile.open.ToString())
                        FormType.mdiParent.button[i].Enabled = false;
                    else
                        FormType.mdiParent.button[i].Enabled = true;
                }
            }
        }
    }
}
