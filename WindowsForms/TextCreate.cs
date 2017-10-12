using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class TextCreate
    {
        public TextCreate(Form form)
        {
            textForm(form);
            if (form is Main)
                main((Main)form);
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
        }

        private void textForm(Form form)
        {
            if (form is Main)
            {
                Main main = (Main)form;
                main.Text = TextType.name[0];
            }
            if (form is Document)
            {
                Document document = (Document)form;
                if (document.typeForm == TypeForm.application)
                    document.Text = TextType.name[1];
                if (document.typeForm == TypeForm.specification)
                    document.Text = TextType.name[2];
                if (document.typeForm == TypeForm.engraving)
                    document.Text = TextType.name[3];
                if (document.typeForm == TypeForm.printing)
                    document.Text = TextType.name[4];
            }
            if (form is Registry)
            {
                Registry registry = (Registry)form;
                if (registry.filterOn)
                {
                    if (registry.typeForm == TypeForm.application)
                        registry.Text = TextType.name[14];
                    if (registry.typeForm == TypeForm.specification)
                        registry.Text = TextType.name[15];
                    if (registry.typeForm == TypeForm.engraving)
                        registry.Text = TextType.name[16];
                    if (registry.typeForm == TypeForm.printing)
                        registry.Text = TextType.name[17];
                }
                else
                {
                    if (registry.typeForm == TypeForm.application)
                        registry.Text = TextType.name[5];
                    if (registry.typeForm == TypeForm.specification)
                        registry.Text = TextType.name[6];
                    if (registry.typeForm == TypeForm.engraving)
                        registry.Text = TextType.name[7];
                    if (registry.typeForm == TypeForm.printing)
                        registry.Text = TextType.name[8];
                }
            }
            if (form is Settings)
            {
                Settings settings = (Settings)form;
                if (settings.typeForm == TypeForm.main)
                    settings.Text = TextType.name[9];
                if (settings.typeForm == TypeForm.application)
                    settings.Text = TextType.name[10];
                if (settings.typeForm == TypeForm.specification)
                    settings.Text = TextType.name[11];
                if (settings.typeForm == TypeForm.engraving)
                    settings.Text = TextType.name[12];
                if (settings.typeForm == TypeForm.printing)
                    settings.Text = TextType.name[13];
            }
        }

        private void main(Main form)
        {
            for (int i = 0; i < form.item.Count; i++)
            {
                if (form.item[i].Name == MenuBar.file.ToString())
                    form.item[i].Text = TextType.main[0];
                if (form.item[i].Name == MenuBar.document.ToString())
                    form.item[i].Text = TextType.main[1];
                if (form.item[i].Name == MenuBar.registry.ToString())
                    form.item[i].Text = TextType.main[2];
                if (form.item[i].Name == MenuBar.view.ToString())
                    form.item[i].Text = TextType.main[3];
                if (form.item[i].Name == MenuBar.settings.ToString())
                    form.item[i].Text = TextType.main[4];
                if (form.item[i].Name == MenuBar.window.ToString())
                    form.item[i].Text = TextType.main[5];
                if (form.item[i].Name == MenuView.vertically.ToString())
                    form.item[i].Text = TextType.main[6];
                if (form.item[i].Name == MenuView.cascade.ToString())
                    form.item[i].Text = TextType.main[7];
                if (form.item[i].Name == MenuView.horizontally.ToString())
                    form.item[i].Text = TextType.main[8];
                if (form.item[i].Name == MenuFile.save.ToString())
                    form.item[i].Text = TextType.main[9];
                if (form.item[i].Name == MenuFile.print.ToString())
                    form.item[i].Text = TextType.main[10];
                if (form.item[i].Name == MenuFile.fill.ToString())
                    form.item[i].Text = TextType.main[11];
                if (form.item[i].Name == MenuFile.delete.ToString())
                    form.item[i].Text = TextType.main[12];
                if (form.item[i].Name == MenuFile.filter.ToString())
                    form.item[i].Text = TextType.main[13];
                if (form.item[i].Name == MenuFile.open.ToString())
                    form.item[i].Text = TextType.main[14];
                if (form.item[i].Name == MenuFile.add.ToString())
                    form.item[i].Text = TextType.main[15];
                if (form.item[i].Name == MenuFile.edit.ToString())
                    form.item[i].Text = TextType.main[16];
                if (form.item[i].Name == MenuFile.clean.ToString())
                    form.item[i].Text = TextType.main[17];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    form.item[i].Text = TextType.name[1];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    form.item[i].Text = TextType.name[2];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    form.item[i].Text = TextType.name[3];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    form.item[i].Text = TextType.name[4];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    form.item[i].Text = TextType.name[5];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    form.item[i].Text = TextType.name[6];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    form.item[i].Text = TextType.name[7];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    form.item[i].Text = TextType.name[8];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.main, MenuBar.settings))
                    form.item[i].Text = TextType.name[9];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.settings))
                    form.item[i].Text = TextType.name[10];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.settings))
                    form.item[i].Text = TextType.name[11];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.settings))
                    form.item[i].Text = TextType.name[12];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.settings))
                    form.item[i].Text = TextType.name[13];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuFile.filter))
                    form.item[i].Text = TextType.name[14];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuFile.filter))
                    form.item[i].Text = TextType.name[15];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuFile.filter))
                    form.item[i].Text = TextType.name[16];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuFile.filter))
                    form.item[i].Text = TextType.name[17];
            }
            for (int i = 0; i < form.button.Count; i++)
            {
                if (form.button[i].Name == MenuBar.file.ToString())
                    form.button[i].Text = TextType.main[0];
                if (form.button[i].Name == MenuBar.document.ToString())
                    form.button[i].Text = TextType.main[1];
                if (form.button[i].Name == MenuBar.registry.ToString())
                    form.button[i].Text = TextType.main[2];
                if (form.button[i].Name == MenuBar.view.ToString())
                    form.button[i].Text = TextType.main[3];
                if (form.button[i].Name == MenuBar.settings.ToString())
                    form.button[i].Text = TextType.main[4];
                if (form.button[i].Name == MenuBar.window.ToString())
                    form.button[i].Text = TextType.main[5];
                if (form.button[i].Name == MenuView.vertically.ToString())
                    form.button[i].Text = TextType.main[6];
                if (form.button[i].Name == MenuView.cascade.ToString())
                    form.button[i].Text = TextType.main[7];
                if (form.button[i].Name == MenuView.horizontally.ToString())
                    form.button[i].Text = TextType.main[8];
                if (form.button[i].Name == MenuFile.save.ToString())
                    form.button[i].Text = TextType.main[9];
                if (form.button[i].Name == MenuFile.print.ToString())
                    form.button[i].Text = TextType.main[10];
                if (form.button[i].Name == MenuFile.fill.ToString())
                    form.button[i].Text = TextType.main[11];
                if (form.button[i].Name == MenuFile.delete.ToString())
                    form.button[i].Text = TextType.main[12];
                if (form.button[i].Name == MenuFile.filter.ToString())
                    form.button[i].Text = TextType.main[13];
                if (form.button[i].Name == MenuFile.open.ToString())
                    form.button[i].Text = TextType.main[14];
                if (form.button[i].Name == MenuFile.add.ToString())
                    form.button[i].Text = TextType.main[15];
                if (form.button[i].Name == MenuFile.edit.ToString())
                    form.button[i].Text = TextType.main[16];
                if (form.button[i].Name == MenuFile.clean.ToString())
                    form.button[i].Text = TextType.main[17];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    form.button[i].Text = TextType.name[1];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    form.button[i].Text = TextType.name[2];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    form.button[i].Text = TextType.name[3];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    form.button[i].Text = TextType.name[4];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    form.button[i].Text = TextType.name[5];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    form.button[i].Text = TextType.name[6];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    form.button[i].Text = TextType.name[7];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    form.button[i].Text = TextType.name[8];
            }
        }

        private void application(Document form)
        {
            for (int i = 0; i < 20; i++)
                form.name[i].Text = TextType.application[i];
            for (int i = 0; i < 10; i++)
                form.name[20 + i].Text = (String.Format("{1} {0}{2}", (i < 9) ? "0" : "", TextType.application[20], i + 1));
            for (int i = 0; i < 7; i++)
                form.name[30 + i].Text = TextType.application[20 + i];
        }

        private void specification(Document form)
        {
            for (int i = 0; i < TextType.specification.Length; i++)
                form.name[i].Text = TextType.specification[i];
            for (int i = TextType.specification.Length; i < form.name.Count; i++)
                form.name[i].Text = TextType.specification[i - 5];
        }

        private void engraving(Document form)
        {
            for (int i = 0; i < 42; i++)
                form.name[i].Text = TextType.engraving[i + 3];
            for (int i = 42; i < 64; i++)
                form.name[i].Text = TextType.engraving[i - 14];
            for (int i = 64; i < 69; i++)
                form.name[i].Text = TextType.engraving[i - 19];
        }

        private void printing(Document form)
        {
            for (int i = 0; i < 49; i++)
                form.name[i].Text = TextType.printing[i + 4];
            form.name[49].Text = TextType.printing[26];
            form.name[50].Text = TextType.printing[26];
        }

        //private void registry(Registry registry)
        //{
        //    if (registry.filterOn)
        //    {
        //        if (registry.typeForm == TypeForm.application)
        //            registry.Text = TextType.name[14];
        //        if (registry.typeForm == TypeForm.specification)
        //            registry.Text = TextType.name[15];
        //        if (registry.typeForm == TypeForm.engraving)
        //            registry.Text = TextType.name[16];
        //        if (registry.typeForm == TypeForm.printing)
        //            registry.Text = TextType.name[17];
        //    }
        //    else
        //    {
        //        if (registry.typeForm == TypeForm.application)
        //            registry.Text = TextType.name[5];
        //        if (registry.typeForm == TypeForm.specification)
        //            registry.Text = TextType.name[6];
        //        if (registry.typeForm == TypeForm.engraving)
        //            registry.Text = TextType.name[7];
        //        if (registry.typeForm == TypeForm.printing)
        //            registry.Text = TextType.name[8];
        //    }
        //}

            /*
            int number = 0;
            for (int i = 0; i < form.visible.Count; i++)
                form.name[number++].Text = TextType.application[i];
            form.name[number++].Text = TextType.application[1];
            form.name[number++].Text = TextType.application[4];
            form.name[number++].Text = TextType.application[5];
            form.name[number++].Text = TextType.application[8];
            form.name[number++].Text = TextType.application[9];
            form.name[number++].Text = TextType.application[10];
            form.name[number++].Text = TextType.application[14];
            for (int i = 16; i < 30; i++)
                form.name[number++].Text = TextType.application[i];
            form.name[number++].Text = TextType.application[32];
            form.name[number++].Text = TextType.application[34];
            form.name[number++].Text = TextType.application[0];
            form.name[number++].Text = TextType.application[1];
            for (int i = 11; i < 14; i++)
                form.name[number++].Text = TextType.application[i];
            form.name[number++].Text = TextType.application[15];
            form.name[number++].Text = TextType.application[31];
            form.name[number++].Text = TextType.application[33];
            form.name[number++].Text = TextType.application[35];
            form.name[number++].Text = TextType.application[36];
            form.name[number++].Text = TextType.application[3];
            form.name[number++].Text = TextType.application[6];
            form.name[number++].Text = TextType.application[7];
            form.name[number++].Text = TextType.application[30];
           */
       

        //private void specificationFilter(Filter form)
        //{
            /*
            int number = 0;
            for (int i = 0; i < 6; i++)
                form.name[number++].Text = TextType.specification[i];
            for (int i = 12; i < 15; i++)
                form.name[number++].Text = TextType.specification[i];
            for (int i = 1; i < 11; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.specification[25]));
            form.name[number++].Text = TextType.specification[2];
            form.name[number++].Text = TextType.specification[4];
            form.name[number++].Text = TextType.specification[6];
            for (int i = 9; i < 19; i++)
                form.name[number++].Text = TextType.specification[i];
            form.name[number++].Text = TextType.specification[0];
            form.name[number++].Text = TextType.specification[1];
            form.name[number++].Text = TextType.specification[5];
            form.name[number++].Text = TextType.specification[7];
            form.name[number++].Text = TextType.specification[3];
            form.name[number++].Text = TextType.specification[8];
            */
        //}

        //private void engravingFilter(Filter form)
        //{
            /*
            int number = 0;
            form.name[number++].Text = TextType.engraving[3];
            form.name[number++].Text = TextType.engraving[4];
            form.name[number++].Text = TextType.engraving[5];
            form.name[number++].Text = TextType.engraving[6];
            form.name[number++].Text = TextType.engraving[12];
            form.name[number++].Text = TextType.engraving[14];
            form.name[number++].Text = TextType.engraving[25];
            form.name[number++].Text = TextType.engraving[27];
            for (int i = 1; i < 6; i++)
                form.name[number++].Text = (String.Format("{0} {1}", i, TextType.engraving[2]));
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[29]));
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[30]));
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[31]));
            for (int i = 45; i < 50; i++)
                form.name[number++].Text = TextType.engraving[i];

            form.name[number++].Text = TextType.engraving[5];
            form.name[number++].Text = TextType.engraving[25];
            form.name[number++].Text = TextType.engraving[27];
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[29]));
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[30]));
            for (int i = 1; i < 16; i++)
                form.name[number++].Text = (String.Format("{0}{1} {2}", (i < 10) ? "0" : "", i, TextType.engraving[31]));
            form.name[number++].Text = TextType.engraving[3];
            form.name[number++].Text = TextType.engraving[4];
            form.name[number++].Text = TextType.engraving[12];
            form.name[number++].Text = TextType.engraving[14];
            for (int i = 1; i < 6; i++)
                form.name[number++].Text = (String.Format("{0} {1}", i, TextType.engraving[2]));
            form.name[number++].Text = TextType.engraving[49];
            for (int i = 45; i < 50; i++)
                form.name[number++].Text = TextType.engraving[i];
                */
        //}

        //private void printingFilter(Filter form)
        //{

        //}
    }
}
