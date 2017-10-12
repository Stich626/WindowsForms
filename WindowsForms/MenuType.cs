using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class MenuType
    {
        public MenuStrip stripMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Location = new Point(0, 0);
            menuStrip.Size = new Size(653, 24);
            menuStrip.Padding = new Padding(0);
            menuStrip.Margin = new Padding(0);
            return menuStrip;
        }

        public ToolStripMenuItem toolStripMenu(object type, MenuStrip menuStrip)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = String.Format("{0}", type);
            toolStripMenuItem.Text = toolStripMenuItem.Name;
            toolStripMenuItem.Size = new Size(154, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem });
            return toolStripMenuItem;
        }

        public ToolStripMenuItem toolStripMenu(TypeForm type, ToolStripMenuItem toolStrip)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = String.Format("{0}{1}",  type, toolStrip.Name);
            toolStripMenuItem.Text = toolStripMenuItem.Name;
            toolStripMenuItem.Size = new Size(154, 24);
            toolStrip.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem });
            return toolStripMenuItem;
        }

        public ToolStripMenuItem toolStripMenu(MenuFile type, ToolStripMenuItem toolStrip)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = String.Format("{0}", type);
            toolStripMenuItem.Text = toolStripMenuItem.Name;
            toolStripMenuItem.Size = new Size(154, 24);
            toolStrip.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem });
            return toolStripMenuItem;
        }

        public ToolStripMenuItem toolStripMenu(MenuView type, ToolStripMenuItem toolStrip)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = String.Format("{0}", type);
            toolStripMenuItem.Text = toolStripMenuItem.Name;
            toolStripMenuItem.Size = new Size(154, 24);
            toolStrip.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem });
            return toolStripMenuItem;
        }

        public ToolStrip stripTool()
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Location = new Point(0, 24);
            toolStrip.Size = new Size(653, 25);
            toolStrip.Padding = new Padding(0);
            toolStrip.Margin = new Padding(0);
            return toolStrip;
        }

        public ToolStripButton toolStripButton(object type, MenuBar menuBar, ToolStrip toolStrip)
        {
            ToolStripButton toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton.Image = null;
            toolStripButton.ImageTransparentColor = Color.Magenta;
            toolStripButton.Name = String.Format("{0}{1}", type, menuBar);
            toolStripButton.Text = toolStripButton.Name;
            toolStripButton.Size = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripButton[] { toolStripButton });
            return toolStripButton;
        }

        public ToolStripButton toolStripButton(object type, ToolStrip toolStrip)
        {
            ToolStripButton toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton.Image = null;
            toolStripButton.ImageTransparentColor = Color.Magenta;
            toolStripButton.Name = String.Format("{0}", type);
            toolStripButton.Text = toolStripButton.Name;
            toolStripButton.Size = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripButton[] { toolStripButton });
            return toolStripButton;
        }

        public ToolStripButton toolStripButton(MenuView type, ToolStrip toolStrip)
        {
            ToolStripButton toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton.Image = null;
            toolStripButton.ImageTransparentColor = Color.Magenta;
            toolStripButton.Name = String.Format("{0}", type);
            toolStripButton.Text = toolStripButton.Name;
            toolStripButton.Size = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripButton[] { toolStripButton });
            return toolStripButton;
        }

        public void toolStripSeparator(ToolStrip toolStrip)
        {
            ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator.Size = new Size(6, 27);
            toolStrip.Items.AddRange(new ToolStripSeparator[] { toolStripSeparator });
        }
    }
}

