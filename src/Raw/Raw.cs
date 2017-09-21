using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Raw
{
    public class Raw
    {
        public static string Get(string fullpath)
        {
            string raw;
            using (FileStream fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    raw = r.ReadToEnd();
                }
            }
            return raw;
        }

        public static void Store(string fullpath, string raw)
        {
            using (FileStream fs = new FileStream(fullpath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
                    w.Write(raw);
                }
            }
        }
    }
}
