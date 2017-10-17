using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    enum Language { Ru, Ua };

    class FormText
    {
        private static Language lang = Language.Ru;
        private static string path;
        public static string[] name, filter, main, application, engraving, specification, printing;

        public FormText(Language Lang)
        {
            lang = Lang;
            if (lang == Language.Ru)
                path = "Text/Ru/";
            if (lang == Language.Ua)
                path = "Text/Ua/";
            try
            {
                name = arrEmty("name");
                filter = arrEmty("filter");
                main = arrEmty("main");
                application = arrEmty("application");
                engraving = arrEmty("engraving");
                specification = arrEmty("specification");
                printing = arrEmty("printing");
            }
            catch
            {

            }
        }

        public FormText(Form form)
        {
            textForm(form);
            if (form is Main)
                mainForm((Main)form);
            if (form is Document)
            {
                Document document = form as Document;
                if (document.typeForm == TypeForm.application)
                    applicationForm(document);
                if (document.typeForm == TypeForm.specification)
                    specificationForm(document);
                if (document.typeForm == TypeForm.engraving)
                    engravingForm(document);
                if (document.typeForm == TypeForm.printing)
                    printingForm(document);
            }
            if (form is Edit)
            {
                if (FormType.mdiParent.ActiveMdiChild is Settings)
                    editSettings((Edit)form, (Settings)FormType.mdiParent.ActiveMdiChild);
            }
        }

        private string[] arrEmty(string file)
        {
            string[] arr1 = File.ReadAllLines(String.Format("{0}{1}.txt", path, file));
            string[] arr2 = new string[arr1.Length + 1];
            arr2[0] = String.Empty;
            for (int i = 1; i < arr2.Length; i++)
                arr2[i] = arr1[i - 1];
            return arr2;
        }

        private void textForm(Form form)
        {
            if (form is Main)
            {
                Main main = (Main)form;
                main.Text = name[1];
            }
            if (form is Document)
            {
                Document document = (Document)form;
                if (document.typeForm == TypeForm.application)
                    document.Text = name[2];
                if (document.typeForm == TypeForm.specification)
                    document.Text = name[3];
                if (document.typeForm == TypeForm.engraving)
                    document.Text = name[4];
                if (document.typeForm == TypeForm.printing)
                    document.Text = name[5];
            }
            if (form is Registry)
            {
                Registry registry = (Registry)form;
                if (registry.filterOn)
                {
                    if (registry.typeForm == TypeForm.application)
                        registry.Text = name[15];
                    if (registry.typeForm == TypeForm.specification)
                        registry.Text = name[16];
                    if (registry.typeForm == TypeForm.engraving)
                        registry.Text = name[17];
                    if (registry.typeForm == TypeForm.printing)
                        registry.Text = name[18];
                }
                else
                {
                    if (registry.typeForm == TypeForm.application)
                        registry.Text = name[6];
                    if (registry.typeForm == TypeForm.specification)
                        registry.Text = name[7];
                    if (registry.typeForm == TypeForm.engraving)
                        registry.Text = name[8];
                    if (registry.typeForm == TypeForm.printing)
                        registry.Text = name[9];
                }
            }
            if (form is Settings)
            {
                Settings settings = (Settings)form;
                if (settings.typeForm == TypeForm.main)
                    settings.Text = name[10];
                if (settings.typeForm == TypeForm.application)
                    settings.Text = name[11];
                if (settings.typeForm == TypeForm.specification)
                    settings.Text = name[12];
                if (settings.typeForm == TypeForm.engraving)
                    settings.Text = name[13];
                if (settings.typeForm == TypeForm.printing)
                    settings.Text = name[14];
            }
        }

        private void mainForm(Main form)
        {
            for (int i = 0; i < form.item.Count; i++)
            {
                if (form.item[i].Name == MenuBar.file.ToString())
                    form.item[i].Text = main[1];
                if (form.item[i].Name == MenuBar.document.ToString())
                    form.item[i].Text = main[2];
                if (form.item[i].Name == MenuBar.registry.ToString())
                    form.item[i].Text = main[3];
                if (form.item[i].Name == MenuBar.view.ToString())
                    form.item[i].Text = main[4];
                if (form.item[i].Name == MenuBar.settings.ToString())
                    form.item[i].Text = main[5];
                if (form.item[i].Name == MenuBar.window.ToString())
                    form.item[i].Text = main[6];
                if (form.item[i].Name == MenuView.vertically.ToString())
                    form.item[i].Text = main[7];
                if (form.item[i].Name == MenuView.cascade.ToString())
                    form.item[i].Text = main[8];
                if (form.item[i].Name == MenuView.horizontally.ToString())
                    form.item[i].Text = main[9];
                if (form.item[i].Name == MenuFile.save.ToString())
                    form.item[i].Text = main[10];
                if (form.item[i].Name == MenuFile.print.ToString())
                    form.item[i].Text = main[11];
                if (form.item[i].Name == MenuFile.fill.ToString())
                    form.item[i].Text = main[12];
                if (form.item[i].Name == MenuFile.delete.ToString())
                    form.item[i].Text = main[13];
                if (form.item[i].Name == MenuFile.filter.ToString())
                    form.item[i].Text = main[14];
                if (form.item[i].Name == MenuFile.open.ToString())
                    form.item[i].Text = main[15];
                if (form.item[i].Name == MenuFile.add.ToString())
                    form.item[i].Text = main[16];
                if (form.item[i].Name == MenuFile.edit.ToString())
                    form.item[i].Text = main[17];
                if (form.item[i].Name == MenuFile.clean.ToString())
                    form.item[i].Text = main[18];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    form.item[i].Text = name[2];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    form.item[i].Text = name[3];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    form.item[i].Text = name[4];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    form.item[i].Text = name[5];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    form.item[i].Text = name[6];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    form.item[i].Text = name[7];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    form.item[i].Text = name[8];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    form.item[i].Text = name[9];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.main, MenuBar.settings))
                    form.item[i].Text = name[10];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.settings))
                    form.item[i].Text = name[11];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.settings))
                    form.item[i].Text = name[12];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.settings))
                    form.item[i].Text = name[13];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.settings))
                    form.item[i].Text = name[14];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuFile.filter))
                    form.item[i].Text = name[15];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuFile.filter))
                    form.item[i].Text = name[16];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuFile.filter))
                    form.item[i].Text = name[17];
                if (form.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuFile.filter))
                    form.item[i].Text = name[18];
            }
            for (int i = 0; i < form.button.Count; i++)
            {
                if (form.button[i].Name == MenuBar.file.ToString())
                    form.button[i].Text = main[1];
                if (form.button[i].Name == MenuBar.document.ToString())
                    form.button[i].Text = main[2];
                if (form.button[i].Name == MenuBar.registry.ToString())
                    form.button[i].Text = main[3];
                if (form.button[i].Name == MenuBar.view.ToString())
                    form.button[i].Text = main[4];
                if (form.button[i].Name == MenuBar.settings.ToString())
                    form.button[i].Text = main[5];
                if (form.button[i].Name == MenuBar.window.ToString())
                    form.button[i].Text = main[6];
                if (form.button[i].Name == MenuView.vertically.ToString())
                    form.button[i].Text = main[7];
                if (form.button[i].Name == MenuView.cascade.ToString())
                    form.button[i].Text = main[8];
                if (form.button[i].Name == MenuView.horizontally.ToString())
                    form.button[i].Text = main[9];
                if (form.button[i].Name == MenuFile.save.ToString())
                    form.button[i].Text = main[10];
                if (form.button[i].Name == MenuFile.print.ToString())
                    form.button[i].Text = main[11];
                if (form.button[i].Name == MenuFile.fill.ToString())
                    form.button[i].Text = main[12];
                if (form.button[i].Name == MenuFile.delete.ToString())
                    form.button[i].Text = main[13];
                if (form.button[i].Name == MenuFile.filter.ToString())
                    form.button[i].Text = main[14];
                if (form.button[i].Name == MenuFile.open.ToString())
                    form.button[i].Text = main[15];
                if (form.button[i].Name == MenuFile.add.ToString())
                    form.button[i].Text = main[16];
                if (form.button[i].Name == MenuFile.edit.ToString())
                    form.button[i].Text = main[17];
                if (form.button[i].Name == MenuFile.clean.ToString())
                    form.button[i].Text = main[18];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    form.button[i].Text = name[2];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    form.button[i].Text = name[3];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    form.button[i].Text = name[4];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    form.button[i].Text = name[5];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    form.button[i].Text = name[6];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    form.button[i].Text = name[7];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    form.button[i].Text = name[8];
                if (form.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    form.button[i].Text = name[9];
            }
        }

        private void applicationForm(Document form)
        {
            for (int i = 0; i < 20; i++)
                form.name[i].Text = application[i + 1];
            for (int i = 0; i < 10; i++)
                form.name[i + 20].Text = (String.Format("{1} {0}{2}", (i < 9) ? "0" : "", application[21], i + 1));
            for (int i = 0; i < 7; i++)
                form.name[i + 30].Text = application[i + 22];
        }

        private void specificationForm(Document form)
        {
            for (int i = 0; i < 21; i++)
                form.name[i].Text = specification[i + 1];
            form.name[21].Text = specification[1];
            for (int i = 0; i < 4; i++)
                form.name[i + 22].Text = specification[i + 22];
            form.name[26].Text = specification[1];
            for (int i = 0; i < 4; i++)
                form.name[i + 27].Text = specification[i + 22];
        }

        private void engravingForm(Document form)
        {
            for (int i = 0; i < 25; i++)
                form.name[i].Text = engraving[i + 4];
            form.name[25].Text = engraving[4];
            for (int i = 0; i < 16; i++)
                form.name[i + 26].Text = engraving[i + 29];
            form.name[42].Text = engraving[4];
            for (int i = 0; i < 16; i++)
                form.name[i + 43].Text = engraving[i + 29];
            for (int i = 0; i < 5; i++)
                form.name[i + 59].Text = engraving[i + 45];
            for (int i = 0; i < 5; i++)
                form.name[i + 64].Text = engraving[i + 45];
        }

        private void printingForm(Document form)
        {
            for (int i = 0; i < 49; i++)
                form.name[i].Text = printing[i + 5];
            form.name[49].Text = printing[27];
            form.name[50].Text = printing[27];
        }

        private void editSettings(Edit edit, Settings settings)
        {
            for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                edit.name[0].Text = settings.right.Columns[1].HeaderText;
        }
    }
}
