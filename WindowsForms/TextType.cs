using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    enum Language { Ru, Ua };

    class TextType
    {
        private static Language language = Language.Ru;
        private static string path;
        public static string[] name, filter, main, application, engraving, specification, printing;

        public TextType(Language Language)
        {
            language = Language;
            if (language == Language.Ru)
                path = "Text/Ru/";
            if (language == Language.Ua)
                path = "Text/Ua/";
            try
            {
                name = File.ReadAllLines(String.Format("{0}name.txt", path));
                filter = File.ReadAllLines(String.Format("{0}filter.txt", path));
                main = File.ReadAllLines(String.Format("{0}main.txt", path));
                application = File.ReadAllLines(String.Format("{0}application.txt", path));
                engraving = File.ReadAllLines(String.Format("{0}engraving.txt", path));
                specification = File.ReadAllLines(String.Format("{0}specification.txt", path));
                printing = File.ReadAllLines(String.Format("{0}printing.txt", path));
            }
            catch
            {

            }
        }
    }
}
