using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class Collection<T> : List<T>
        where T : Model<T>
    {
        public T first()
        {
            return this[0];
        }

        public T last()
        {
            return this[this.Count - 1];
        }

        public Collection<T> get()
        {
            return this;
        }
    }
}
