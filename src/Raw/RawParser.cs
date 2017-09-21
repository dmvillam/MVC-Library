using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Raw
{
    public class RawParser
    {
        /*
         * data to parse has to be in format:
         * "key1=value1 \r\n key2=value2 \r\n key3 = value3 \r\n"
         * 
         * Commentaries: "#commentary", ";commentary", "//commentary"
         */
        public static void Parse1(string raw, Dictionary<string, string> dict)
        {
            List<string> lines = Regex.Split(raw, "\r\n").ToList();
            Dictionary<string, string> edit = new Dictionary<string, string>();

            foreach(string line in lines)
            {
                if (line.StartsWith("#") || line.StartsWith(";") || line.StartsWith("//"))
                    continue;

                string[] pair = line.Split('=');
                if (pair.Length==2)
                {
                    foreach (KeyValuePair<string, string> elem in dict)
                    {
                        if (elem.Key == pair[0].Trim())
                        {
                            edit.Add(elem.Key, pair[1].Trim());
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, string> elem in edit)
                dict[elem.Key] = elem.Value;
        }
    }
}
