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
    //
    //типы форм
    //
    enum TypeForm { main, application, engraving, specification, printing};

    class FormType
    {
        //
        //родительская форма
        //
        public static Main mdiParent;

        public FormType(Form form)
        {
            form.SuspendLayout();
            form.AutoScaleDimensions = new SizeF(8F, 16F);
            form.AutoScaleMode = AutoScaleMode.Font;
            form.AutoScroll = true;
            form.ResumeLayout(false);
            form.Padding = new Padding(0);
            if (form is Main)
            {
                form.IsMdiContainer = true;
                mdiParent = (Main)form;
            }
            if (form is Document ||
                form is Registry ||
                form is Settings)
            {
                form.MdiParent = mdiParent;
                form.MaximizeBox = false;
                form.StartPosition = FormStartPosition.Manual;
            }
            if (form is Edit)
            {
                form.MaximizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;
            }
        }
    }

    class Main : Form
    {
        public List<ToolStripMenuItem> item = new List<ToolStripMenuItem>();
        public List<ToolStripButton> button = new List<ToolStripButton>();
        public MenuStrip menu;
        public ToolStrip tool;

        public Main()
        {
            new FormCreate(this);
        }

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }

    class Document : Form
    {
        public List<Label> name = new List<Label>();
        public List<Control> save = new List<Control>();
        public List<TextBox> load = new List<TextBox>();
        public TypeForm typeForm;
        public Panel minSize = new Panel();

        public Document(TypeForm type)
        {
            typeForm = type;
            new FormCreate(this);
        }

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }

    class Registry : Form
    {
        public TypeForm typeForm;
        public bool filterOn = false;
        public DataGridView registry;
        public DataGridView filter;
        public Panel minSize = new Panel();

        public Registry(TypeForm formType)
        {
            typeForm = formType;
            new FormCreate(this);
        }

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }

    class Edit : Form
    {
        public List<Control> control = new List<Control>();

        public Edit(Form form, MenuFile menu)
        {
            new FormCreate(this);
        }

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }

    class Settings : Form
    {
        public TypeForm typeForm;
        public Panel minSize = new Panel();
        public DataGridView left;
        public DataGridView right;

        public Settings(TypeForm type)
        {
            typeForm = type;
            new FormCreate(this);
        }

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
