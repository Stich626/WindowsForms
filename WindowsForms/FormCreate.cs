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
    class FormCreate
    {
        public FormCreate(Form form)
        {
            //
            //язык приложения
            //
            new FormText(Language.Ru);
            //
            //создание формы
            //
            new FormType(form);
            //
            //разер формы
            //
            new FormSize(form);
            //
            //создание контролов
            //  
            new ControlCreate(form);
            //
            //события контролов
            //
            new ControlEvent(form);
            //
            //размещение контролов
            //
            new ContriolInsert(form);
            //
            //события формы
            //
            new FormEvent(form);
            //
            //данные формы
            //
            new FormData(form);
            //
            //текста формы
            //
            new FormText(form);
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}


