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
        public static string[] name, filter, main, application, engraving, specification, printing, edit;

        public FormText(Language Lang)
        {
            lang = Lang;
            if (lang == Language.Ru)
                path = "Text/Ru/";
            if (lang == Language.Ua)
                path = "Text/Ua/";
            try
            {
                ControlData data = new ControlData();
                name = arrEmty("name", path);
                main = arrEmty("main", path);
                application = arrEmty("application", path);
                engraving = arrEmty("engraving", path);
                specification = arrEmty("specification", path);
                printing = arrEmty("printing", path);
                edit = arrEmty("edit", path);
                filter = File.ReadAllLines(String.Format("{0}filter.txt", path));
            }
            catch
            {

            }
        }

        public FormText(Form form)
        {
            if (form is Main)
                formText((Main)form);
            if (form is Document)
                formText((Document)form);
            if (form is Registry)
                formText((Registry)form);
            if (form is Settings)
                formText((Settings)form);
            if (form is Edit)
                formText((Edit)form);
        }

        private void formText(Main main)
        {
            main.Text = name[1];
            for (int i = 0; i < main.item.Count; i++)
            {
                if (main.item[i].Name == MenuBar.file.ToString())
                    main.item[i].Text = FormText.main[1];
                if (main.item[i].Name == MenuBar.document.ToString())
                    main.item[i].Text = FormText.main[2];
                if (main.item[i].Name == MenuBar.registry.ToString())
                    main.item[i].Text = FormText.main[3];
                if (main.item[i].Name == MenuBar.view.ToString())
                    main.item[i].Text = FormText.main[4];
                if (main.item[i].Name == MenuBar.settings.ToString())
                    main.item[i].Text = FormText.main[5];
                if (main.item[i].Name == MenuBar.window.ToString())
                    main.item[i].Text = FormText.main[6];
                if (main.item[i].Name == MenuView.vertically.ToString())
                    main.item[i].Text = FormText.main[7];
                if (main.item[i].Name == MenuView.cascade.ToString())
                    main.item[i].Text = FormText.main[8];
                if (main.item[i].Name == MenuView.horizontally.ToString())
                    main.item[i].Text = FormText.main[9];
                if (main.item[i].Name == MenuFile.save.ToString())
                    main.item[i].Text = FormText.main[10];
                if (main.item[i].Name == MenuFile.print.ToString())
                    main.item[i].Text = FormText.main[11];
                if (main.item[i].Name == MenuFile.fill.ToString())
                    main.item[i].Text = FormText.main[12];
                if (main.item[i].Name == MenuFile.delete.ToString())
                    main.item[i].Text = FormText.main[13];
                if (main.item[i].Name == MenuFile.filter.ToString())
                    main.item[i].Text = FormText.main[14];
                if (main.item[i].Name == MenuFile.open.ToString())
                    main.item[i].Text = FormText.main[15];
                if (main.item[i].Name == MenuFile.add.ToString())
                    main.item[i].Text = FormText.main[16];
                if (main.item[i].Name == MenuFile.edit.ToString())
                    main.item[i].Text = FormText.main[17];
                if (main.item[i].Name == MenuFile.clean.ToString())
                    main.item[i].Text = FormText.main[18];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    main.item[i].Text = name[2];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    main.item[i].Text = name[3];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    main.item[i].Text = name[4];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    main.item[i].Text = name[5];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    main.item[i].Text = name[6];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    main.item[i].Text = name[7];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    main.item[i].Text = name[8];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    main.item[i].Text = name[9];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.main, MenuBar.settings))
                    main.item[i].Text = name[10];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.settings))
                    main.item[i].Text = name[11];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.settings))
                    main.item[i].Text = name[12];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.settings))
                    main.item[i].Text = name[13];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.settings))
                    main.item[i].Text = name[14];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.application, MenuFile.filter))
                    main.item[i].Text = name[15];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuFile.filter))
                    main.item[i].Text = name[16];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuFile.filter))
                    main.item[i].Text = name[17];
                if (main.item[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuFile.filter))
                    main.item[i].Text = name[18];
            }
            for (int i = 0; i < main.button.Count; i++)
            {
                if (main.button[i].Name == MenuBar.file.ToString())
                    main.button[i].Text = FormText.main[1];
                if (main.button[i].Name == MenuBar.document.ToString())
                    main.button[i].Text = FormText.main[2];
                if (main.button[i].Name == MenuBar.registry.ToString())
                    main.button[i].Text = FormText.main[3];
                if (main.button[i].Name == MenuBar.view.ToString())
                    main.button[i].Text = FormText.main[4];
                if (main.button[i].Name == MenuBar.settings.ToString())
                    main.button[i].Text = FormText.main[5];
                if (main.button[i].Name == MenuBar.window.ToString())
                    main.button[i].Text = FormText.main[6];
                if (main.button[i].Name == MenuView.vertically.ToString())
                    main.button[i].Text = FormText.main[7];
                if (main.button[i].Name == MenuView.cascade.ToString())
                    main.button[i].Text = FormText.main[8];
                if (main.button[i].Name == MenuView.horizontally.ToString())
                    main.button[i].Text = FormText.main[9];
                if (main.button[i].Name == MenuFile.save.ToString())
                    main.button[i].Text = FormText.main[10];
                if (main.button[i].Name == MenuFile.print.ToString())
                    main.button[i].Text = FormText.main[11];
                if (main.button[i].Name == MenuFile.fill.ToString())
                    main.button[i].Text = FormText.main[12];
                if (main.button[i].Name == MenuFile.delete.ToString())
                    main.button[i].Text = FormText.main[13];
                if (main.button[i].Name == MenuFile.filter.ToString())
                    main.button[i].Text = FormText.main[14];
                if (main.button[i].Name == MenuFile.open.ToString())
                    main.button[i].Text = FormText.main[15];
                if (main.button[i].Name == MenuFile.add.ToString())
                    main.button[i].Text = FormText.main[16];
                if (main.button[i].Name == MenuFile.edit.ToString())
                    main.button[i].Text = FormText.main[17];
                if (main.button[i].Name == MenuFile.clean.ToString())
                    main.button[i].Text = FormText.main[18];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.document))
                    main.button[i].Text = name[2];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.document))
                    main.button[i].Text = name[3];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.document))
                    main.button[i].Text = name[4];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.document))
                    main.button[i].Text = name[5];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.application, MenuBar.registry))
                    main.button[i].Text = name[6];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.specification, MenuBar.registry))
                    main.button[i].Text = name[7];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.engraving, MenuBar.registry))
                    main.button[i].Text = name[8];
                if (main.button[i].Name == String.Format("{0}{1}", TypeForm.printing, MenuBar.registry))
                    main.button[i].Text = name[9];
            }
        }

        private void formText(Document document)
        {
            if (document.typeForm == TypeForm.application)
            {
                applicationForm(document);
                document.Text = name[2];
            }
            if (document.typeForm == TypeForm.specification)
            {
                specificationForm(document);
                document.Text = name[3];
            }
            if (document.typeForm == TypeForm.engraving)
            {
                engravingForm(document);
                document.Text = name[4];
            }
            if (document.typeForm == TypeForm.printing)
            {
                printingForm(document);
                document.Text = name[5];
            }
        }

        private void formText(Registry registry)
        {
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
            //
            //названия колонок реестра
            //
            {
                if (registry.typeForm == TypeForm.application)
                    for (int i = 1; i < application.Length; i++)
                        registry.registry.Columns[i - 1].HeaderText = application[i];
                if (registry.typeForm == TypeForm.specification)
                    for (int i = 1; i < specification.Length; i++)
                        registry.registry.Columns[i - 1].HeaderText = specification[i];
                if (registry.typeForm == TypeForm.engraving)
                    for (int i = 1; i < engraving.Length; i++)
                        registry.registry.Columns[i - 1].HeaderText = engraving[i];
                if (registry.typeForm == TypeForm.printing)
                    for (int i = 1; i < printing.Length; i++)
                        registry.registry.Columns[i - 1].HeaderText = printing[i];
            }
            //
            //названия колонок фильтра реестра
            //
            {
                for (int i = 0; i < registry.registry.ColumnCount; i++)
                    registry.filter[0, i].Value = registry.registry.Columns[i].HeaderText;
                for (int i = 0; i < registry.filter.ColumnCount; i++)
                    registry.filter.Columns[i].HeaderText = filter[i];
            }
        }

        private void formText(Settings settings)
        {
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

        private void formText(Edit edit)
        {
            if (edit.form is Settings)
            {
                Settings settings = FormType.mdiParent.ActiveMdiChild as Settings;
                if (settings.left.CurrentCell.Value.ToString() != printing[2])
                {
                    for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                        edit.name[i].Text = settings.right.Columns[i + 1].HeaderText;
                }
                else
                {
                    for (int i = 0; i < settings.right.ColumnCount - 1; i++)
                        edit.name[i].Text = settings.right.Columns[i + 1].HeaderText.Replace(Environment.NewLine, "");
                }
            }
            if (edit.form is Registry)
            {
                for (int i = 0; i < 5; i++)
                    edit.name[i].Text = filter[i];
            }
            edit.button[0].Text = FormText.edit[1];
            edit.button[1].Text = FormText.edit[2];
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

        private string[] arrEmty(string file, string path)
        {
            string[] arr1 = File.ReadAllLines(String.Format("{0}{1}.txt", path, file));
            string[] arr2 = new string[arr1.Length + 1];
            arr2[0] = String.Empty;
            for (int i = 1; i < arr2.Length; i++)
                arr2[i] = arr1[i - 1];
            return arr2;
        }
    }
}
