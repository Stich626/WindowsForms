using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class FormSize
    {
        //
        //расположение формы
        //
        private static MenuView viewSize = MenuView.cascade;
        private static bool flagSize;
        //
        //минимальный размер
        //
        private static Size mdiSize;
        //
        //коректировка размера
        //
        private Size corSize = new Size(4, 8);

        public FormSize(object sender)
        {
            if (sender is Main)
                mdiSize = clientSize((Main)sender);
            if (sender is Document)
            {
                Document form = sender as Document;
                form.minSize.Size = new Size(mdiSize.Width / 2, mdiSize.Height) -
                                      new Size(corSize.Width, corSize.Height) -
                                              (form.Size - form.ClientSize);
            }

            if (sender is Registry)
            {
                Registry form = sender as Registry;
                form.minSize.Size = new Size(mdiSize.Width / 2, mdiSize.Height) -
                                      new Size(corSize.Width, corSize.Height) -
                                              (form.Size - form.ClientSize);
            }
            if (sender is Settings)
            {
                Settings form = sender as Settings;
                form.minSize.Size = new Size(mdiSize.Width / 2, mdiSize.Height) -
                                      new Size(corSize.Width, corSize.Height) -
                                              (form.Size - form.ClientSize);
            }
        }

        public FormSize (MenuView view)
        {
            viewSize = view;
            Form mdiParent = FormType.mdiParent;
            for (byte i = 0; i < mdiParent.MdiChildren.Length; i++)
                if (mdiParent.MdiChildren[i] != null)
                    formSize(mdiParent.MdiChildren[i]);
        }

        public FormSize(Form form)
        {
            formSize(form);
        }

        private void formSize(Form form)
        {
            if (form is Main)
                form.WindowState = FormWindowState.Maximized;
            if (form is Document || form is Registry || form is Settings)
            {
                if (viewSize == MenuView.horizontally)
                {
                    if (!flagSize)
                        form.Location = new Point(0, 0);
                    else
                        form.Location = new Point(0, (mdiSize.Height - corSize.Height) / 2);
                    form.Size = new Size(mdiSize.Width - corSize.Width,
                                        (mdiSize.Height - corSize.Height) / 2);
                }
                if (viewSize == MenuView.cascade)
                {
                    form.Location = new Point(0, 0);
                    form.Size = mdiSize - corSize;
                }
                if (viewSize == MenuView.vertically)
                {
                    if (!flagSize)
                        form.Location = new Point(0, 0);
                    else
                        form.Location = new Point((mdiSize.Width - corSize.Width) / 2, 0);
                    form.Size = new Size((mdiSize.Width - corSize.Width) / 2, 
                                          mdiSize.Height - corSize.Height);
                }
                if (flagSize)
                    flagSize = false;
                else
                    flagSize = true;
            }
          
            if (form is Edit)
                form.Size = new Size(mdiSize.Height / 2, mdiSize.Height / 2);              
        }

        private Size clientSize(Main form)
        {
            Size size = new Size(form.ClientSize.Width,
                form.ClientSize.Height - (form.menu.Height + form.tool.Height));
            return size;
        }
    }
}

