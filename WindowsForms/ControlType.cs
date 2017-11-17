using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ControlType
    {
        public Button button(AnchorStyles anchor)
        {
            Button button = new Button();
            button.Size = new Size(80, 30);
            button.Margin = new Padding(3, 3, 3, 3);
            button.Anchor = anchor | AnchorStyles.Bottom;
            //button.Name = String.Format("button{0}", number);
            button.UseVisualStyleBackColor = true;
            return button;
        }

        public RadioButton radioButton(int number)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.AutoSize = true;
            radioButton.Location = new Point(318, 73);
            radioButton.Name = String.Format("radioButton{0}", number);
            radioButton.Size = new Size(18, 17);
            radioButton.UseVisualStyleBackColor = true;
            return (RadioButton)toolTip(radioButton);
        }

        public Label label(int number)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Name = String.Format("label{0}", number);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Margin = new Padding(1);
            label.Dock = DockStyle.Fill;
            label.BackColor = SystemColors.ControlLight;
            //label.Text = label.Name;
            label.TextAlign = ContentAlignment.MiddleLeft;
            return (Label)toolTip(label);
        }

        public Label label(Label label, DockStyle style)
        {
            label.Dock = style;
            label.Padding = new Padding(0, 3, 0, 3);
            return label;
        }

        public CheckBox checkBox(int number)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Location = new Point(318, 73);
            checkBox.Name = String.Format("checkBox{0}", number);
            checkBox.Size = new Size(18, 17);
            checkBox.UseVisualStyleBackColor = true;
             return (CheckBox)toolTip(checkBox);
        }

        public TextBox textBox(int number, bool readOnly)
        {
            TextBox textBox = new TextBox();
            textBox.Name = String.Format("textBox{0}", number);
            //textBox.Text = textBox.Name;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Margin = new Padding(4, 0, 4, 0);
            textBox.Dock = DockStyle.Fill;
            textBox.ReadOnly = readOnly;
            return (TextBox)toolTip(textBox);
        }

        public TextBox textBox(int number)
        {
            TextBox textBox = new TextBox();
            textBox.Name = String.Format("textBox{0}", number);
            //textBox.Text = textBox.Name;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Margin = new Padding(3, 2, 3, 1);
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return (TextBox)toolTip(textBox);
        }

        public DateTimePicker dateTimePicker(int number)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = String.Format("dateTimePicker{0}", number);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Margin = new Padding(0);
            dateTimePicker.Dock = DockStyle.Fill;
            return (DateTimePicker)toolTip(dateTimePicker);
        }

        public ComboBox comboBox(int number)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Margin = new Padding(0);
            comboBox.Dock = DockStyle.Fill;
            comboBox.Name = String.Format("comboBox{0}", number);
            return (ComboBox)toolTip(comboBox);
        }

        public DataGridView dataGridView()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            //dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Margin = new Padding(6);
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = SystemColors.Control;
            return dataGridView;
        }

        public DataGridView dataGridView(int column, int row)
        {
            DataGridView gridView = dataGridView();
            gridView.ColumnCount = column;
            gridView.RowCount = row;
            for (int i = 0; i < column; i++ )
                gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                return gridView;
        }

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
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
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

        public void tableLayoutPanel(TableLayoutPanel tableLayoutPanel, int Column, int Row, object control)
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

        public Panel panel(Control control)
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
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(control, 0, 1);
            panel.Controls.Add(tableLayoutPanel);
            return panel;
        }

        private Control toolTip(Control control)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(control, control.Name);
            return control;
        }
    }   
}
