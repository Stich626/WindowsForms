using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class PanelType
    {
        public TabPage tabPage(string name)
        {
            TabPage tabPage = new TabPage();
            tabPage.Padding = new Padding(0);
            tabPage.Dock = DockStyle.Fill;
            tabPage.Text = name;
            tabPage.BackColor = SystemColors.Control;
            return tabPage;
        }

        public TabControl tabControl()
        {
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.BackColor = SystemColors.Control;
            return tabControl;
        }

        public TableLayoutPanel tableLayoutPanel(int[] column, int row)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = column.Count();
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, column[i]));
            tableLayoutPanel.RowCount = row;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            return tableLayoutPanel;
        }

        public TableLayoutPanel tableLayoutPanel(int column, int row)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = column;
            tableLayoutPanel.AutoScroll = true;
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowCount = row + 1;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
            return tableLayoutPanel;
        }

        public TableLayoutPanel tableLayoutPanel(int column, int[] row)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = column;
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, column));
            tableLayoutPanel.RowCount = row.Count();
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, row[i]));
            return tableLayoutPanel;
        }

        public void tableLayoutPanel(TableLayoutPanel tableLayoutPanel, int Column, int Row, object control, int index)
        {
            if (control is Label)
                tableLayoutPanel.Controls.Add((Label)control, Column, Row);
            else
                tableLayoutPanel.Controls.Add(panel((Control)control), Column, Row);
        }

        public Panel panel()
        {
            Panel panel = new Panel();
            //panel.BackColor = Color.Black;            
            panel.Margin = new Padding(0);
            panel.Location = new Point(0, 0);
            return panel;
        }

        public Panel panel(TextBox textBox)
        {
            Panel panel = new Panel();
            panel.Controls.Add(textBox);
            panel.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            panel.ClientSize = new Size(textBox.Size.Width, textBox.Size.Height + 4) ;
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(1);
            return panel;
        }

        private Panel panel(Control control)
        {
            Panel panel = new Panel();
            if (control is TextBox)
            {
                TextBox textBox = (TextBox)control;
                if (!textBox.ReadOnly)
                    panel.BackColor = SystemColors.Window;
            }
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(1);
            panel.Dock = DockStyle.Fill;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(control, 0, 1);
            panel.Controls.Add(tableLayoutPanel);
            return panel;
        }
    }
}
