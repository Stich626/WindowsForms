using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ContriolInsert
    {
        ControlType control = new ControlType();

        public ContriolInsert(Form form)
        {
            if (form is Main)
                new MenuInsert((Main)form);
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
                //
                //минимальны размер формы
                //
                document.minSize = control.panel();
                document.Controls.Add(document.minSize);
            }
            if (form is Settings)
                settings((Settings)form);
            if (form is Edit)
                edit((Edit)form);
        }

        private void application(Document form)
        {
            int[] Column = { 50, 50, 50 };
            TableLayoutPanel tableLayoutPanel = control.tableLayoutPanel(Column, 37);
            //
            //размещение заголовков
            //
            int index = 0;
                for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel, 0, i, form.name[index], index++);
            form.Controls.Add(tableLayoutPanel);
            //
            //размещение контролов save
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel, 1, i, form.save[index], index++);
            form.Controls.Add(tableLayoutPanel);
            //
            //размещение контролов load
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel, 2, i, form.load[index], index++);
            form.Controls.Add(tableLayoutPanel);
        }

        private void specification(Document form)
        {
            int[] Column1 = { 50, 50, 50 };
            TableLayoutPanel tableLayoutPanel1 = control.tableLayoutPanel(Column1, 21);     
            int[] Column2 = { 1, 3, 2, 2, 4, 1, 3, 2, 2, 4 };
            TableLayoutPanel tableLayoutPanel2 = control.tableLayoutPanel(Column2, 11);
            int[] Row = { 22, 11 };
            TableLayoutPanel tableLayoutPanel3 = control.tableLayoutPanel(1, Row);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 1);
            //
            //размещение заголовков
            //                  
            int index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 0, i, form.name[index], index++);
            for (int i = 0; i < tableLayoutPanel2.ColumnCount; i++)
                control.tableLayoutPanel(tableLayoutPanel2, i, 0, form.name[index], index++);
            //
            //размещение контролов save
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 1, i, form.save[index], index++);
            for (int i = 0; i < 5; i++)
                for (int j = 1; j < tableLayoutPanel2.RowCount; j++)
                    control.tableLayoutPanel(tableLayoutPanel2, i, j, form.save[index], index++);
            //
            //размещение контролов load
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 2, i, form.load[index], index++);
            for (int i = 5; i < 10; i++)
                for (int j = 1; j < tableLayoutPanel2.RowCount; j++)
                    control.tableLayoutPanel(tableLayoutPanel2, i, j, form.load[index], index++);
            form.Controls.Add(tableLayoutPanel3);
        }

        private void engraving(Document form)
        {                   
            int[] Column1 = { 50, 50, 50 };
            TableLayoutPanel tableLayoutPanel1 = control.tableLayoutPanel(Column1, 25);
            int[] Column2 = { 1, 5, 4, 2, 2, 2, 2, 2, 2 };
            TableLayoutPanel tableLayoutPanel2 = control.tableLayoutPanel(Column2, 42);
            int[] Column3 = Column2;
            TableLayoutPanel tableLayoutPanel3 = control.tableLayoutPanel(Column3, 22);
            int[] Column4 = { 1, 4 };
            TableLayoutPanel tableLayoutPanel4 = control.tableLayoutPanel(Column4, 10);
            int[] Row = { 22, 20 };
            TableLayoutPanel tableLayoutPanel5 = control.tableLayoutPanel(1, Row);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel4, 0, 1);
            TabControl tabControl = control.tabControl();
            TabPage tabPage1 = control.tabPage(FormText.engraving[1]);
            TabPage tabPage2 = control.tabPage(FormText.engraving[2]);
            TabPage tabPage3 = control.tabPage(FormText.engraving[3]);
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage3.Controls.Add(tableLayoutPanel5);
            //
            //размещение заголовков
            //   
            int index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 0, i, form.name[index], index++);
            for (int i = 0; i < tableLayoutPanel2.ColumnCount; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.name[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.name[index], index++);
                }
            for (int i = 0; i < tableLayoutPanel3.ColumnCount; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.name[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.name[index], index++);
                }
            for (int i = 0; i < tableLayoutPanel4.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel4, 0, i, form.name[index], index++);
            //
            //размещение контролов save
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 1, i, form.save[index], index++);
            for (int i = 0; i < tableLayoutPanel2.ColumnCount; i++)
                for (int j = 22; j < tableLayoutPanel2.RowCount; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.save[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.save[index], index++);
                }
            for (int i = 0; i < tableLayoutPanel3.ColumnCount; i++)
                for (int j = 12; j < tableLayoutPanel3.RowCount; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.save[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.save[index], index++);
                }
            for (int i = 5; i < tableLayoutPanel4.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel4, 1, i, form.save[index], index++);
            //
            //размещение контролов load
            //
            index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel1, 2, i, form.load[index], index++);
            for (int i = 0; i < tableLayoutPanel2.ColumnCount; i++)
                for (int j = 2; j < 22; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.load[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel2, i, j, form.load[index], index++);
                }
            for (int i = 0; i < tableLayoutPanel3.ColumnCount; i++)
                for (int j = 2; j < 12; j++)
                {
                    if (i != 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.load[index], index++);
                    else if (j % 2 == 0)
                        control.tableLayoutPanel(tableLayoutPanel3, i, j, form.load[index], index++);
                }
            for (int i = 0; i < 5; i++)
                control.tableLayoutPanel(tableLayoutPanel4, 1, i, form.load[index], index++);
            form.Controls.Add(tabControl);
        }

        private void printing(Document form)
        {
            int[] Column1 = { 50, 50, 50 };
            TableLayoutPanel tableLayoutPanel1 = this.control.tableLayoutPanel(Column1, 22);
            int[] Column2 = { 3, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            TableLayoutPanel tableLayoutPanel2 = this.control.tableLayoutPanel(Column2, 27);
            tableLayoutPanel2.RowStyles.Insert(1, new RowStyle(SizeType.Percent, 380));
            int[] Column3 = { 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            TableLayoutPanel tableLayoutPanel3 = this.control.tableLayoutPanel(Column3, 27);
            tableLayoutPanel3.RowStyles.Insert(1, new RowStyle(SizeType.Percent, 380));
            int[] Column4 = Column3;
            TableLayoutPanel tableLayoutPanel4 = this.control.tableLayoutPanel(Column4, 27);
            tableLayoutPanel4.RowStyles.Insert(1, new RowStyle(SizeType.Percent, 380));
            int[] Row5 = { 8, 230, 2 };
            TableLayoutPanel tableLayoutPanel5 = this.control.tableLayoutPanel(1, Row5);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel2, 0, 1);
            int[] Column6 = { 17, 14 };
            TableLayoutPanel tableLayoutPanel6 = this.control.tableLayoutPanel(Column6, 1);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel5, 0, 0);
            TabControl tabControl2 = this.control.tabControl();
            tableLayoutPanel6.Controls.Add(tabControl2, 1, 0);
            TabControl tabControl1 = this.control.tabControl();
            TabPage tabPage1 = this.control.tabPage(FormText.printing[1]);
            TabPage tabPage2 = this.control.tabPage(FormText.printing[2]);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabPage1.Controls.Add(tableLayoutPanel1);           
            tabPage2.Controls.Add(tableLayoutPanel6);
            TabPage tabPage3 = this.control.tabPage(FormText.printing[3]);
            TabPage tabPage4 = this.control.tabPage(FormText.printing[4]);
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabPage3.Controls.Add(tableLayoutPanel3);
            tabPage4.Controls.Add(tableLayoutPanel4);
            //
            //размещение заголовков
            //
            ControlType control = new ControlType();
            int index = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                this.control.tableLayoutPanel(tableLayoutPanel1, 0, i, form.name[index], index++);
            this.control.tableLayoutPanel(tableLayoutPanel2, 0, 1, control.label(form.name[index], DockStyle.Bottom), index++);
            for (int j = 1; j < tableLayoutPanel2.RowCount; j++)
                this.control.tableLayoutPanel(tableLayoutPanel2, 1, j, form.name[index], index++);
            this.control.tableLayoutPanel(tableLayoutPanel3, 0, 1, control.label(form.name[index], DockStyle.Bottom), index++);
            this.control.tableLayoutPanel(tableLayoutPanel4, 0, 1, control.label(form.name[index], DockStyle.Bottom), index++);
            //
            //размещение контролов save
            //
            index = 0;
            for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                this.control.tableLayoutPanel(tableLayoutPanel1, 1, j, form.save[index], index++);
            for (int j = 2; j < tableLayoutPanel2.RowCount - 3; j++)
                this.control.tableLayoutPanel(tableLayoutPanel2, 0, j, form.save[index], index++);
            for (int i = 2; i < tableLayoutPanel2.ColumnCount; i++)
                for (int j = 0; j < tableLayoutPanel2.RowCount; j++)
                    this.control.tableLayoutPanel(tableLayoutPanel2, i, j, form.save[index], index++);
            //
            //размещение контролов load
            //
            index = 0;
            for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                this.control.tableLayoutPanel(tableLayoutPanel1, 2, j, form.load[index], index++);
            for (int j = 2; j < tableLayoutPanel3.RowCount - 3; j++)
                this.control.tableLayoutPanel(tableLayoutPanel3, 0, j, form.load[index], index++);
            for (int i = 1; i < tableLayoutPanel3.ColumnCount; i++)
                for (int j = 0; j < tableLayoutPanel3.RowCount; j++)
                    this.control.tableLayoutPanel(tableLayoutPanel3, i, j, form.load[index], index++);
            for (int j = 2; j < tableLayoutPanel4.RowCount - 3; j++)
                this.control.tableLayoutPanel(tableLayoutPanel4, 0, j, form.load[index], index++);
            for (int i = 1; i < tableLayoutPanel4.ColumnCount; i++)
                for (int j = 0; j < tableLayoutPanel4.RowCount; j++)
                    this.control.tableLayoutPanel(tableLayoutPanel4, i, j, form.load[index], index++);
            form.Controls.Add(tabControl1);    
        }

        private void settings(Settings form)
        {
            int[] Column = { 50, 50 };
            TableLayoutPanel tableLayoutPanel = control.tableLayoutPanel(Column, 1);
            tableLayoutPanel.Controls.Add(form.left, 0, 0);
            tableLayoutPanel.Controls.Add(form.right, 1, 0);
            form.Controls.Add(tableLayoutPanel);
        }

        private void edit(Edit form)
        {
            int[] Column = { 50, 50 };
            TableLayoutPanel tableLayoutPanel = control.tableLayoutPanel(Column, 4);
            //
            //размещение заголовков
            //
            int index = 0;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                control.tableLayoutPanel(tableLayoutPanel, 0, i, form.control[index], index++);
            form.Controls.Add(tableLayoutPanel);
            //
            //размещение контролов filter
            //
            index = 0;
            //for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            //    panel.tableLayoutPanel(tableLayoutPanel, 1, i, form.save[index], index++);
            //form.Controls.Add(tableLayoutPanel);
        }
    }
}
