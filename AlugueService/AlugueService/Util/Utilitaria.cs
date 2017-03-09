using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.Util
{
    public class Utilitaria
    {
        public String normalizarString(string str)
        {
            string aux = str;

            aux = aux.Trim().ToUpper();

            string[] split = aux.Split(new char[] { ' ' });

            string stringNormalizada = "";

            for (int i = 0; i < split.Length; i++)
            {
                string s = split[i];

                if (!s.Equals(""))
                {
                    stringNormalizada += s;

                    if (i < split.Length - 1)
                    {
                        stringNormalizada += " ";
                    }
                }

            }

            return stringNormalizada;
        }

        public String DesnormalizarString(string str)
        {
            string aux = str;
            System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            aux = aux.Trim().ToLower();

            string[] split = aux.Split(new char[] { ' ' });

            string stringDesnormalizada = "";

            for (int i = 0; i < split.Length; i++)
            {
                string s = split[i];

                if (!s.Equals(""))
                {
                    stringDesnormalizada += s;

                    if (i < split.Length - 1)
                    {
                        stringDesnormalizada += " ";
                    }
                }

            }

            return cultureinfo.TextInfo.ToTitleCase(stringDesnormalizada);

        }
    }
}