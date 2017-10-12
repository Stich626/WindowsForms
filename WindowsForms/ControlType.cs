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
        public Button button(int number)
        {
            Button button = new Button();
            button.Size = new Size(75, 23);
            //button.Text = button.Name;
            button.Name = String.Format("button{0}", number);
            button.UseVisualStyleBackColor = true;
            return button;
        }

        private Control toolTip(Control control)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(control, control.Name);
            return control;
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

        public DateTimePicker dateTimePicker(int number)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = String.Format("dateTimePicker{0}", number);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Margin = new Padding(0);
            dateTimePicker.Dock = DockStyle.Fill; Panel panel = new Panel();
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

        public DataGridView dataGridView(int column)
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Margin = new Padding(0);
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (column != 0)
            {
                for (int i = 0; i < column; i++)
                {
                    DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                    Column.Name = String.Format("Column{0}", i);
                    Column.HeaderText = Column.Name;
                    dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column });
                }
            }
            return dataGridView;
        }
    }   
}
